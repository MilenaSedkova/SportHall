using ClientService.DataAccess.Constants;
using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Validation;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Business.DTOs;

public class CreateClientDto
{
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Enter the phone number")]
    [MaxLength(ClientConstants.MaxPhoneNumberLength, ErrorMessage = "The length of the entered phone number exceeds the maximum")]
    [BelarusPhoneNumber(ErrorMessage = "The number format is incorrect")]
    public required string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Enter yout birthday")]
    public DateOnly BirthDate { get; set; }

    [Required(ErrorMessage = "Enter your gender")]
    public ClientGender Gender { get; set; }

    [Required(ErrorMessage = "Enter an emergency contact name")]
    [MaxLength(ClientConstants.MaxNameLength, ErrorMessage = "The length of enetered name exceeds the maximum")]
    public required string EmergencyContactName { get; set; }

    [Required(ErrorMessage = "Enter an emergency contact phone")]
    [MaxLength(ClientConstants.MaxPhoneNumberLength, ErrorMessage = "The length of entered phone number exceeds the maximum")]
    [BelarusPhoneNumber(ErrorMessage = "The number format is incorrect")]
    public required string EmergencyContactPhone { get; set; }
}
