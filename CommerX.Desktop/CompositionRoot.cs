using System;
using CommerX.Application;
using CommerX.Domain.Clients.Repositories;
using CommerX.Infrastructure;
using CommerX.Infrastructure.Clients;
using CommerX.InterfaceAdapter.Clients.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommerX.Desktop;

public static class CompositionRoot
{
    public static IServiceCollection AddCommerX(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CommerX")
            ?? throw new InvalidOperationException(
                "Falta la cadena de conexión CommerX en appsettings.json (sección ConnectionStrings).");

        services.AddCustomerUseCases();

        services.AddCustomerPresenter();
        services.AddUpdateCustomerPresenter();
        services.AddCustomerViewModel();

        services.AddScoped<IClientRepository, ClientRepository>();

        services.AddTransient<CreateClientViewModel>();

        services.AddInfrastructure(connectionString);

        services.AddWpfBlazorWebView();

        services.AddSingleton<DatabaseHealthCheck>();
        services.AddSingleton<MainWindow>();

        return services;
    }
}