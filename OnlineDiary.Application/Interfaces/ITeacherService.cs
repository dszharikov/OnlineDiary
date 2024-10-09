using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ITeacherService
{
    Task<Teacher> GetTeacherByIdAsync(Guid teacherId);
    Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    Task CreateTeacherAsync(Teacher dto);
    Task UpdateTeacherAsync(Guid teacherId, Teacher dto);
    Task DeleteTeacherAsync(Guid teacherId);
}
