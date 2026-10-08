using CommerX.Domain.Clients.Entities;
using CommerX.Domain.Clients.Repositories;
using CommerX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CommerX.Infrastructure.Clients;

public sealed class ClientRepository : IClientRepository
{
    private readonly CommerXDbContext _db;

    public ClientRepository(CommerXDbContext db)
    {
        _db = db;
    }

    public async Task<Client?> FindByDocumentAsync(string document)
    {
        return await _db.Clients
            .FirstOrDefaultAsync(c => c.DocumentNumber.Value == document);
    }

    public async Task<Client?> FindByEmailExcludingAsync(string email, Guid excludeClientId)
    {
        return await _db.Clients
            .FirstOrDefaultAsync(c => c.Email.Value == email && c.Id != excludeClientId);
    }

    public async Task<Client?> FindByIdAsync(Guid clientId)
    {
        return await _db.Clients
            .FirstOrDefaultAsync(c => c.Id == clientId);
    }

    public Task<Client?> FindbyIdAsync(Guid id) => FindByIdAsync(id);

    public async Task AddAsync(Client client)
    {
        await _db.Clients.AddAsync(client);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _db.Clients.Update(client);
        await _db.SaveChangesAsync();
    }
}