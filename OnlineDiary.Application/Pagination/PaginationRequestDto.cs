namespace OnlineDiary.Application.Pagination;

public class PaginationRequestDto
{
    public int PageNumber { get; set; } = 1;  // Номер страницы по умолчанию
    public int PageSize { get; set; } = 15;   // Размер страницы по умолчанию
}