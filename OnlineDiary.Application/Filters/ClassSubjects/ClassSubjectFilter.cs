using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Filters.ClassSubjects;

public class ClassSubjectFilter : IFilter<ClassSubject>
{
    public IQueryable<ClassSubject> Apply(IQueryable<ClassSubject> query, object filterDto)
    {
        if (filterDto is ClassSubjectFilterRequestDto filter)
        {
            if (filter.ClassId != Guid.Empty)
            {
                query = query.Where(cs => cs.ClassId == filter.ClassId);
            }
            if (filter.TeacherId != Guid.Empty)
            {
                query = query.Where(cs => cs.TeacherId == filter.TeacherId);
            }
            if (filter.SubjectId != Guid.Empty)
            {
                query = query.Where(cs => cs.SubjectId == filter.SubjectId);
            }
        }
        return query;
    }
}