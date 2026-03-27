using ClientService.Business.DTOs;
using ClientService.Business.Exceptions;
using ClientService.Business.Interfaces;
using ClientService.Business.Mappers;
using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Interfaces;
using ClientService.DataAccess.PagedResults;
using ClientService.DataAccess.Models;

namespace ClientService.Business.Services;

public class CllientService(IClientRepository clientRepository): IClientService
{
    public async Task<ClientForAdminDto?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetClientByIdAsync(id, isTracking: false, cancellationToken);
        return client is null
            ? throw new NotFoundException($"User with id: {id} not found")
            : ClientMapper.MapToAdminDto(client);
    }

    public async Task<PagedResult<ClientForAdminDto?>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = await clientRepository.GetAllAsync(pageSize, pageNumber, isTracking: false, cancellationToken);

        return MapToAdminPaged(result);
    }

    public async Task<PagedResult<ClientForAdminDto?>> GetClientByGenderAsync(int pageSize, int pageNumber, ClientGender clientGender, CancellationToken cancellationToken)
    {
        var result = await clientRepository.GetClientByGenderAsync(pageSize, pageNumber, clientGender, isTracking: false, cancellationToken);

        return MapToAdminPaged(result);
    }

    public async Task<bool> UpdateClientAsync(UpdateDto updateDto, CancellationToken cancellationToken)
    {
        var user = await clientRepository.GetClientByIdAsync(updateDto.Id, isTracking: true, cancellationToken)
            ?? throw new NotFoundException($"Client with id: {updateDto.Id} not found");

        PatchMapper.ApplyMapper(user, updateDto);

        await clientRepository.UpdateClientAsync(user, cancellationToken);  

        return true;
    }

    public async Task<bool> DeleteClientAsync(Guid guid, CancellationToken cancellationToken)
    {
        var result = await clientRepository.DeleteClientAsync(guid, cancellationToken);

        return result;
    }

    public async Task<ClientForAdminDto> CreateClientAsync(CreateClientDto createDto, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Id = Guid.NewGuid(),
            PhoneNumber = createDto.PhoneNumber,
            BirthDate = createDto.BirthDate,
            Gender = createDto.Gender,
            EmergencyContactName = createDto.EmergencyContactName,
            EmergencyContactPhone = createDto.EmergencyContactPhone
        };

        var createdClient = await clientRepository.CreateClientAsync(client, cancellationToken);

        return ClientMapper.MapToAdminDto(createdClient);
    }

    public async Task<int> CountByGenderAsync(ClientGender clientGender, CancellationToken cancellationToken)
    {
        return await clientRepository.CountByGenderAsync(clientGender, cancellationToken);
    }

    private PagedResult<ClientForAdminDto?> MapToAdminPaged(PagedResult<Client> result)
    {
        return new PagedResult<ClientForAdminDto?>(
            result.Items.Select(ClientMapper.MapToAdminDto),
            result.pageSize,
            result.pageNumber,
            result.TotalCount
            );
    }
}
