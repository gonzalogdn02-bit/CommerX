using CommerX.Domain.Clients.Entities;
using CommerX.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CommerX.Infrastructure.Data;

public sealed class CommerXDbContext : DbContext
{
    public CommerXDbContext(DbContextOptions<CommerXDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}