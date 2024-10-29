using Microsoft.EntityFrameworkCore;
using OnlineDiary.Application.Pagination;

namespace OnlineDiary.Infrastructure.Services;

public class PaginationService : IPaginationService
{
    public async Task<PaginationResponseDto<T>> PaginateAsync<T>(
             IQueryable<T> query, PaginationRequestDto paginationRequest, CancellationToken cancellationToken = default)
    {
        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query.Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize)
                               .Take(paginationRequest.PageSize)
                               .ToListAsync(cancellationToken);

        return new PaginationResponseDto<T>
        {
            PageNumber = paginationRequest.PageNumber,
            PageSize = paginationRequest.PageSize,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)paginationRequest.PageSize),
            Items = items
        };
    }
}