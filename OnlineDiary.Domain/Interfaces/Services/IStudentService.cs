using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid studentId);

    Task<Student> GetStudentByUserIdAsync(Guid userId);

    Task<IEnumerable<Student>> GetAllStudentsAsync();

    Task CreateStudentAsync(Student student);

    Task UpdateStudentAsync(Student student);

    Task DeleteStudentAsync(Guid studentId);
}
