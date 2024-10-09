using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IQuarterlySubgradeService
{
    Task<QuarterlySubgrade> GetQuarterlySubgradeByIdAsync(Guid quarterlySubgradeId);
    Task<IEnumerable<QuarterlySubgrade>> GetQuarterlySubgradesByTermClassSubjectSubcategoryAsync
        (Guid termId, Guid classSubjectId, Guid subcategoryId);
    Task<IEnumerable<QuarterlySubgrade>> GetQuarterlySubgradesByTermStudentClassSubjectAsync
        (Guid termId, Guid studentId, Guid classSubjectId);

    Task<IEnumerable<QuarterlySubgrade>> GetQuarterlySubgradesByTermClassSubjectIdAsync
        (Guid termId, Guid classSubjectId);
    Task CreateQuarterlySubgradeAsync(QuarterlySubgrade quarterlySubgrade);

    Task UpdateQuarterlySubgradeAsync(Guid quarterlySubgradeId, QuarterlySubgrade quarterlySubgrade);

    Task DeleteQuarterlySubgradeAsync(Guid quarterlySubgradeId);
}
