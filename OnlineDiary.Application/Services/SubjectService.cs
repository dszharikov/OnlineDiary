using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Filters;
using OnlineDiary.Application.Filters.Subjects;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class SubjectService : ISubjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFilter<Subject> _subjectFilter;
    private readonly IPaginationService _paginationService;

    public SubjectService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFilter<Subject> subjectFilter,
        IPaginationService paginationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _subjectFilter = subjectFilter;
        _paginationService = paginationService;
    }

    public async Task<Subject> GetSubjectByIdAsync(Guid subjectId)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);
        if (subject == null)
        {
            throw new NotFoundException($"Предмет с ID {subjectId} не найден.");
        }

        return subject;
    }

    public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
    {
        var subjects = _unitOfWork.Subjects.GetAllAsync();
        return subjects;
    }

    public async Task<PaginationResponseDto<Subject>> GetSubjectsAsync(
        PaginationAndFilterRequestDto<SubjectFilterRequestDto> paginationAndFilterRequest)
    {
        var query = _unitOfWork.Subjects.GetAllAsync();

        query = _subjectFilter.Apply(query, paginationAndFilterRequest.Filter);

        var paginatedSubjects = await _paginationService.PaginateAsync(query, paginationAndFilterRequest.Pagination);
        return paginatedSubjects;
    }

    public async Task CreateSubjectAsync(Subject subject)
    {
        await EnsureSubjectDoesNotExistsAsync(subject.Name);

        await _unitOfWork.Subjects.AddAsync(subject);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateSubjectAsync(Guid subjectId, Subject updatedSubject)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);
        if (subject == null)
        {
            throw new NotFoundException($"Предмет с ID {subjectId} не найден.");
        }

        if (subject.Name != updatedSubject.Name)
        {
            await EnsureSubjectDoesNotExistsAsync(updatedSubject.Name);
        }

        _mapper.Map(updatedSubject, subject); // Обновляем сущность через маппинг
        _unitOfWork.Subjects.Update(subject);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSubjectAsync(Guid subjectId)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);
        if (subject == null)
        {
            throw new NotFoundException($"Предмет с ID {subjectId} не найден.");
        }

        _unitOfWork.Subjects.Remove(subject);

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task EnsureSubjectDoesNotExistsAsync(string name)
    {
        var subjects = await _unitOfWork.Subjects.FindAsync(s => s.Name == name);
        if (subjects.Any())
        {
            throw new DuplicateException($"Предмет с именем {name} уже существует.");
        }
    }

    
}
