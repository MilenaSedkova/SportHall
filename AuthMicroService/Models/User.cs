using AuthMicroService.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthMicroService.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateOnly RegistratedAt { get; set; }
    }
}
