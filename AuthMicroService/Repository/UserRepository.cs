using AuthMicroService.ContextDb;
using AuthMicroService.Interfaces;
using AuthMicroService.Models;
using AuthMicroService.PagedResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthMicroService.Repository;

public class UserRepository : IUserRepository
{
    private readonly AuthContext _context;

    public UserRepository(AuthContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken)
    {
        var query = _context.Users.AsQueryable();

        if (!isTracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken)
    {
        var query = _context.Users.AsQueryable();

        if (!isTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<PagedUserResult<User>> GetAllAsync(int pageNumder, int pageSize, bool isTracking, CancellationToken cancellationToken)
    {
        var query = _context.Users.AsQueryable();

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
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(id, cancellationToken);
        if(user == null)
        {
            return false;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Update(user);
        var changedRows = await _context.SaveChangesAsync(cancellationToken);
        return changedRows > 0;
    }

    public async Task<bool> EmailExistAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return false;
        }
        return true;
    }
}

