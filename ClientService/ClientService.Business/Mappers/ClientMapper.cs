using ClientService.Business.DTOs;
using ClientService.DataAccess.Models;

namespace ClientService.Business.Mappers;

public static class ClientMapper
{
    public static ClientForAdminDto MapToAdminDto(Client client)
    {
        return new ClientForAdminDto(
            client.Id,
            client.PhoneNumber,
            client.BirthDate,
            client.Gender,
            client.EmergencyContactPhone,
            client.EmergencyContactName
            );
    }
}
