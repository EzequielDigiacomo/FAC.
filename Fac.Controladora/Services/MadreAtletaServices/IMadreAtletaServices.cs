using Fac.Controladora.DTOs.MadreAtletaDtos;

namespace Fac.Controladora.Services.MadreAtletaServices
{
    public interface IMadreAtletaServices
    {
        Task<MadreAtletaDetalleDto> Actualizar(int id, MadreAtletaCrearDto dto);
        Task<MadreAtletaDetalleDto> Crear(MadreAtletaCrearDto dto);
        Task<MadreAtletaDetalleDto> ObtenerPorId(int id);
        Task<List<MadreAtletaDetalleDto>> ObtenerTodos();
        Task<MadreAtletaDetalleDto> Remover(int id);
    }
}