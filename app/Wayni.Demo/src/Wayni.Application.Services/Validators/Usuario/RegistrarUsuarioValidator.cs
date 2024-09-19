using FluentValidation;
using Wayni.Application.Models.Features.Usuario.Requests;

namespace Wayni.Application.Services.Validators.Usuario;

public class RegistrarUsuarioValidator : AbstractValidator<RegistrarUsuarioRequest>
{
    public RegistrarUsuarioValidator()
    {
        RuleFor(x => x.Nombres)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Apellidos)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.NumeroDocumento)
            .MaximumLength(11)
            .NotEmpty()
            .NotNull();
    }
}