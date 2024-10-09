using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(Guid classId)
        {
            return await _dbSet
                .Where(s => s.ClassId == classId)
                .Include(s => s.Class)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbSet
                .Include(s => s.Class)
                .ToListAsync();
        }

        public override async Task<Student> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.UserId == id);
        }
    }
}
