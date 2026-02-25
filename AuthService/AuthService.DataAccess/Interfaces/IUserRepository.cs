using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.DataAccess.Models;
using AuthService.DataAccess.PagedResults;

namespace AuthService.DataAccess.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken);

    Task<PagedUserResult<User>> GetAllAsync(int pageNumber, int pageSize, bool isTracking, CancellationToken cancellationToken);

    Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);

    Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken);
}
