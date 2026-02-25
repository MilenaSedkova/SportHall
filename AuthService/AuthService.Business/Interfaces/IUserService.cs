using AuthService.Business.DTOs;
using System;
using System.Collections.Generic;
using AuthService.DataAccess.PagedResults;

namespace AuthService.Business.Interfaces;

public interface IUserService
{
    Task<UserForAdminDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<UserForAdminDto?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<PagedUserResult<UserForAdminDto?>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<UserForAdminDto> UpdateUserAsync(UpdateUserDto updateUser, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> ChangePasswordAsync(Guid id, string newPassword, CancellationToken cancellationToken);

    Task<bool> ActivateUserAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> DeActivateUserAsync(Guid id, CancellationToken cancellationToken);
}
