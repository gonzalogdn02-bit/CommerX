using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommerX.Application.Clients.DTOs;

namespace CommerX.Application.Clients.Ports;

public interface ICreateClientOutputPort
{
    Task HandleSuccessAsync(CreateClientResponse response);
    Task HandleDuplicateAsync(string document);
    Task HandleValidationErrorAsync(string message);
}