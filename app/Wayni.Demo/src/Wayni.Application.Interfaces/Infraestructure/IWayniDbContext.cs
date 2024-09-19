using Microsoft.EntityFrameworkCore;
using Wayni.Domain.Entities;

namespace Wayni.Application.Interfaces.Infraestructure;

public interface IWayniDbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}