using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class TermRepository : BaseRepository<Term>, ITermRepository
    {
        public TermRepository(SchoolDbContext context) : base(context) { }
    }
}
