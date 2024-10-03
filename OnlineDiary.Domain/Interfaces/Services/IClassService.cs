using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IClassService
{
    Task<Class> GetClassByIdAsync(Guid classId);

    Task<IEnumerable<Class>> GetClassesBySchoolIdAsync(Guid schoolId);

    Task CreateClassAsync(Class @class);

    Task UpdateClassAsync(Class @class);

    Task DeleteClassAsync(Guid classId);

    Task AssignHomeroomTeacherAsync(Guid classId, Guid teacherId);
}
