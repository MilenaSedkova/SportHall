namespace ClientService.DataAccess.PagedResults;

public record PagedClientResult<T>(
    IEnumerable<T> Items,
    int pageSize, 
    int pageNumber,
    int TotalCount
    );
