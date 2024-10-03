using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IClassLevelSubjectRepository : IRepository<ClassLevelSubject>
{
    Task<IEnumerable<ClassLevelSubject>> GetByClassLevelIdAsync(Guid classLevelId);

    Task<ClassLevelSubject> GetByClassLevelAndSubjectAsync(Guid classLevelId, Guid subjectId);

}
