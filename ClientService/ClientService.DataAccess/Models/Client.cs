using System.ComponentModel.DataAnnotations;
using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Validation;

namespace ClientService.DataAccess.Models;

public class Client
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [MaxLength(ClientConstants.MaxPhoneNumberLength)]
    [BelarusPhoneNumber(ErrorMessage = "Неверный формат номера телефона")]
    public required string PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public ClientGender Gender { get; set; }

    [MaxLength(ClientConstants.MaxNameLength)]
    public required string EmergencyContactName { get; set; }

    [MaxLength(ClientConstants.MaxPhoneNumberLength)]
    [BelarusPhoneNumber(ErrorMessage = "Неверный формат номера телефона")]
    public required string EmergencyContactPhone {  get; set; }
}

file static class ClientConstants
{
    public const int MaxNameLength = 128;
    public const int MaxPhoneNumberLength = 38;
}
