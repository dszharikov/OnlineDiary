using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ClassSubjectRepository : BaseRepository<ClassSubject>, IClassSubjectRepository
    {
        public ClassSubjectRepository(SchoolDbContext context) : base(context) { }

        public async Task<ClassSubject> GetByClassAndSubjectAsync(Guid classId, Guid subjectId)
        {
            return await _dbSet
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .FirstOrDefaultAsync(cs => cs.ClassId == classId && cs.SubjectId == subjectId);
        }

        public async Task<IEnumerable<ClassSubject>> GetByClassIdAsync(Guid classId)
        {
            return await _dbSet
                .Where(cs => cs.ClassId == classId)
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .ToListAsync();
        }

        public override async Task<ClassSubject> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .FirstOrDefaultAsync(cs => cs.ClassSubjectId == id);
        }

        public override async Task<IEnumerable<ClassSubject>> GetAllAsync()
        {
            return await _dbSet
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .ToListAsync();
        }

        public override async Task<IEnumerable<ClassSubject>> FindAsync(Expression<Func<ClassSubject, bool>> predicate)
        {
            return await _dbSet
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClassSubject>> GetBySubjectIdAsync(Guid subjectId)
        {
            return await _dbSet
                .Where(cs => cs.SubjectId == subjectId)
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClassSubject>> GetByTeacherIdAsync(Guid subjectId)
        {
            return await _dbSet
                .Where(cs => cs.TeacherId == subjectId)
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Class)
                .ToListAsync();
        }
    }
}
