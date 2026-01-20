using AuthMicroService.Enums;
using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Enter user name")]
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Enter the Email")]
        [EmailAddress(ErrorMessage = "Email has incorrect format")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Enter the password")]
        [MinLength(6, ErrorMessage = "Minimal length of password is 6 symbols")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Enter the role")]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid role")]
        public UserRole Role { get; set; }
    }
}
