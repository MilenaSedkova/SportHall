using System.ComponentModel.DataAnnotations;
using ClientService.DataAccess.Enums;

namespace ClientService.DataAccess.Models;
public class ClientModel
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [MaxLength(ClientEntityConstants.MaxPhoneNumberLength)]
    public required string PhoneNumber { get; set; }

    public DateOnly BirhDate { get; set; }

    public ClientGender Gender { get; set; }

    [MaxLength(ClientEntityConstants.MaxNameLength)]
    public required string EmergencyContactName { get; set; }

    [MaxLength(ClientEntityConstants.MaxPhoneNumberLength)]
    public required string EmergencyContactPhone {  get; set; }
}
