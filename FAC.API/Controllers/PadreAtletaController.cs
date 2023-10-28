using Fac.Controladora.DTOs.MadreAtletaDtos;
using Fac.Controladora.DTOs.PadreAtletaDtos;
using Fac.Controladora.Services.MadreAtletaServices;
using Fac.Controladora.Services.PadreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PadreAtletaController : ControllerBase
    {
        private readonly IPadreAtletaServices _services;
        public PadreAtletaController(IPadreAtletaServices services)
        {
            _services = services;
        }

        // GET: api/<PadreAtletaController>
        [HttpGet]
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<List<PadreAtletaDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<PadreAtletaController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<PadreAtletaDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<PadreAtletaController>
        [HttpPost]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<PadreAtletaDetalleDto> Post([FromBody] PadreAtletaCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<PadreAtletaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<PadreAtletaDetalleDto> Put(int id, [FromBody] PadreAtletaCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<PadreAtletaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<PadreAtletaDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}

