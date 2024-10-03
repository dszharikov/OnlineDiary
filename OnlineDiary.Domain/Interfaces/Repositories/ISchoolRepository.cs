using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface ISchoolRepository : IRepository<School>
{
    Task<School> GetSchoolByIdAsync(Guid schoolId);

    Task<School> GetSchoolWithDirectorAsync(Guid schoolId);
}
