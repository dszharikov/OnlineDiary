using OnlineDiary.Application.Filters.Subjects;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ISubjectService
{
    Task<Subject> GetSubjectByIdAsync(Guid subjectId);
    Task<PaginationResponseDto<Subject>> GetSubjectsAsync(
        PaginationAndFilterRequestDto<SubjectFilterRequestDto> paginationAndFilterRequest);
    Task<IEnumerable<Subject>> GetAllSubjectsAsync();
    Task CreateSubjectAsync(Subject dto);
    Task UpdateSubjectAsync(Guid subjectId, Subject dto);
    Task DeleteSubjectAsync(Guid subjectId);
}
