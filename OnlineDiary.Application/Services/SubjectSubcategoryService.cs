using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class SubjectSubcategoryService : ISubjectSubcategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubjectSubcategoryService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SubjectSubcategory> GetSubcategoryByIdAsync(Guid subcategoryId)
    {
        var subcategory = await _unitOfWork.SubjectSubcategories.GetByIdAsync(subcategoryId);
        if (subcategory == null)
        {
            throw new NotFoundException($"Подкатегория с ID {subcategoryId} не найдена.");
        }

        return subcategory;
    }

    public async Task<IEnumerable<SubjectSubcategory>> GetAllSubcategoriesAsync()
    {
        var subcategories = await _unitOfWork.SubjectSubcategories.GetAllAsync();
        return subcategories;
    }

    public async Task CreateSubcategoryAsync(SubjectSubcategory subcategory)
    {
        await EnsureSubcategoryDoesNotExistAsync(subcategory.SubjectId, subcategory.Name);

        await _unitOfWork.SubjectSubcategories.AddAsync(subcategory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateSubcategoryAsync(Guid subcategoryId, SubjectSubcategory updatedSubcategory)
    {
        var subcategory = await _unitOfWork.SubjectSubcategories.GetByIdAsync(subcategoryId);
        if (subcategory == null)
        {
            throw new NotFoundException($"Подкатегория с ID {subcategoryId} не найдена.");
        }

        if (updatedSubcategory.Name != subcategory.Name)
        {
            await EnsureSubcategoryDoesNotExistAsync(subcategory.SubjectId, updatedSubcategory.Name);
        }

        _mapper.Map(updatedSubcategory, subcategory); // Обновляем сущность через маппинг
        _unitOfWork.SubjectSubcategories.Update(subcategory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSubcategoryAsync(Guid subcategoryId)
    {
        var subcategory = await _unitOfWork.SubjectSubcategories.GetByIdAsync(subcategoryId);
        if (subcategory == null)
        {
            throw new NotFoundException($"Подкатегория с ID {subcategoryId} не найдена.");
        }

        _unitOfWork.SubjectSubcategories.Remove(subcategory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task EnsureSubcategoryDoesNotExistAsync(Guid subjectId, string name)
    {
        var subcategories = await _unitOfWork.SubjectSubcategories.FindAsync(s => s.SubjectId == subjectId && s.Name == name);
        if (subcategories.Any())
        {
            throw new DuplicateException($"Подкатегория с именем {name} уже существует.");
        }
    }
}
