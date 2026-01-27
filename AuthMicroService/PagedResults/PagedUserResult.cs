namespace AuthMicroService.PagedResults;

public record PagedUserResult<T>(
    IEnumerable<T> Items,

    int TotalCount,

    int PageNumber,

    int PageSize
);

