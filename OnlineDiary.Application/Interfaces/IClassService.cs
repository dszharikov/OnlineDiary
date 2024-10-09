using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IClassService
{
    Task<Class> GetClassByIdAsync(Guid classId);
    Task<IEnumerable<Class>> GetAllClassesAsync();
    Task CreateClassAsync(Class dto);
    Task UpdateClassAsync(Guid classId, Class dto);
    Task DeleteClassAsync(Guid classId);
}
