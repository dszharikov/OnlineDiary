using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IClassSubjectRepository : IRepository<ClassSubject>
{
    Task<IEnumerable<ClassSubject>> GetByClassIdAsync(Guid classId);
    Task<IEnumerable<ClassSubject>> GetBySubjectIdAsync(Guid subjectId);
    Task<IEnumerable<ClassSubject>> GetByTeacherIdAsync(Guid subjectId);
    Task<ClassSubject> GetByClassAndSubjectAsync(Guid classId, Guid subjectId);
}
