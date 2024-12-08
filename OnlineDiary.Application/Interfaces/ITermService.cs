using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ITermService
{
    Task<Term> GetTermByIdAsync(Guid termId);
    Task<PaginationResponseDto<Term>> GetTermsAsync(PaginationRequestDto paginationRequest);
    Task CreateTermAsync(Term dto);
    Task UpdateTermAsync(Guid termId, Term dto);
    Task DeleteTermAsync(Guid termId);
}
