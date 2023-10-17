using Fac.Controladora.DTOs.PadreAtletaDtos;

namespace Fac.Controladora.Services.PadreServices
{
    public interface IPadreAtletaServices
    {
        Task<PadreAtletaDetalleDto> Actualizar(int id, PadreAtletaCrearDto dto);
        Task<PadreAtletaDetalleDto> Crear(PadreAtletaCrearDto dto);
        Task<PadreAtletaDetalleDto> ObtenerPorId(int id);
        Task<List<PadreAtletaDetalleDto>> ObtenerTodos();
        Task<PadreAtletaDetalleDto> Remover(int id);
    }
}