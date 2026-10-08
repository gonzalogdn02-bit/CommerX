using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CommerX.Infrastructure.Data;

public sealed class CommerXDbContextFactory : IDesignTimeDbContextFactory<CommerXDbContext>
{
    private const string DesignTimeConnectionString =
        "Server=(localdb)\\MSSQLLocalDB;Database=CommerX;Trusted_Connection=True;TrustServerCertificate=True;";

    public CommerXDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<CommerXDbContext>()
            .UseSqlServer(DesignTimeConnectionString)
            .Options;

        return new CommerXDbContext(options);
    }
}