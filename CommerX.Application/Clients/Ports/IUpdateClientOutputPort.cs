using CommerX.Application.Clients.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Application.Clients.Ports
{
    namespace CommerX.Application.Clients.Ports
    {
        public interface IUpdateClientOutputPort
        {
            UpdateClientResponse Response { get; }
            Task HandleSuccessAsync(UpdateClientResponse response);
            Task HandleNotFoundAsync(Guid clientId);
            Task HandleDuplicateEmailAsync(string email);
            Task HandleNoChangesAsync();
            Task HandleValidationErrorAsync(string message);
            Task handlesuccessAsync(UpdateClientResponse response);
        }
    }
}
