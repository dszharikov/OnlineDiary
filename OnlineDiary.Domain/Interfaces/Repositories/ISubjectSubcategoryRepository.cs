using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface ISubjectSubcategoryRepository : IRepository<SubjectSubcategory>
{
    Task<IEnumerable<SubjectSubcategory>> GetBySubjectIdAsync(Guid subjectId);
}
