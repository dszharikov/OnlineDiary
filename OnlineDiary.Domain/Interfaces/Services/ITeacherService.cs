using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface ITeacherService
{
    Task<Teacher> GetTeacherByIdAsync(Guid teacherId);

    Task<Teacher> GetTeacherByUserIdAsync(Guid userId);

    Task<IEnumerable<Teacher>> GetAllTeachersAsync();

    Task AssignSubjectToTeacherAsync(Guid teacherId, Guid subjectId);

    Task CreateTeacherAsync(Teacher teacher);

    Task UpdateTeacherAsync(Teacher teacher);

    Task DeleteTeacherAsync(Guid teacherId);
}
