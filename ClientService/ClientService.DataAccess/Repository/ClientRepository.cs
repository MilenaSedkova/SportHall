using ClientService.DataAccess.ContextDb;
using ClientService.DataAccess.Interfaces;
using ClientService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using ClientService.DataAccess.PagedResults;
using ClientService.DataAccess.Enums;

namespace ClientService.DataAccess.Repository;

public class ClientRepository(ClientContext clientSet) : IClientRepository
{
    public async Task<Client?> GetClientByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken)
    {
        var query = isTracking ? clientSet.Clients.AsQueryable() : clientSet.Clients.AsNoTracking();

        return await query.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
    
    public async Task<PagedResult<Client>> GetAllAsync(int pageSize, int pageNumber, bool isTracking, CancellationToken cancellationToken)
    {
        var query = isTracking ? clientSet.Clients.AsQueryable() : clientSet.Clients.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize) 
            .ToListAsync();

        return new PagedResult<Client>(items, pageSize, pageNumber, totalCount);
    }

    public async Task<PagedResult<Client>> GetClientByGenderAsync(int pageSize, int pageNumber, ClientGender gender, bool isTracking, CancellationToken cancellationToken)
    {
        var query = isTracking ? clientSet.Clients.AsQueryable() : clientSet.Clients.AsNoTracking();

        query = query.Where(c => c.Gender == gender);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Client>(items, pageSize, pageNumber, totalCount);
    }

    public async Task<Client> CreateClientAsync(Client client, CancellationToken cancellationToken)
    {
        await clientSet.Clients.AddAsync(client);
        await clientSet.SaveChangesAsync();

        return client;
    }

    public async Task<bool> UpdateClientAsync(Client client, CancellationToken cancellationToken)
    {
        clientSet.Clients.Update(client);
        var changedRows = await clientSet.SaveChangesAsync();

        return changedRows > 0;
    }

    public async Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken)
    {
        var client = await clientSet.Clients.FirstOrDefaultAsync(c => c.Id == id);

        if(client is null)
        {
            return false;
        }

        clientSet.Clients.Remove(client);

        return await clientSet.SaveChangesAsync(cancellationToken) > 0;
    }
}
