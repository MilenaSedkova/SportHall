using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Models;
using ClientService.DataAccess.PagedResults;

namespace ClientService.DataAccess.Interfaces;
public interface IClientRepository
{
    Task<Client?> GetClientByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Client>> GetAllAsync(int pageSize, int pageNumber, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Client>> GetClientByGenderAsync(int pageSize, int pageNumber, ClientGender gender, bool isTracking, CancellationToken cancellationToken);

    Task<Client> CreateClientAsync(Client client, CancellationToken cancellationToken);

    Task<bool> UpdateClientAsync(Client client, CancellationToken cancelToken);

    Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken);
}
