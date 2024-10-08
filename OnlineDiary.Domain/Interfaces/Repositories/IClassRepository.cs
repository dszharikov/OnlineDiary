using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IClassRepository : IRepository<Class>
{
    Task<Class> GetByNameAsync(string className);
}