using ClientService.Business.DTOs;
using ClientService.DataAccess.PagedResults;
using ClientService.DataAccess.Enums;

namespace ClientService.Business.Interfaces;

public interface IClientService
{ 
    Task<ClientForAdminDto?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<PagedResult<ClientForAdminDto?>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);

    Task<bool> UpdateClientAsync(UpdateClientDto updateDto, CancellationToken cancellationToken);

    Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken);

    Task<ClientForAdminDto> CreateClientAsync(CreateClientDto createClient, CancellationToken cancellationToken);

    Task<PagedResult<ClientForAdminDto?>> GetClientByGenderAsync(int pageSize, int pageNumber, ClientGender gender, CancellationToken cancellationToken);

    Task<int> CountByGenderAsync(ClientGender gender, CancellationToken cancellationToken);
}
