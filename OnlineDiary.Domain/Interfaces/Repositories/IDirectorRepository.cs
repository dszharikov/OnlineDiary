using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IDirectorRepository : IRepository<Director>
{
    Task<Director> GetDirectorByIdAsync(Guid directorId);

    Task<Director> GetDirectorBySchoolIdAsync(Guid schoolId);

    Task<Director> GetDirectorByUserIdAsync(Guid userId);
}