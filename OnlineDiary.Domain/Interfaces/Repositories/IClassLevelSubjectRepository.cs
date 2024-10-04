using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IClassLevelSubjectRepository : IRepository<ClassLevelSubject>
{
    Task<IEnumerable<ClassLevelSubject>> GetByClassLevelIdAsync(int classLevel);

    Task<ClassLevelSubject> GetByClassLevelAndSubjectAsync(int classLevel, Guid subjectId);

}
