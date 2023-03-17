using Microsoft.EntityFrameworkCore;
using Naxxum.Enlightenment.Domain.Entities;
using Naxxum.Enlightenment.Infrastructure.Data.Configurations;

namespace Naxxum.Enlightenment.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Client { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfiguration(new ClientConfiguration());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}