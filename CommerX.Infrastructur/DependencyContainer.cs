using CommerX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommerX.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CommerXDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}