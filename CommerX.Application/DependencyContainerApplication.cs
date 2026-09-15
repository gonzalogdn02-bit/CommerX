using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.Application.Clients.UseCases;
using CommerX.Application.Clients.Validation;
using CommerX.Application.Common.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace CommerX.Application;

public static class DependencyContainerApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddScoped<ICreateClientInputPort, CreateClientUseCase>();
        services.AddScoped<IUpdateClientInputPort, UpdateClientInteractor>();

        services.AddScoped<IModelValidatorHub<CreateClientRequest>, CreateClientValidationHub>();

        return services;
    }
}