using Fac.Controladora.DTOs.LoginUser;
using Fac.Entidades;

namespace Fac.Controladora.Services.LoginUserServices
{
    public interface ILoginUserServices
    {
        Task<LoginUserDetalleDto> Actualizar(int id, LoginUserCrearDto dto);
        Task<LoginUserDetalleDto> Crear(LoginUserCrearDto dto);
        Task<LoginUserDetalleDto> ObtenerPorId(int id);
        Task<List<LoginUserDetalleDto>> ObtenerTodos();
        Task<LoginUserDetalleDto> Remover(int id);

        //------------------



    }
}