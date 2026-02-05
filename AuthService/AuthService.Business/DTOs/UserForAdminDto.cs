using AuthService.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.DTOs;

public record UserForAdminDto(
     Guid Id,
     string Name,
     string? Surname,
     string Email,
     UserRole Role,
     bool IsActive,
     DateOnly RegistratedAt
);

