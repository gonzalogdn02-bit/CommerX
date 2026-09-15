using CommerX.Application.Clients.Ports;
using CommerX.InterfaceAdapter.Clients.ViewModels;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddClientPresenters(this IServiceCollection services)
    {

        services.AddScoped<CreateClientViewModel>();

        services.AddScoped<ICreateClientOutputPort>(
            sp => sp.GetRequiredService<CreateClientViewModel>());

        return services;
    }
}