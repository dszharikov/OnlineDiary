using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IQuarterlySubgradeRepository : IRepository<QuarterlySubgrade>
{
    Task<QuarterlySubgrade> GetByTermStudentSubcategoryAsync
        (Guid termId, Guid StudentId, Guid SubcategoryId);
    Task<IEnumerable<QuarterlySubgrade>> GetByTermStudentClassSubjectAsync
        (Guid termId, Guid classSubjectId, Guid subcategoryId);
    Task<IEnumerable<QuarterlySubgrade>> GetByTermStudentClassSubjectIdAsync
        (Guid termId, Guid studentId, Guid classSubjectId);

    Task<IEnumerable<QuarterlySubgrade>> GetByTermClassSubjectIdAsync
        (Guid termId, Guid classSubjectId);
}
