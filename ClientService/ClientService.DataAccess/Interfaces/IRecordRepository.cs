using ClientService.DataAccess.Models;
using ClientService.DataAccess.PagedResults;

namespace ClientService.DataAccess.Interfaces;

public interface IRecordRepository
{
    Task<Record?> GetRecordByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetAllRecordsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);

    Task<Record> CreateRecordAsync(Record record, CancellationToken cancellationToken);

    Task<Coach> UpdateRecordAsync(Record record, CancellationToken cancellationToken);

    Task<bool> DeleteRecordAsync(Guid id, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetRecordsByClientIdAsync(int pageSize, int pageNumber, Guid clientId, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetRecordsByCoachIdAsync(int pageSize, int pageNumber, Guid coachId, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetRecordsByDateAsync(int pageSize, int pageNumber, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken);

    Task<bool> HasOverlappingCoachRecordAsync(Guid coachId, DateTimeOffset startDate, DateTimeOffset endTime, CancellationToken cancellationToken);

    Task<bool> HasOverlappingClientRecordAsync(Guid clientId, DateTimeOffset startDate, DateTimeOffset endTime, CancellationToken cancellationToken);
}
