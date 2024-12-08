using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Filters.Students;

public class StudentFilter : IFilter<Student>
{
    public IQueryable<Student> Apply(IQueryable<Student> query, object filterDto)
    {
        if (filterDto is StudentFilterRequestDto filter)
        {
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(s => s.FirstName.Contains(filter.FirstName));
            }
            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(s => s.LastName.Contains(filter.LastName));
            }
            if (filter.ClassId != Guid.Empty)
            {
                query = query.Where(s => s.ClassId == filter.ClassId);
            }
        }
        return query;
    }
}