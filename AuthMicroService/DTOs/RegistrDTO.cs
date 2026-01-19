using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class RegistrDTO
    {
        [Required(ErrorMessage = "Enter user name")]
        public string Name { get; set; } = null!;

        public string? Surname { get; set; }

        [Required(ErrorMessage = "Enter the Email")]
        [EmailAddress(ErrorMessage = "Email has uncorrect format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Enter the password")]
        [MinLength(6, ErrorMessage = "Minimal length of password is 6 symbols")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Enter the role")]
        public string Role { get; set; } = null!;

    }
}
