using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.Application.Common.Results;

namespace CommerX.InterfaceAdapter.Clients.Common.Presenter;

public sealed class CreateClientPresenter : BasePresenter<CreateClientResponse>, ICreateClientOutputPort
{
    public CreateClientResponse Response => _result?.Value ?? default!;

    public Task HandleDuplicateAsync(string document)
    {
        _result = OperationResult<CreateClientResponse>.Fail($"El documento '{document}' ya se encuentra registrado.");
        return Task.CompletedTask;
    }

    public Task HandleDuplicateEmailAsync(string email)
    {
        _result = OperationResult<CreateClientResponse>.Fail($"El email '{email}' ya se encuentra registrado.");
        return Task.CompletedTask;
    }
}