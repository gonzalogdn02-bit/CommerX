using CommerX.Domain.Clients.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Application.Clients.Ports;

public interface IUpdateClientGateway
{
    Task UpdateAsync(Client client);
} 