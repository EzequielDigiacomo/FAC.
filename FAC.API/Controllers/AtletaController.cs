using AutoMapper;
using Fac.Controladora.DTOs.AtletaDtos;
using Fac.Controladora.Services.AtletaServices;
using Fac.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaServices _services;
       
        public AtletaController(IAtletaServices services)
        {
            _services = services;
          
        }

        // GET: api/<AtletaController>
        [HttpGet]
       
        public async Task<List<AtletaDetalleDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<AtletaDetalleDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<AtletaDetalleDto> Post([FromBody] AtletaCrearDto dto)
        {
            //var atleta = _mapper.Map<Atleta>(dto);
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<AtletaDetalleDto> Put(int id, [FromBody] AtletaCrearDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<AtletaDetalleDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
