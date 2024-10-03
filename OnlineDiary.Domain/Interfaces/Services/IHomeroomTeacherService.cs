using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IHomeroomTeacherService
{
    Task<HomeroomTeacher> GetHomeroomTeacherByClassIdAsync(Guid classId);

    Task AssignHomeroomTeacherAsync(Guid classId, Guid teacherId);

    Task RemoveHomeroomTeacherAsync(Guid classId);
}
