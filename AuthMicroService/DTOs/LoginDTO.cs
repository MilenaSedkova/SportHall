using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Enter the Email")]
        [EmailAddress(ErrorMessage = "Incorrect format of Email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Enter the password")]
        [MinLength(6, ErrorMessage = "Minimal length of password is 6 symbols")]
        public string Password { get; set; } = null!;
    }
}
