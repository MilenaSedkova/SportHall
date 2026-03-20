using ClientService.DataAccess.Enums;

namespace ClientService.Business.DTOs;

public record ClientForAdminDto(
    Guid Id,
    string PhoneNumber,
    DateOnly BirthDate,
    ClientGender Gender,
    string EmergencyContactName,
    string EmergencyContactPhone
);
