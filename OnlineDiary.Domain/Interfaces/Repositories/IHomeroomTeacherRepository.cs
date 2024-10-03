using System;
using System.Threading.Tasks;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories
{
    public interface IHomeroomTeacherRepository : IRepository<HomeroomTeacher>
    {
        Task<HomeroomTeacher> GetByClassIdAsync(Guid classId);

        Task<HomeroomTeacher> GetByTeacherIdAsync(Guid teacherId);
    }
}
