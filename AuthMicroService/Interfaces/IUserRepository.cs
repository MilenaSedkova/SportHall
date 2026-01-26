using AuthMicroService.Models;
using AuthMicroService.PagedResults;

namespace AuthMicroService.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsynс(Guid id, CancellationToken cancellationToken, bool isTracking);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken, bool isTracking);

    Task<PagedUserResult<User>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<User> CreateUserAsync(User user, CancellationToken cancellationTocken);

    Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken);

    Task<bool> EmailExistAsync(string email, CancellationToken cancellationToken);
}

