using ClientService.DataAccess.Enums;
using ClientService.DataAccess.Models;
using ClientService.DataAccess.PagedResults; 

namespace ClientService.DataAccess.Interfaces;

public interface ICoachRepository
{
    Task<Coach?> GetCoachByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Coach>> GetAllCoachesAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);

    Task<PagedResult<Coach>> GetCoachesBySpecializationAsync(int pageSize, int pageNumber, CoachSpecialization specialization, CancellationToken cancellationToken);

    Task<Coach> CreateCoachAsync(Coach coach, CancellationToken cancellationToken);

    Task<Coach> UpdateCoachAsync(Coach coach, CancellationToken cancellationToken);

    Task<bool> DeleteCoachAsync(Guid coachId, CancellationToken cancellationToken);

    Task<int> GetCountOfSpecializationAsync(CoachSpecialization coachSpecialization, CancellationToken cancellationToken);

    Task<PagedResult<Coach>> SearchCoachByNameAsync(int pageSize, int pageNumber,  string name, CancellationToken cancellationToken);
}
