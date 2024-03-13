using System.Text.Json;

namespace OpenMHWorld.API.Responses;

public record PaginatedResponse
{
    public PaginatedResponse(CustomResponse response, long? total, int currentPage, int pageSize)
    {
        Response = response;
        Total = total;
        TotalPages = (total + pageSize - 1) / pageSize;
        CurrentPage = currentPage;
        PageSize = pageSize;
        HasNext = (currentPage * pageSize) < total;
        HasPrevious = currentPage > 1 && currentPage < TotalPages;
    }

    public long? Total { get; init; }
    public long? TotalPages { get; init; }
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }
    public CustomResponse Response { get; init; }
    public bool HasNext { get; init; }
    public bool HasPrevious { get; init; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(new
        {
            Total,
            TotalPages,
            CurrentPage,
            PageSize,
            HasPrevious,
            HasNext
        });
    }
}
