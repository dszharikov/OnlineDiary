using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Filters.Subjects;

public class SubjectFilter : IFilter<Subject>
{
    public IQueryable<Subject> Apply(IQueryable<Subject> query, object filterDto)
    {
        if (filterDto is SubjectFilterRequestDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(s => s.Name.Contains(filter.Name));
            }
        }
        return query;
    }
}