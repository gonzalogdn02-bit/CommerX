using CommerX.Application.Common.Ports;
using CommerX.Application.Common.Results;
using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;

namespace CommerX.InterfaceAdapter.Clients.ViewModels;

public sealed class CreateClientViewModel : BasePresenter<CreateClientResponse>, ICreateClientOutputPort
{

    public Task HandleDuplicateAsync(string document)
    {
        _result = OperationResult<CreateClientResponse>.Fail($"El documento '{document}' ya se encuentra registrado.");
        return Task.CompletedTask;
    }
}