namespace ClientService.DataAccess.PagedResults;

public record PagedResult<T>(
    IEnumerable<T> Items,
    int pageSize, 
    int pageNumber,
    int TotalCount
    );
