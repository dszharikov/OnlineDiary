using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IClassLevelSubjectService
{
    Task<ClassLevelSubject> GetClassLevelSubjectByIdAsync(Guid classLevelSubjectId);
    Task<IEnumerable<ClassLevelSubject>> GetAllClassLevelSubjectsAsync();
    Task<IEnumerable<ClassLevelSubject>> GetClassLevelSubjectsByClassLevelAsync(int classLevel);
    Task CreateClassLevelSubjectAsync(ClassLevelSubject dto);
    Task UpdateClassLevelSubjectAsync(Guid classLevelSubjectId, ClassLevelSubject dto);
    Task DeleteClassLevelSubjectAsync(Guid classLevelSubjectId);
}
