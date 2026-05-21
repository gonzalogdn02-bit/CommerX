using CommerX.Domain.Clients.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Domain.Clients.Repositories;

public interface IClientRepository
{
    Task<Client?> FindByDocumentAsync(string document);
    Task AddAsync(Client client);
}