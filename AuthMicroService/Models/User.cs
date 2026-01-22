using AuthMicroService.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthMicroService.Models
{
    public class User
    {
        [Key]

        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Surname { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public bool IsActive { get; set; } = true;

        public DateOnly RegistratedAt { get; set; }
    }
}
