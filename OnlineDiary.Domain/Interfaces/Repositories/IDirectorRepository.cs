using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IDirectorRepository : IRepository<Director>
{
    Task<Director> GetDirectorBySchoolIdAsync(Guid schoolId);
}