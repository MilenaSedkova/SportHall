using AuthMicroService.DTOs;
using AuthMicroService.Models;
using AuthMicroService.PagedResults;

namespace AuthMicroService.Interfaces
{
    public interface IUserService
    {
        public Task<UserForAdminDTO?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

        public Task<UserForAdminDTO?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken);

        public Task<PagedUserResult<UserForAdminDTO?>> GetAllAsync(int pageNumber, int pageSize, bool isTracking, CancellationToken cancellationToken);

        public Task<bool> RegistrationAsync(RegistrationDTO registrationDTO, CancellationToken cancellationToken);

        public Task<bool> LoginAsync(LoginDTO loginDTO, CancellationToken cancellationToken);

        public Task<bool> UpdateUserAsync(UpdateUserDTO updateUser, CancellationToken cancellationToken);

        public Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> ChangePasswordAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> ActivateUserAsync(Guid id, CancellationToken cancellationToken);

        public Task<bool> DeActivateUserAsync(Guid id, CancellationToken cancellationToken);
    }
}
