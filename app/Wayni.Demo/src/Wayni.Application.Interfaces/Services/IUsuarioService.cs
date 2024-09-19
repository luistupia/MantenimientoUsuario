using Wayni.Application.Models.Features.Usuario.Dto;
using Wayni.Application.Models.Features.Usuario.Requests;
using Wayni.Shared.Common.Wrappers;

namespace Wayni.Application.Interfaces.Services;

public interface IUsuarioService
{
    Task<BaseResponse<DtoUsuario>> ObtenerAsync(int id);
    Task<BaseResponse<List<DtoUsuario>>> ListarAsync();
    Task<BaseResponse<bool>> RegistrarAsync(RegistrarUsuarioRequest request);
    Task<BaseResponse<bool>> ModificarAsync(ModificarUsuarioRequest request);
    Task<BaseResponse<bool>> EliminarAsync(int id);
}