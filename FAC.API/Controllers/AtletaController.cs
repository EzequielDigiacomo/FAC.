using Fac.Controladora.DTOs.AtletaDtos;
using Fac.Controladora.Services.AtletaServices;
using FAC.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerFilter))]
   
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaServices _services;
        private readonly ILogger<AtletaController> logger;

        public AtletaController(IAtletaServices services, ILogger<AtletaController> logger)
        {
            _services = services;
            this.logger = logger;
        }

        // GET: api/<AtletaController>
        [HttpGet]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros") )]
        public async Task<List<AtletaDetalleDto>> Get()
        {
            logger.LogInformation("Obtener Todos los atletas");
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<AtletaDetalleDto> GetPorId(int id)
        {
            
            logger.LogDebug($"Se Obtuvo un atleta con el id n {id}");
            logger.LogWarning($"Ese Atleta no existe id {id}");
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<AtletaDetalleDto> Post([FromBody] AtletaCrearDto dto)
        {
            logger.LogWarning("Hubo un error al crear el atleta");
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<AtletaDetalleDto> Put(int id, [FromBody] AtletaCrearDto dto)
        {
            logger.LogInformation("Se modifico un dato de un atleta");
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<AtletaDetalleDto> Delete(int id)
        {
            logger.LogInformation("Se elimino un atleta");
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
