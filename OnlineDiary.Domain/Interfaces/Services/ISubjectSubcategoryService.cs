using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface ISubjectSubcategoryService
{
    Task<SubjectSubcategory> GetSubcategoryByIdAsync(Guid subcategoryId);

    Task<IEnumerable<SubjectSubcategory>> GetSubcategoriesBySubjectIdAsync(Guid subjectId);

    Task CreateSubcategoryAsync(SubjectSubcategory subcategory);

    Task UpdateSubcategoryAsync(SubjectSubcategory subcategory);

    Task DeleteSubcategoryAsync(Guid subcategoryId);
}
