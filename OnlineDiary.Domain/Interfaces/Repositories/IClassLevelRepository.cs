using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IClassLevelRepository : IRepository<ClassLevel>
{
    Task<ClassLevel> GetByLevelAsync(int level);
}
