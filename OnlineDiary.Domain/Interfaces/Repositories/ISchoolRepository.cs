using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface ISchoolRepository : IRepository<School>
{
    Task<School> GetSchoolByIdAsync(Guid schoolId);
    Task<School> GetCurrentSchoolAsync();

    Task<School> GetSchoolWithDirectorAsync(Guid schoolId);
}
