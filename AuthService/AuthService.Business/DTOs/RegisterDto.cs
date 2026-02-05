using AuthService.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.DTOs;

public class RegisterDto
{
    [Required(ErrorMessage = "Enter user name")]
    public required string Name { get; set; }

    public string? Surname { get; set; }

    [Required(ErrorMessage = "Enter the Email")]
    [EmailAddress(ErrorMessage = "Email has incorrect format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Enter the password")]
    public required string PasswordHash { get; set; }

    [Required(ErrorMessage = "Enter the role")]
    [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid role")]
    public UserRole Role { get; set; }
}
