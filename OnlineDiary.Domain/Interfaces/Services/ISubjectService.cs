using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface ISubjectService
{
    Task<Subject> GetSubjectByIdAsync(Guid subjectId);

    Task<IEnumerable<Subject>> GetAllSubjectsAsync();

    Task CreateSubjectAsync(Subject subject);

    Task UpdateSubjectAsync(Subject subject);

    Task DeleteSubjectAsync(Guid subjectId);
}
