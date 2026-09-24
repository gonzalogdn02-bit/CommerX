using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.Application.Common.Results;
using CommerX.InterfaceAdapter.Common.Presenter;

namespace CommerX.InterfaceAdapter.Clients.ViewModels;

public sealed class CreateClientViewModel : BasePresenter<CreateClientResponse>, ICreateClientOutputPort
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