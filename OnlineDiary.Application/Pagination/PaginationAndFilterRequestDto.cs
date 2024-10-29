namespace OnlineDiary.Application.Pagination;

public class PaginationAndFilterRequestDto<TFilter>
{
    public PaginationRequestDto Pagination { get; set; }
    public TFilter Filter { get; set; }
}