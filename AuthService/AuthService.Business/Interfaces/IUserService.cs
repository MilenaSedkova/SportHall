using AuthService.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.DataAccess.PagedResults;

namespace AuthService.Business.Interfaces;

public interface IUserService
{
    Task<UserForAdminDto?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<UserForAdminDto?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken);

    Task<PagedUserResult<UserForAdminDto?>> GetAllAsync(int pageNumber, int pageSize, bool isTracking, CancellationToken cancellationToken);

    Task<bool> RegisterAsync(RegisterDto registrationDTO, CancellationToken cancellationToken);

    Task<LoginResultDto> LoginAsync(LoginDto loginDTO, CancellationToken cancellationToken);

    Task<UserForAdminDto> UpdateUserAsync(UpdateUserDto updateUser, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> ChangePasswordAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> ActivateUserAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> DeActivateUserAsync(Guid id, CancellationToken cancellationToken);
}

