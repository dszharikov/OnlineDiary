using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ISchoolService
{
    Task<School> GetSchoolByIdAsync(Guid schoolId);
    Task<School> GetCurrentSchoolAsync();
    Task<IEnumerable<School>> GetAllSchoolsAsync();
    Task CreateSchoolAsync(School dto);
    Task UpdateSchoolAsync(Guid schoolId, School dto);
    Task DeleteSchoolAsync(Guid schoolId);
}
