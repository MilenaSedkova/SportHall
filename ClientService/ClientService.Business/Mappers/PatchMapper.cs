using ClientService.DataAccess.Models;
using ClientService.Business.DTOs;

namespace ClientService.Business.Mappers;

public static class PatchMapper
{
    public static void ApplyMapper(Client client, UpdateDto update)
    {
        client.PhoneNumber = update.PhoneNumber ?? client.PhoneNumber;
        client.BirthDate = update.BirthDate ?? client.BirthDate;
        client.Gender = update.Gender ?? client.Gender;
        client.EmergencyContactPhone = update.EmergencyContactPhone ?? client.EmergencyContactPhone;
        client.EmergencyContactName = update.EmergencyContactName ?? client.EmergencyContactName;
    }
}
