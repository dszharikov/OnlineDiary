using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Application.Filters.ClassSubjects;
using OnlineDiary.Application.Filters;

namespace OnlineDiary.Application.Services;

public class ClassSubjectService : IClassSubjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;
    private readonly IFilter<ClassSubject> _classSubjectFilter;

    public ClassSubjectService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPaginationService paginationService, 
        IFilter<ClassSubject> classSubjectFilter)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _paginationService = paginationService;
        _classSubjectFilter = classSubjectFilter;
    }

    public async Task<ClassSubject> GetClassSubjectByIdAsync(Guid classSubjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(classSubjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ID {classSubjectId} не найдена.");
        }

        return classSubject;
    }

    public async Task<ClassSubject> GetClassSubjectByClassIdAndSubjectIdAsync(Guid classId, Guid subjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByClassAndSubjectAsync(classId, subjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ClassId {classId} и SubjectId {subjectId} не найдена.");
        }

        return classSubject;
    }

    public async Task<PaginationResponseDto<ClassSubject>> GetClassSubjectsAsync(
        PaginationAndFilterRequestDto<ClassSubjectFilterRequestDto> paginationAndFilterRequestDto)
    {
        var query = _unitOfWork.ClassSubjects.GetAllAsync();

        query = _classSubjectFilter.Apply(query, paginationAndFilterRequestDto.Filter);

        var paginatedClassSubjects = await _paginationService.PaginateAsync(query, paginationAndFilterRequestDto.Pagination);
        return paginatedClassSubjects;
    }

    public async Task<IEnumerable<ClassSubject>> GetClassSubjectsBySubjectIdAsync(Guid subjectId)
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetBySubjectIdAsync(subjectId);

        return classSubjects;
    }

    public async Task<IEnumerable<ClassSubject>> GetClassSubjectsByTeacherIdAsync(Guid teacherId)
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetByTeacherIdAsync(teacherId);

        return classSubjects;
    }

    public async Task<IEnumerable<ClassSubject>> GetClassSubjectsByClassIdAsync(Guid classId)
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetByClassIdAsync(classId);

        return classSubjects;
    }

    public async Task CreateClassSubjectAsync(ClassSubject classSubject)
    {
        await EnsureClassSubjectDoesNotExistAsync(classSubject.ClassId, classSubject.SubjectId);

        await _unitOfWork.ClassSubjects.AddAsync(classSubject);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateClassSubjectAsync(Guid classSubjectId, ClassSubject updatedClassSubject)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(classSubjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ID {classSubjectId} не найдена.");
        }

        if (updatedClassSubject.ClassId != classSubject.ClassId || updatedClassSubject.SubjectId != classSubject.SubjectId)
        {
            await EnsureClassSubjectDoesNotExistAsync(updatedClassSubject.ClassId, updatedClassSubject.SubjectId);
        }

        _mapper.Map(updatedClassSubject, classSubject);

        _unitOfWork.ClassSubjects.Update(classSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteClassSubjectAsync(Guid classSubjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(classSubjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ID {classSubjectId} не найдена.");
        }

        _unitOfWork.ClassSubjects.Remove(classSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    // Метод проверки на наличие дубликата ClassSubject
    private async Task EnsureClassSubjectDoesNotExistAsync(Guid classId, Guid subjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByClassAndSubjectAsync(classId, subjectId);

        if (classSubject != null)
        {
            throw new DuplicateException("Такая запись ClassSubject уже существует.");
        }
    }
}
