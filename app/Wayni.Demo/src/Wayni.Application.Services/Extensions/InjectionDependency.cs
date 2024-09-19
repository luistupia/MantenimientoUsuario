using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wayni.Application.Interfaces.Services;
using Wayni.Application.Services.Features.Usuario;

namespace Wayni.Application.Services.Extensions;

public static class InjectionDependency
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        services.AddTransient<IUsuarioService, UsuarioService>();
        return services;
    }
}