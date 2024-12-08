using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Filters.ClassLevelSubjects;

public class ClassLevelSubjectFilter : IFilter<ClassLevelSubject>
{
    public IQueryable<ClassLevelSubject> Apply(IQueryable<ClassLevelSubject> query, object filterDto)
    {
        if (filterDto is ClassLevelSubjectFilterRequestDto filter)
        {
            if (filter.ClassLevel > 0)
            {
                query = query.Where(cls => cls.ClassLevel == filter.ClassLevel);
            }
            if (!string.IsNullOrEmpty(filter.SubjectName))
            {
                query = query.Where(cls => cls.Subject.Name.Contains(filter.SubjectName));
            }
        }
        return query;
    }
}