using Fac.AccesoDatos;
using Fac.Controladora.DTOs.LoginUser;
using Fac.Controladora.DTOs.MadreAtletaDtos;
using Fac.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Controladora.Services.LoginUserServices
{
    public class LoginUserServices : ILoginUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginUserServices(ApplicationDbContext context, IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<LoginUserDetalleDto>> ObtenerTodos()
        {
            var loginLista = await _context.Login.Select(l => new LoginUserDetalleDto
            {
                Id = l.Id,
                UserName = l.UserName,
                Password = l.Password,
                EmailAdress = l.EmailAdress,
                Rol = l.Rol,
                LastName = l.LastName,
                FirstName = l.FirstName,

            }).ToListAsync();

            return loginLista;
        }

        public async Task<LoginUserDetalleDto> ObtenerPorId(int id)
        {
            var login = await BuscarPorId(id);

            return new LoginUserDetalleDto
            {
                Id = login.Id,
                UserName = login.UserName,
                Password = login.Password,
                EmailAdress = login.EmailAdress,
                Rol = login.Rol,
                LastName = login.LastName,
                FirstName = login.FirstName,
            };
        }

        public async Task<LoginUserDetalleDto> Crear(LoginUserCrearDto dto)
        {
            var emailRepetido = await _context.Login.AnyAsync(x => x.EmailAdress == dto.EmailAdress);
            if (emailRepetido)
            {
                throw new Exception($"Ya existe una cuenta con ese email {dto.EmailAdress}");
            }

            var login = new UserModel
            {
                UserName = dto.UserName,
                Password = dto.Password,
                EmailAdress = dto.EmailAdress,
                Rol = dto.Rol,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
            };


            await _context.AddAsync(login);
            await _context.SaveChangesAsync();

            return new LoginUserDetalleDto
            {
                Id = login.Id,
                UserName = dto.UserName,
                Password = dto.Password,
                EmailAdress = dto.EmailAdress,
                Rol = dto.Rol,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
            };

        }

        public async Task<LoginUserDetalleDto> Actualizar(int id, LoginUserCrearDto dto)
        {
            var emailRepetido = await _context.Login.AnyAsync(x => x.EmailAdress == dto.EmailAdress);
            if (emailRepetido)
            {
                throw new Exception($"Ya existe una cuenta con ese email {dto.EmailAdress}");
            }

            var login = await BuscarPorId(id);

            login.UserName = dto.UserName;
            login.Password = dto.Password;
            login.EmailAdress = dto.EmailAdress;
            login.Rol = dto.Rol;
            login.LastName = dto.LastName;
            login.FirstName = dto.FirstName;


            _context.Update(login);
            await _context.SaveChangesAsync();

            return new LoginUserDetalleDto
            {
                Id = login.Id,
                UserName = login.UserName,
                Password = login.Password,
                EmailAdress = login.EmailAdress,
                Rol = login.Rol,
                LastName = login.LastName,
                FirstName = login.FirstName,
            };
        }

        public async Task<LoginUserDetalleDto> Remover(int id)
        {
            var login = await BuscarPorId(id);
            _context.Remove(login);
            await _context.SaveChangesAsync();

            return new LoginUserDetalleDto
            {
                Id = login.Id,
                UserName = login.UserName,
                Password = login.Password,
                EmailAdress = login.EmailAdress,
                Rol = login.Rol,
                LastName = login.LastName,
                FirstName = login.FirstName,
            };
        }


        private async Task<UserModel> BuscarPorId(int id)
        {
            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return login;
        }

        //----------------------------------

        //public async Task<UserModel> Login(LoginUser userLogin)
        //{
        //    var user = await Authenticate(userLogin);

        //    if (user != null)
        //    {
        //        //crear token

        //        var token = Generate(user);

        //        return token;
        //    }

        //    return NotFound("Usuario no encontrado");
        //}
        //private UserModel Authenticate(LoginUser userLogin)
        //{
        //    var currentUser = UserConstants.Users.FirstOrDefault(user => user.UserName.ToLower() == userLogin.UserName.ToLower()
        //    && user.Password == userLogin.Password);

        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }
        //    return null;
        //}

        ////Estos metodos hay que ponerlos en otro lado

        //private string Generate(UserModel user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    //crear los claims (reclamaciones)
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.UserName),
        //        new Claim(ClaimTypes.Email, user.EmailAdress),
        //        new Claim(ClaimTypes.GivenName, user.FirstName),
        //        new Claim(ClaimTypes.Surname, user.LastName),
        //        new Claim(ClaimTypes.Role, user.Rol),
        //    };

        //    //crear el token
        //    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        //                                 _configuration["Jwt:Audience"],
        //                                 claims,
        //                                 expires: DateTime.Now.AddMinutes(1),
        //                                 signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private UserModel GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;

        //    if (identity != null)
        //    {
        //        var userClaims = identity.Claims;
        //        return new UserModel
        //        {
        //            UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //            EmailAdress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
        //            FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
        //            LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
        //            Rol = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
        //        };
        //    }
        //    return null;
        //}
    }
}

