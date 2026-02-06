using AuthService.DataAccess.ContextDb;
using AuthService.DataAccess.Interfaces;
using AuthService.DataAccess.Models;
using AuthService.DataAccess.PagedResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.DataAccess.Repository;

public class UserRepository(AuthContext userSet) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken)
    {
        var query = isTracking ? userSet.Users.AsQueryable() : userSet.Users.AsNoTracking();

        return await query.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken)
    {
        var query = userSet.Users.AsQueryable();

        if (!isTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<PagedUserResult<User>> GetAllAsync(int pageNumder, int pageSize, bool isTracking, CancellationToken cancellationToken)
    {
        var query = userSet.Users.AsQueryable();

        if (!isTracking)
        {
            query = query.AsNoTracking();
        }
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(u => u.Id)
            .Skip((pageNumder - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedUserResult<User>(items, totalCount, pageNumder, pageSize);
    }

    public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        await userSet.Users.AddAsync(user, cancellationToken);
        await userSet.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userSet.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
        {
            return false;
        }
        userSet.Users.Remove(user);
        return await userSet.SaveChangesAsync(cancellationToken) > 0;
    }
    public async Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        userSet.Users.Update(user);
        var changedRows = await userSet.SaveChangesAsync(cancellationToken);
        return changedRows > 0;
    }
}


