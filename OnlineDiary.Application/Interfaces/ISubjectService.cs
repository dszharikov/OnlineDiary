using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ISubjectService
{
    Task<Subject> GetSubjectByIdAsync(Guid subjectId);
    Task<IEnumerable<Subject>> GetAllSubjectsAsync();
    Task CreateSubjectAsync(Subject dto);
    Task UpdateSubjectAsync(Guid subjectId, Subject dto);
    Task DeleteSubjectAsync(Guid subjectId);
}
