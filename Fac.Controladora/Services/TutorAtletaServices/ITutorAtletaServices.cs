using Fac.Controladora.DTOs.TutorAtletaDtos;

namespace Fac.Controladora.Services.TutorAtletaServices
{
    public interface ITutorAtletaServices
    {
        Task<TutorAtletaDetalleDto> Actualizar(int id, TutorAtletaCrearDto dto);
        Task<TutorAtletaDetalleDto> Crear(TutorAtletaCrearDto dto);
        Task<TutorAtletaDetalleDto> ObtenerPorId(int id);
        Task<List<TutorAtletaDetalleDto>> ObtenerTodos();
        Task<TutorAtletaDetalleDto> Remover(int id);
    }
}