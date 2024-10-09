using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid studentId);
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(Guid classId);
    Task CreateStudentAsync(Student dto);
    Task UpdateStudentAsync(Guid studentId, Student dto);
    Task DeleteStudentAsync(Guid studentId);
}
