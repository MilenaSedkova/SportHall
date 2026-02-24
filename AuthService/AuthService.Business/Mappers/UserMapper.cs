using AuthService.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.DataAccess.Models;

namespace AuthService.Business.Mappers;

public static class UserMapper
{
    public static UserForAdminDto MapToAdminDto(User user)
    {
        return new UserForAdminDto(
            user.Id,
            user.Name,
            user.Surname,
            user.Email,
            user.Role,
            user.IsActive,
            user.RegistratedAt
            );
    }
}