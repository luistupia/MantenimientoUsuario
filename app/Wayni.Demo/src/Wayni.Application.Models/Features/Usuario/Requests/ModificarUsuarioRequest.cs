﻿namespace Wayni.Application.Models.Features.Usuario.Requests;

public record ModificarUsuarioRequest(
    int Id,
    string? Nombres,
    string? Apellidos,
    string? NumeroDocumento,
    string? Avatar
);