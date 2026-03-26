using ClientService.Business.DTOs;
using ClientService.DataAccess.PagedResults;
using ClientService.DataAccess.Enums;

namespace ClientService.Business.Interfaces;

public interface IClientService
{ 
    Task<ClientForAdminDto?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<PagedResult<ClientForAdminDto?>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<bool> UpdateClientAsync(UpdateDto updateDto, CancellationToken cancellationToken);

    Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken);

    Task<CreateClientDto> CreateClientAsync(CreateClientDto createClient, CancellationToken cancellationToken);

    Task<PagedResult<ClientForAdminDto?>> GetClientByGender(int pageSize, int pageNumber, ClientGender gender, bool isTracking, CancellationToken cancellationToken);

    Task<int?> CountByGenderAsync(ClientGender gender, CancellationToken cancellationToken);
}
