
using Fac.Controladora.DTOs.LoginUser;
using Fac.Controladora.Services.LoginUserServices;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using FAC.API.Recursos;
using Microsoft.AspNetCore.Identity;
using Fac.Entidades;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[TypeFilter(typeof(ExceptionManagerFilter))]
    public class LoginUserController : ControllerBase
    {
        private readonly ILoginUserServices _services;
        private readonly IConfiguration _configuration;
        //private readonly ILogger<LoginUserController> logger;

        public LoginUserController(ILoginUserServices services, IConfiguration configuration /*ILogger<LoginUserController> logger*/)
        {
            _services = services;
            //this.logger = logger;
            _configuration = configuration;

        }

        // GET: api/<AtletaController>
        [HttpGet]
       
        public async Task<List<LoginUserDetalleDto>> Get()
        {
            //logger.LogInformation("Obtener Todos los Logins");
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        
        public async Task<LoginUserDetalleDto> GetPorId(int id)
        {

           // logger.LogDebug($"Se Obtuvo un atleta con el id n {id}");
            //logger.LogWarning($"Ese Atleta no existe id {id}");
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<UsuarioController>
        [HttpPost]
       
        public async Task<LoginUserDetalleDto> Post([FromBody] LoginUserCrearDto dto)
        {
            //logger.LogWarning("Hubo un error al crear el login");
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        
        public async Task<LoginUserDetalleDto> Put(int id, [FromBody] LoginUserCrearDto dto)
        {
            //logger.LogInformation("Se modifico un dato de un login");
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
      
        public async Task<LoginUserDetalleDto> Delete(int id)
        {
            //logger.LogInformation("Se elimino el login");
            var respuesta = await _services.Remover(id);
            return respuesta;
        }


    }
}
