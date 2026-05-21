using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.Domain.Clients.Entities;
using CommerX.Domain.Clients.Repositories;
using CommerX.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Application.Clients.UseCases;

public sealed class CreateClientUseCase : ICreateClientInputPort
{
    private readonly IClientRepository _repository;
    private readonly ICreateClientOutputPort _outputPort;

    public CreateClientUseCase(
        IClientRepository repository,
        ICreateClientOutputPort outputPort)
    {
        _repository = repository;
        _outputPort = outputPort;
    }

    public async Task ExecuteAsync(CreateClientRequest request)
    {
        try
        {
            var existing = await _repository.FindByDocumentAsync(request.Document);

            if (existing is not null)
            {
                await _outputPort.HandleDuplicateAsync(request.Document);
                return;
            }

            var client = Client.Create(
                request.FullName,
                request.LastName,
                request.Document,
                request.Email,
                request.Phone,
                request.Address,
                request.BirthDate
            );

            await _repository.AddAsync(client);

            var response = new CreateClientResponse
            {
                CustomerId = client.Id,
                FullName = request.FullName,
                LastName = request.LastName
            };

            await _outputPort.HandleSuccessAsync(response);
        }
        catch (DomainException ex)
        {
            await _outputPort.HandleValidationErrorAsync(ex.Message);
        }
    }
}