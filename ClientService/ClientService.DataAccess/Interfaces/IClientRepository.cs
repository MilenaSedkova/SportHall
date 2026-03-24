using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Models;
using ClientService.DataAccess.PagedResults;

namespace ClientService.DataAccess.Interfaces;
public interface IClientRepository
{
    Task<Client?> GetClientById(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<Client?> GetClientByUserIdAsync(Guid userId, bool isTracking, CancellationToken cancellationToken);

    Task<Client?> GetClientByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Client>> GetAllAsync(int pageSize, int pageNumber, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Client>> GetClientByGenderAsync(int pageSize, int pageNumber, ClientGender gender, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Client>> GetClientByPhoneNumberAsync(int pageSize, int pageNumber, string phoneNumber, bool isTracking, CancellationToken cancellationToken);

    Task<Client> CreateClientAsync(Client client, CancellationToken cancellationToken);

    Task<Client> UpdateClientAsync(Client client, CancellationToken cancelToken);

    Task<Client> DeleteClientAsync(Guid id, CancellationToken cancellationToken);
}
