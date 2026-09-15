using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.Application.Clients.Ports.CommerX.Application.Clients.Ports;
using CommerX.Domain.Clients.Repositories;
using CommerX.Domain.Common.Exceptions;

namespace CommerX.Application.Clients.UseCases;

public sealed class UpdateClientInteractor : IUpdateClientInputPort
{
    private readonly IClientRepository _repository;
    private readonly IUpdateClientOutputPort _outputPort;
    private readonly IUpdateClientGateway _gateway;

    public UpdateClientInteractor(
        IClientRepository repository,
        IUpdateClientOutputPort outputPort,
        IUpdateClientGateway gateway)
    {
        _repository = repository;
        _outputPort = outputPort;
        _gateway = gateway;
    }

    public async Task Handle(UpdateClientRequest request)
    {
        try
        {
            var client = await _repository.FindByIdAsync(request.CustomerId);
            if (client is null)
            {
                await _outputPort.HandleNotFoundAsync(request.CustomerId);
                return;
            }

            bool noChanges =
                client.Email.Value == request.Email &&
                client.Phone.Value == request.Phone &&
                client.Address.Value == request.Address &&
                client.BirthDate == request.BirthDate;

            if (noChanges)
            {
                await _outputPort.HandleNoChangesAsync();
                return;
            }

            if (client.Email.Value != request.Email)
            {
                var duplicate = await _repository.FindByEmailExcludingAsync(request.Email, request.CustomerId);
                if (duplicate is not null)
                {
                    await _outputPort.HandleDuplicateEmailAsync(request.Email);
                    return;
                }
            }

            client.Update(
                request.Email,
                request.Phone,
                request.Address,
                request.BirthDate);

            await _gateway.UpdateAsync(client);

            var response = new UpdateClientResponse(
                customerId: client.Id,
                email: request.Email,
                phone: request.Phone,
                address: request.Address,
                birthDate: request.BirthDate);

            await _outputPort.HandleSuccessAsync(response);
        }
        catch (DomainException ex)
        {
            await _outputPort.HandleValidationErrorAsync(ex.Message);
        }
    }
}