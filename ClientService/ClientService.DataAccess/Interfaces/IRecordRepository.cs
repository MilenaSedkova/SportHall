using ClientService.DataAccess.Models;
using ClientService.DataAccess.PagedResults;

namespace ClientService.DataAccess.Interfaces;

public interface IRecordRepository
{
    Task<Record?> GetRecordByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetAllRecordsAsync(int pageSize, int pageNumber, bool isTracking, CancellationToken cancellationToken);

    Task<Record> CreateRecordAsync(Record record, CancellationToken cancellationToken);

    Task<bool> UpdateRecordAsync(Record record, CancellationToken cancellationToken);

    Task<bool> DeleteRecordAsync(Guid id, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetRecordsByClientIdAsync(int pageSize, int pageNumber, Guid clientId, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetRecordsByCoachIdAsync(int pageSize, int pageNumber, Guid coachId, bool isTracking, CancellationToken cancellationToken);

    Task<PagedResult<Record>> GetRecordsByDateAsync(int pageSize, int pageNumber, DateTimeOffset startDate, DateTimeOffset endDate, bool isTracking, CancellationToken cancellationToken);

    Task<bool> HasOverlappingCoachRecordAsync(Guid coachId, DateTimeOffset startDate, DateTimeOffset endTime, CancellationToken cancellationToken);

    Task<bool> HasOverlappingClientRecordAsync(Guid clientId, DateTimeOffset startDate, DateTimeOffset endTime, CancellationToken cancellationToken);
}
