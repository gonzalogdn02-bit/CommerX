using CommerX.Application.Clients.DTOs;
using CommerX.Application.Common.Ports;

namespace CommerX.Application.Clients.Ports;

public interface ICreateClientOutputPort : IBaseOutputPort<CreateClientResponse>
{
    Task HandleDuplicateAsync(string document);
}