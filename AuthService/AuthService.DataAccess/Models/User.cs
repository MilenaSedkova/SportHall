using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.DataAccess.Enums; 

namespace AuthService.DataAccess.Models;

public class User
{
    [Key]
     public Guid Id { get; set; }

     [MaxLength(UserEntityConstants.MaxNameLength)]
     public required string Name { get; set; }

     [MaxLength(UserEntityConstants.MaxSurnameLength)]
     public string? Surname { get; set; }

     [MaxLength(UserEntityConstants.MaxEmailLength)]
     public required string Email { get; set; }

     public required string PasswordHash { get; set; }

     public UserRole Role { get; set; }

     public bool IsActive { get; set; } = true;

     public DateOnly RegistratedAt { get; set; }
}
