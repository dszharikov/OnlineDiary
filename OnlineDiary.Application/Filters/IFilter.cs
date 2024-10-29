namespace OnlineDiary.Application.Filters;

public interface IFilter<T>
{
    IQueryable<T> Apply(IQueryable<T> query, object filterDto);
}