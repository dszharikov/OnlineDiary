using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class SchoolService : ISchoolService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SchoolService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<School> GetSchoolByIdAsync(Guid schoolId)
    {
        var school = await _unitOfWork.Schools.GetByIdAsync(schoolId);
        if (school == null)
        {
            throw new NotFoundException($"Школа с ID {schoolId} не найдена.");
        }

        return school;
    }

    public async Task<IEnumerable<School>> GetAllSchoolsAsync()
    {
        var schools = _unitOfWork.Schools.GetAllAsync().ToList();

        return schools;
    }

    public async Task<School> GetCurrentSchoolAsync()
    {
        var school = await _unitOfWork.Schools.GetCurrentSchoolAsync();

        if (school is null)
        {
            throw new NotFoundException("Текущая школа не найдена.");
        }

        return school;
    }

    public async Task CreateSchoolAsync(School dto)
    {
        var school = await _unitOfWork.Schools.GetCurrentSchoolAsync();

        if (school != null)
        {
            throw new DuplicateException("Текущая школа уже существует.");
        }

        school = _mapper.Map<School>(dto);
        await _unitOfWork.Schools.AddAsync(school);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateSchoolAsync(Guid schoolId, School updatedSchool)
    {
        var school = await _unitOfWork.Schools.GetByIdAsync(schoolId);
        if (school == null)
        {
            throw new NotFoundException($"Школа с ID {schoolId} не найдена.");
        }

        _mapper.Map(updatedSchool, school); // Обновляем сущность через маппинг
        _unitOfWork.Schools.Update(school);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSchoolAsync(Guid schoolId)
    {
        var school = await _unitOfWork.Schools.GetByIdAsync(schoolId);
        if (school == null)
        {
            throw new NotFoundException($"Школа с ID {schoolId} не найдена.");
        }

        _unitOfWork.Schools.Remove(school);

        await _unitOfWork.SaveChangesAsync();
    }
}
