using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext context) : base(context) { }
    }
}
