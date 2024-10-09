using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IClassSubjectService
{
    Task<ClassSubject> GetClassSubjectByIdAsync(Guid classSubjectId);
    Task<IEnumerable<ClassSubject>> GetAllClassSubjectsAsync();
    Task<IEnumerable<ClassSubject>> GetClassSubjectsBySubjectIdAsync(Guid subjectId);
    Task<IEnumerable<ClassSubject>> GetClassSubjectsByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<ClassSubject>> GetClassSubjectsByClassIdAsync(Guid classId);
    Task CreateClassSubjectAsync(ClassSubject dto);
    Task UpdateClassSubjectAsync(Guid classSubjectId, ClassSubject dto);
    Task DeleteClassSubjectAsync(Guid classSubjectId);
}
