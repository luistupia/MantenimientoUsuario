using Microsoft.AspNetCore.Mvc;
using Wayni.Application.Interfaces.Services;
using Wayni.Application.Models.Features.Usuario.Requests;

namespace WebApp.Controllers;

[Route("usuarios")]
public class UsuariosController(IUsuarioService usuarioService) : Controller
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Obtener(int id) => Ok(await usuarioService.ObtenerAsync(id));

    [HttpGet("listar")]
    public async Task<IActionResult> Listar() => Ok(await usuarioService.ListarAsync());

    [HttpPost("registrar")]
    [ServiceFilter(typeof(ValidationModelFilter))]
    public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioRequest request)
        => Ok(await usuarioService.RegistrarAsync(request));

    [HttpPost("modificar")]
    [ServiceFilter(typeof(ValidationModelFilter))]
    public async Task<IActionResult> Modificar([FromBody] ModificarUsuarioRequest request)
        => Ok(await usuarioService.ModificarAsync(request));

    [HttpPost("eliminar")]
    public async Task<IActionResult> Eliminar([FromBody] EliminarUsuarioRequest request)
        => Ok(await usuarioService.EliminarAsync(request.Id));
}