using AuthMicroService.DTOs;
using AuthMicroService.Models;
using AuthMicroService.PagedResults;

namespace AuthMicroService.Interfaces
{
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
}
