using AuthService.Business.DTOs;
using AuthService.DataAccess.Models;

namespace AuthService.Business.Mappers;

public static class UserPatchMapper
{
    public static void ApplyMapping(User user, UpdateUserDto updateUser)
    {
        user.Name = updateUser.Name ?? user.Name;
        user.Surname = updateUser.Surname ?? user.Surname;
        user.Email = updateUser.Email ?? user.Email;
        user.Role = updateUser.Role ?? user.Role;
        user.IsActive = updateUser.IsActive ?? user.IsActive;
    }
}
