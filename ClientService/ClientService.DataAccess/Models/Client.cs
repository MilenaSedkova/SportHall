using System.ComponentModel.DataAnnotations;
using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Validation;
using ClientService.DataAccess.Constants;

namespace ClientService.DataAccess.Models;

public class Client
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [MaxLength(ClientConstants.MaxPhoneNumberLength)]
    [BelarusPhoneNumber(ErrorMessage = "The number format is incorrect")]
    public required string PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public ClientGender Gender { get; set; }

    [MaxLength(ClientConstants.MaxNameLength)]
    public required string EmergencyContactName { get; set; }

    [MaxLength(ClientConstants.MaxPhoneNumberLength)]
    [BelarusPhoneNumber(ErrorMessage = "The number format is incorrect")]
    public required string EmergencyContactPhone {  get; set; }
}
