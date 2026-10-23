using CommerX.Application.Clients.Ports;
using CommerX.Application.Clients.Ports.CommerX.Application.Clients.Ports;
using CommerX.InterfaceAdapter.Clients.Common.Presenter;
using CommerX.InterfaceAdapter.Clients.Presenters;
using CommerX.InterfaceAdapter.Clients.ViewModels;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{

    public static IServiceCollection AddCustomerPresenter(this IServiceCollection services)
    {
        services.AddScoped<CreateClientPresenter>();
        services.AddScoped<ICreateClientOutputPort>(
            sp => sp.GetRequiredService<CreateClientPresenter>());

        return services;
    }
    public static IServiceCollection AddUpdateCustomerPresenter(this IServiceCollection services)
    {
        services.AddScoped<UpdateClientPresenter>();
        services.AddScoped<IUpdateClientOutputPort>(
            sp => (IUpdateClientOutputPort)sp.GetRequiredService<UpdateClientPresenter>());

        return services;
    }
    public static IServiceCollection AddCustomerViewModel(this IServiceCollection services)
    {
        services.AddScoped<CreateClientViewModel>();
        return services;
    }
    public static IServiceCollection AddClientPresenters(this IServiceCollection services)
    {
        services.AddCustomerPresenter();
        services.AddUpdateCustomerPresenter();
        return services;
    }
    public static IServiceCollection AddClientViewModel(this IServiceCollection services)
    {
        return services.AddCustomerViewModel();
    }
}