using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Validation;
using System.ComponentModel.DataAnnotations;
using ClientService.DataAccess.Constants;

namespace ClientService.Business.DTOs;

public class UpdateDto
{
    public Guid Id { get; set; }

    [MaxLength(ClientConstants.MaxPhoneNumberLength, ErrorMessage = "The length of the entered phone number exceeds the maximum")]
    [BelarusPhoneNumber(ErrorMessage = "The number format is incorrect")]
    public string? PhoneNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public ClientGender? Gender { get; set; }

    [MaxLength(ClientConstants.MaxNameLength, ErrorMessage = "The length of enetered name exceeds the maximum")]
    public string? EmergencyContactName { get; set; }

    [MaxLength(ClientConstants.MaxPhoneNumberLength, ErrorMessage = "The length of entered phone number exceeds the maximum")]
    [BelarusPhoneNumber(ErrorMessage = "The number format is incorrect")]
    public string? EmergencyContactPhone { get; set; }
}
