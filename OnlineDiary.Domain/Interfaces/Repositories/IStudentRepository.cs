using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(Guid classId);
}