using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IQuarterlySubgradeRepository : IRepository<QuarterlySubgrade>
{
    Task<IEnumerable<QuarterlySubgrade>> GetByQuarterlyGradeIdAsync(Guid quarterlyGradeId);
}
