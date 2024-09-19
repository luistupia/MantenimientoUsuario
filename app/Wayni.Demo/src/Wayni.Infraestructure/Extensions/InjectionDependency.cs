using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wayni.Application.Interfaces.Infraestructure;
using Wayni.Infraestructure.Persistence;

namespace Wayni.Infraestructure.Extensions;

public static class InjectionDependency
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WayniDbContext>((sp, options) =>
        {
            var cadena = configuration.GetConnectionString("SqlConnection")!;
            options.UseSqlServer(cadena);
        });


        services.AddScoped<IWayniDbContext, WayniDbContext>();

        return services;
    }
}