using Fac.Controladora.DTOs.PadreAtletaDtos;
using Fac.Controladora.DTOs.TutorAtletaDtos;
using Fac.Controladora.Services.PadreServices;
using Fac.Controladora.Services.TutorAtletaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorAtletaController : ControllerBase
    {
        private readonly ITutorAtletaServices _services;
        public TutorAtletaController(ITutorAtletaServices services)
        {
            _services = services;
        }

        // GET: api/<TutorAtletaController>
        [HttpGet]
        public async Task<List<TutorAtletaDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<TutorAtletaController>/5
        [HttpGet("{id}")]
        public async Task<TutorAtletaDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<TutorAtletaController>
        [HttpPost]
        public async Task<TutorAtletaDetalleDto> Post([FromBody] TutorAtletaCrearDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<TutorAtletaController>/5
        [HttpPut("{id}")]
        public async Task<TutorAtletaDetalleDto> Put(int id, [FromBody] TutorAtletaCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<TutorAtletaController>/5
        [HttpDelete("{id}")]
        public async Task<TutorAtletaDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
 