using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class QuarterlyGradeService : IQuarterlyGradeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuarterlyGradeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<QuarterlyGrade> GetQuarterlyGradeByIdAsync(Guid quarterlyGradeId)
    {
        var quarterlyGrade = await _unitOfWork.QuarterlyGrades.GetByIdAsync(quarterlyGradeId);

        if (quarterlyGrade == null)
        {
            throw new NotFoundException($"Оценка с ID {quarterlyGradeId} не найдена.");
        }

        return quarterlyGrade;
    }

    public async Task<QuarterlyGrade> GetQuarterlyGradeByStudentSubjectTermAsync(Guid studentId, Guid subjectId, Guid termId)
    {
        var quarterlyGrade = await _unitOfWork.QuarterlyGrades.GetByStudentSubjectTermAsync(studentId, subjectId, termId);

        if (quarterlyGrade == null)
        {
            throw new NotFoundException($"Оценка не найдена.");
        }

        return quarterlyGrade;
    }

    public async Task<IEnumerable<QuarterlyGrade>> GetQuarterlyGradesByStudentIdAsync(Guid studentId)
    {
        var quarterlyGrades = await _unitOfWork.QuarterlyGrades.GetByStudentAsync(studentId);

        return quarterlyGrades;
    }
    public async Task CreateQuarterlyGradeAsync(QuarterlyGrade quarterlyGrade)
    {
        var quarterlyGradeEntity = await _unitOfWork.QuarterlyGrades
            .GetByStudentSubjectTermAsync(quarterlyGrade.StudentId, quarterlyGrade.SubjectId, quarterlyGrade.TermId);

        if (quarterlyGradeEntity != null)
        {
            throw new DuplicateException("Оценка уже существует.");
        }

        await _unitOfWork.QuarterlyGrades.AddAsync(quarterlyGrade);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateQuarterlyGradeAsync(Guid quarterlyGradeId, QuarterlyGrade updatedQuarterlyGrade)
    {
        var quarterlyGrade = await _unitOfWork.QuarterlyGrades.GetByIdAsync(quarterlyGradeId);

        if (quarterlyGrade == null)
        {
            throw new NotFoundException($"Оценка с ID {quarterlyGradeId} не найдена.");
        }

        _mapper.Map(updatedQuarterlyGrade, quarterlyGrade);

        _unitOfWork.QuarterlyGrades.Update(quarterlyGrade);
        await _unitOfWork.SaveChangesAsync();
    }
    public async Task DeleteQuarterlyGradeAsync(Guid quarterlyGradeId)
    {
        var quarterlyGrade = await _unitOfWork.QuarterlyGrades.GetByIdAsync(quarterlyGradeId);

        if (quarterlyGrade == null)
        {
            throw new NotFoundException($"Оценка с ID {quarterlyGradeId} не найдена.");
        }

        _unitOfWork.QuarterlyGrades.Remove(quarterlyGrade);
        await _unitOfWork.SaveChangesAsync();
    }
}