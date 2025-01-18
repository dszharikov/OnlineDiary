using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(SchoolDbContext context) : base(context) { }

    public override IQueryable<Subject> GetAllAsync()
    {
        return _dbSet
            .OrderBy(s => s.Name);
    }
}
