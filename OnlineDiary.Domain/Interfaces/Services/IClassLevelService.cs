using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IClassLevelService
{
    Task<ClassLevel> GetClassLevelByIdAsync(Guid classLevelId);

    Task<IEnumerable<ClassLevel>> GetAllClassLevelsAsync();

    Task CreateClassLevelAsync(ClassLevel classLevel);

    Task UpdateClassLevelAsync(ClassLevel classLevel);

    Task DeleteClassLevelAsync(Guid classLevelId);
}
