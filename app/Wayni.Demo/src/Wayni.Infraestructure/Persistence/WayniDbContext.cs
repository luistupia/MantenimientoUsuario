using Microsoft.EntityFrameworkCore;
using Wayni.Application.Interfaces.Infraestructure;
using Wayni.Domain.Entities;

namespace Wayni.Infraestructure.Persistence;

internal class WayniDbContext : DbContext, IWayniDbContext
{
    public WayniDbContext(DbContextOptions<WayniDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);
}