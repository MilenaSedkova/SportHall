using System.ComponentModel.DataAnnotations;

namespace AuthService.API.RequestModels;

public class ChangePasswordRequest
{
    [Required]
    [MinLength(6)]
    public required string NewPassword { get; set; }
}
