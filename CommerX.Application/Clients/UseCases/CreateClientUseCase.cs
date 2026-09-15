using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.Application.Common.Validation;
using CommerX.Domain.Clients.Entities;
using CommerX.Domain.Clients.Repositories;
using CommerX.Domain.Common.Exceptions;

namespace CommerX.Application.Clients.UseCases;

public sealed class CreateClientUseCase : ICreateClientInputPort
{
    private readonly IClientRepository _repository;
    private readonly ICreateClientOutputPort _outputPort;
    private readonly IModelValidatorHub<CreateClientRequest> _validator;

    public CreateClientUseCase(
        IClientRepository repository,
        ICreateClientOutputPort outputPort,
        IModelValidatorHub<CreateClientRequest> validator)
    {
        _repository = repository;
        _outputPort = outputPort;
        _validator = validator;
    }

    public async Task ExecuteAsync(CreateClientRequest request)
    {
        // Validación de precondiciones técnicas con Guards
        var errors = _validator.Validate(request).ToList();
        if (errors.Count > 0)
        {
            await _outputPort.ValidationErrorsAsync(errors);
            return;
        }

        try
        {
            // Verificación de unicidad
            var existing = await _repository.FindByDocumentAsync(request.Document);
            if (existing is not null)
            {
                await _outputPort.HandleDuplicateAsync(request.Document);
                return;
            }

            //Dominio (aplica invariantes de negocio)
            var client = Client.Create(
                request.FirstName,
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
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _outputPort.HandleSuccessAsync(response);
        }
        catch (DomainException ex)
        {
            await _outputPort.HandleErrorAsync(ex.Message);
        }
    }
}