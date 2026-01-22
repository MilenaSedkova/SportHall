using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Enter the Email")]
        [EmailAddress(ErrorMessage = "Incorrect format of Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        [MinLength(6, ErrorMessage = "Minimal length of password is 6 symbols")]
        public required string PasswordHash { get; set; }

    }
}
