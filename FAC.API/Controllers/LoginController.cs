using Fac.Controladora.DTOs.LoginUser;
using Fac.Entidades;
using FAC.API.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration config)
        {
            _configuration = config;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUser();

                return Ok($"Hola {currentUser.FirstName}, tu eres {currentUser.Rol} " );
        }

        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                //crear token

                var token = Generate(user);

                return Ok(token);
            }

            return NotFound("Usuario no encontrado");
        }

        private UserModel Authenticate(LoginUser userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(user => user.UserName.ToLower() == userLogin.UserName.ToLower()
            && user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        //Estos metodos hay que ponerlos en otro lado

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //crear los claims (reclamaciones)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAdress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            //crear el token
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                         _configuration["Jwt:Audience"],
                                         claims,
                                         expires: DateTime.Now.AddMinutes(1),
                                         signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAdress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Rol = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }


    }



}
