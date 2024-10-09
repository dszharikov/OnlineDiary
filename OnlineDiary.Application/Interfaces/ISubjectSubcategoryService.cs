using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ISubjectSubcategoryService
{
    Task<SubjectSubcategory> GetSubcategoryByIdAsync(Guid subcategoryId);
    Task<IEnumerable<SubjectSubcategory>> GetAllSubcategoriesAsync();
    Task CreateSubcategoryAsync(SubjectSubcategory dto);
    Task UpdateSubcategoryAsync(Guid subcategoryId, SubjectSubcategory dto);
    Task DeleteSubcategoryAsync(Guid subcategoryId);
}
