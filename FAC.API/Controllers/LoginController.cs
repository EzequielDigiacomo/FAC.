﻿using Fac.Controladora.DTOs.LoginUser;
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
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
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
            var currentUser = UserConstants.Users.FirstOrDefault(user => user.Username.ToLower() == userLogin.UserName.ToLower()
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
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //crear los claims (reclamaciones)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAdress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            //crear el token
            var token =  new JwtSecurityToken(_config["Jwt:Key"],
                                         _config["Jwt:Audience"],
                                         claims,
                                         expires: DateTime.Now.AddMinutes(60),
                                         signingCredentials: credentials);
       
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
