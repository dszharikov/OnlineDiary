using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ITermService
{
    Task<Term> GetTermByIdAsync(Guid termId);
    Task<IEnumerable<Term>> GetAllTermsAsync();
    Task CreateTermAsync(Term dto);
    Task UpdateTermAsync(Guid termId, Term dto);
    Task DeleteTermAsync(Guid termId);
}
