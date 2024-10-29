namespace OnlineDiary.Application.Pagination;

public interface IPaginationService
{
    Task<PaginationResponseDto<T>> PaginateAsync<T>(
        IQueryable<T> query, PaginationRequestDto paginationRequest, CancellationToken cancellationToken = default);
}