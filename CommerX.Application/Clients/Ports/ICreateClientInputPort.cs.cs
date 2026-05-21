using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommerX.Application.Clients.DTOs;

namespace CommerX.Application.Clients.Ports;

public interface ICreateClientInputPort
{
    Task ExecuteAsync(CreateClientRequest request);
}