namespace Wayni.Application.Models.Features.Usuario.Requests;

public record RegistrarUsuarioRequest(
    string? Nombres,
    string? Apellidos,
    string? NumeroDocumento,
    string? Avatar
);