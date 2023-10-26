using Fac.Controladora.DTOs.AtletaDtos;
using Fac.Controladora.DTOs.MadreAtletaDtos;
using Fac.Controladora.Services.AtletaServices;
using Fac.Controladora.Services.MadreAtletaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MadreAtletaController : ControllerBase
    {
        private readonly IMadreAtletaServices _services;
        public MadreAtletaController(IMadreAtletaServices services)
        {
            _services = services;
        }

        // GET: api/<MadreAtletaController>
        [HttpGet]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<List<MadreAtletaDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<MadreAtletaController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<MadreAtletaDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<MadreAtletaController>
        [HttpPost]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<MadreAtletaDetalleDto> Post([FromBody] MadreAtletaCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<MadreAtletaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<MadreAtletaDetalleDto> Put(int id, [FromBody] MadreAtletaCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<MadreAtletaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<MadreAtletaDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}

