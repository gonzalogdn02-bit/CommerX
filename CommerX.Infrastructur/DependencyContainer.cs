using CommerX.Domain.Clients.Repositories;
using CommerX.Infrastructure.Clients;
using CommerX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<CommerXDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}