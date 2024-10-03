using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IClassSubjectService
{
    Task<ClassSubject> GetClassSubjectByIdAsync(Guid classId, Guid subjectId);

    Task<IEnumerable<ClassSubject>> GetSubjectsByClassIdAsync(Guid classId);

    Task AssignSubjectToClassAsync(Guid classId, Guid subjectId, Guid teacherId);

    Task RemoveSubjectFromClassAsync(Guid classId, Guid subjectId);
}
