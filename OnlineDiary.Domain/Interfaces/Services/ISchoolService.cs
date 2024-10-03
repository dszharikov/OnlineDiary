using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface ISchoolService
{
    Task<School> GetSchoolByIdAsync(Guid schoolId);

    Task<IEnumerable<School>> GetAllSchoolsAsync();

    Task CreateSchoolAsync(School school);

    Task UpdateSchoolAsync(School school);

    Task DeleteSchoolAsync(Guid schoolId);
}
