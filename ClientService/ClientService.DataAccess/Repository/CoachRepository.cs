using ClientService.DataAccess.ContextDb;
using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Interfaces;
using ClientService.DataAccess.Models;
using ClientService.DataAccess.PagedResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClientService.DataAccess.Repository;


public class CoachRepository(SportHallContext coachSet) : ICoachRepository
{
    public async Task<Coach?> GetCoachByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken)
    {
        var query = isTracking ? coachSet.Coaches.AsQueryable() : coachSet.Coaches.AsNoTracking();

        return await query.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<PagedResult<Coach>> GetAllCoachesAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var query = coachSet.Coaches.AsNoTracking();

        var totaCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Coach>(items, pageSize, pageNumber, totaCount);
    }

    public async Task<PagedResult<Coach>> GetCoachesBySpecializationAsync(int pageSize, int pageNumber, CoachSpecialization specialization, CancellationToken cancellationToken)
    {
        var query = coachSet.Coaches.AsNoTracking();

        query = query.Where(c => c.Specialization == specialization);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(q => q.Specialization)
            .ThenBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Coach>(items, pageSize, pageNumber, totalCount);
    }

    public async Task<Coach> CreateCoachAsync(Coach coach, CancellationToken cancellationToken)
    {
        await coachSet.Coaches.AddAsync(coach, cancellationToken);
        await coachSet.SaveChangesAsync(cancellationToken);

        return coach;
    }

    public async Task<Coach> UpdateCoachAsync(Coach coach, CancellationToken cancellationToken)
    {
        coachSet.Coaches.Update(coach);
        await coachSet.SaveChangesAsync(cancellationToken);

        return coach;
    }

    public async Task<bool> DeleteCoachAsync(Guid id, CancellationToken cancellationToken)
    {
        var affectedRows = await coachSet.Coaches
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }

    public async Task<int> GetCountOfSpecializationAsync(CoachSpecialization coachSpecialization, CancellationToken cancellationToken)
    {
        return await coachSet.Coaches
            .CountAsync(c => c.Specialization == coachSpecialization, cancellationToken);
    }

    public async Task<PagedResult<Coach>> SearchCoachByNameAsync(int pageSize, int pageNumber, string name, CancellationToken cancellationToken)
    {
        var query = coachSet.Coaches.AsNoTracking();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(c => c.Name.Contains(name));   
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(c => c.Name)
            .ThenBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Coach>(items, pageSize, pageNumber, totalCount);
    }
}
