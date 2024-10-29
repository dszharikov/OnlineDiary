using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Filters.Teachers
{
    public class TeacherFilter : IFilter<Teacher>
    {
        public IQueryable<Teacher> Apply(IQueryable<Teacher> query, object filterDto)
        {
            if (filterDto is TeacherFilterRequestDto filter)
            {
                if (!string.IsNullOrEmpty(filter.FirstName))
                {
                    query = query.Where(t => t.FirstName.Contains(filter.FirstName));
                }
                if (!string.IsNullOrEmpty(filter.LastName))
                {
                    query = query.Where(t => t.LastName.Contains(filter.LastName));
                }
            }
            return query;
        }
    }
}
