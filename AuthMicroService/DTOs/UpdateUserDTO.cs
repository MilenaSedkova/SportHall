using AuthMicroService.Enums;
using AuthMicroService.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }

        [MaxLength(UserEntityConstants.MaxNameLength)]
        public string? Name { get; set; }

        [MaxLength(UserEntityConstants.MaxSurnameLength)]
        public string? Surname { get; set; }

        [MaxLength(UserEntityConstants.MaxEmailLength)]
        public string? Email { get; set; }

        public UserRole? Role { get; set; }

        public bool? IsActive { get; set; }
    }
}
