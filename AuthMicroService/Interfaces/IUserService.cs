using AuthMicroService.DTOs;
using AuthMicroService.Models;
using AuthMicroService.PagedResults;

namespace AuthMicroService.Interfaces
{
    public interface IUserService
    {
        public Task<UserForAdminDto?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

        public Task<UserForAdminDto?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken);

        public Task<PagedUserResult<UserForAdminDto?>> GetAllAsync(int pageNumber, int pageSize, bool isTracking, CancellationToken cancellationToken);

        public Task<bool> RegistrationAsync(RegisterDto registrationDTO, CancellationToken cancellationToken);

        public Task<bool> LoginAsync(LoginDto loginDTO, CancellationToken cancellationToken);

        public Task<bool> UpdateUserAsync(UpdateUserDto updateUser, CancellationToken cancellationToken);

        public Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> ChangePasswordAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> ActivateUserAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> DeActivateUserAsync(Guid id, CancellationToken cancellationToken);
    }
}
