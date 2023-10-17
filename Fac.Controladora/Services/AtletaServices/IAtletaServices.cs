using Fac.Controladora.DTOs.AtletaDtos;

namespace Fac.Controladora.Services.AtletaServices
{
    public interface IAtletaServices
    {
        Task<AtletaDetalleDto> Actualizar(int id, AtletaCrearDto dto);
        Task<AtletaDetalleDto> Crear(AtletaCrearDto dto);
        Task<AtletaDetalleDto> ObtenerPorId(int id);
        Task<List<AtletaDetalleDto>> ObtenerTodos();
        Task<AtletaDetalleDto> Remover(int id);
    }
}