using Microsoft.EntityFrameworkCore;
using Wayni.Application.Interfaces.Infraestructure;
using Wayni.Application.Interfaces.Services;
using Wayni.Application.Models.Features.Usuario.Dto;
using Wayni.Application.Models.Features.Usuario.Requests;
using Wayni.Shared.Common.Constants;
using Wayni.Shared.Common.Extensions;
using Wayni.Shared.Common.Wrappers;

namespace Wayni.Application.Services.Features.Usuario;

internal class UsuarioService : IUsuarioService
{
    private readonly IWayniDbContext _dbContext;

    public UsuarioService(IWayniDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BaseResponse<DtoUsuario>> ObtenerAsync(int id)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario is null) return BaseResponse<DtoUsuario>.Error(BaseMessages.REGISTRO_NOEXISTE);
        var dtoUsuario = usuario.MapTo<Domain.Entities.Usuario, DtoUsuario>();
        return BaseResponse<DtoUsuario>.Ok(dtoUsuario);
    }

    public async Task<BaseResponse<List<DtoUsuario>>> ListarAsync()
    {
        var usuarios = await _dbContext.Usuarios.ToListAsync();
        var dtoUsuario = usuarios.MapTo<Domain.Entities.Usuario, DtoUsuario>();
        return BaseResponse<List<DtoUsuario>>.Ok(dtoUsuario);
    }

    public async Task<BaseResponse<bool>> RegistrarAsync(RegistrarUsuarioRequest request)
    {
        var usuario = request.MapTo<RegistrarUsuarioRequest, Domain.Entities.Usuario>();
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
        return BaseResponse<bool>.Ok(true, BaseMessages.REGISTRO_EXITOSO);
    }

    public async Task<BaseResponse<bool>> ModificarAsync(ModificarUsuarioRequest request)
    {
        var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (usuario is null) return BaseResponse<bool>.Error(BaseMessages.REGISTRO_NOEXISTE);

        usuario.Nombres = request.Nombres ?? usuario.Nombres;
        usuario.Apellidos = request.Apellidos ?? usuario.Apellidos;
        usuario.NumeroDocumento = request.NumeroDocumento ?? usuario.NumeroDocumento;
        usuario.Avatar = request.Avatar ?? usuario.Avatar;

        await _dbContext.SaveChangesAsync(CancellationToken.None);
        return BaseResponse<bool>.Ok(true, BaseMessages.MODIFICA_EXITOSO);
    }

    public async Task<BaseResponse<bool>> EliminarAsync(int id)
    {
        var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuario is null) return BaseResponse<bool>.Error(BaseMessages.REGISTRO_NOEXISTE);

        _dbContext.Usuarios.Remove(usuario);
        await _dbContext.SaveChangesAsync();
        return BaseResponse<bool>.Ok(true, BaseMessages.ELIMINAR_EXITOSO);
    }
}