using AuthMicroService.Enums;
using AuthMicroService.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }

        [MaxLength(UserEntityConstants.MaxNameLength)]    
        public string? Name { get; set; }

        [MaxLength(UserEntityConstants.MaxSurnameLength)]
        public string? Surname { get; set; }

        [MaxLength(UserEntityConstants.MaxEmailLength)]
        [EmailAddress(ErrorMessage = "Email has incorrect format")]
        public string? Email { get; set; }

        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid role")]
        public UserRole? Role { get; set; }

        public bool? IsActive { get; set; }
    }
}
