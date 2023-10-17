using AutoMapper;
using Fac.Controladora.DTOs.AtletaDtos;
using Fac.Entidades;

namespace FAC.API.Controllers.AutoMapper
{
    public class AutoMapping : Profile
    {
        protected AutoMapping()
        {
            CreateMap<AtletaCrearDto, Atleta>();
        }
    }
}
