using CommerX.Application.Clients.Ports;
using CommerX.InterfaceAdapter.Clients.Presenters;
using CommerX.InterfaceAdapter.Clients.ViewModels;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddClientPresenters(this IServiceCollection services)
    {
        services.AddScoped<CreateClientPresenter>();
        services.AddScoped<ICreateClientOutputPort>(
            sp => sp.GetRequiredService<CreateClientPresenter>());

        return services;
    }

    public static IServiceCollection AddClientViewModel(this IServiceCollection services)
    {
        services.AddScoped<CreateClientViewModel>();
        return services;
    }
}