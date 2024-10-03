using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface ITermService
{
    Task<Term> GetTermByIdAsync(Guid termId);

    Task<IEnumerable<Term>> GetTermsBySchoolIdAsync(Guid schoolId);

    Task CreateTermAsync(Term term);

    Task UpdateTermAsync(Term term);

    Task DeleteTermAsync(Guid termId);
}
