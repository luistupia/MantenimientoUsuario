using System.Text.Json.Serialization;

namespace Wayni.Application.Models.Features.Usuario.Dto;

public class DtoUsuario
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Nombres")]
    public string? Nombres { get; set; }

    [JsonPropertyName("Apellidos")]
    public string? Apellidos { get; set; }

    [JsonPropertyName("NumeroDocumento")]
    public string? NumeroDocumento { get; set; }

    [JsonPropertyName("Avatar")]
    public string? Avatar { get; set; }
}