using Microsoft.EntityFrameworkCore;

namespace Callcenter.Backend.Infrastructure.Common;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Agent> Agents { get; set; } = null!;

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}