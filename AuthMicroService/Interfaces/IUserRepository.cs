using AuthMicroService.Models;

namespace AuthMicroService.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsyn(Guid id);

        Task<User?> GetByEmailAsync(string email);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> CreateUserAsync(User user);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(Guid id);

        Task<bool> EmailExistAsync(string email);

    }
}
