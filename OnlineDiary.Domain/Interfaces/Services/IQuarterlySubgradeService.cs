using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IQuarterlySubgradeService
{
    Task<QuarterlySubgrade> GetQuarterlySubgradeByIdAsync(Guid quarterlySubgradeId);

    Task<IEnumerable<QuarterlySubgrade>> GetSubgradesByQuarterlyGradeIdAsync(Guid quarterlyGradeId);

    Task CreateQuarterlySubgradeAsync(QuarterlySubgrade quarterlySubgrade);

    Task UpdateQuarterlySubgradeAsync(QuarterlySubgrade quarterlySubgrade);

    Task DeleteQuarterlySubgradeAsync(Guid quarterlySubgradeId);
}
