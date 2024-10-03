using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IClassLevelSubjectService
{
    Task<ClassLevelSubject> GetClassLevelSubjectByIdAsync(Guid classLevelId, Guid subjectId);

    Task<IEnumerable<ClassLevelSubject>> GetSubjectsByClassLevelIdAsync(Guid classLevelId);

    Task AddSubjectToClassLevelAsync(Guid classLevelId, Guid subjectId);

    Task RemoveSubjectFromClassLevelAsync(Guid classLevelId, Guid subjectId);
}
