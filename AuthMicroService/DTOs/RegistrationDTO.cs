using AuthMicroService.Enums;
using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Enter user name")]

        public required string Name { get; set; }

        public string? Surname { get; set; }

        [Required(ErrorMessage = "Enter the Email")]

        [EmailAddress(ErrorMessage = "Email has incorrect format")]

        public required string Email { get; set; }

        [Required(ErrorMessage = "Enter the password")]

        [MinLength(6, ErrorMessage = "Minimal length of password is 6 symbols")]

        public required string PasswordHash { get; set; }

        [Required(ErrorMessage = "Enter the role")]

        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid role")]

        public UserRole Role { get; set; }
    }
}
