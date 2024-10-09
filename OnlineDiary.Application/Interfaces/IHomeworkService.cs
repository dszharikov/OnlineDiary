using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IHomeworkService
{
    Task<Homework> GetHomeworkByIdAsync(Guid homeworkId);
    Task<IEnumerable<Homework>> GetAllHomeworksAsync();
    Task<IEnumerable<Homework>> GetActualHomeworksByStudentIdAsync(Guid studentId);
    Task CreateHomeworkAsync(Homework dto);
    Task UpdateHomeworkAsync(Guid homeworkId, Homework dto);
    Task DeleteHomeworkAsync(Guid homeworkId);
}