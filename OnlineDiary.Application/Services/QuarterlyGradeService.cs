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

    public async Task<IEnumerable<QuarterlyGrade>> GetQuarterlyGradesByStudentIdTermIdAsync(Guid studentId, Guid termId)
    {
        var quarterlyGrades = await _unitOfWork.QuarterlyGrades
            .GetByStudentIdTermIdAsync(studentId, termId);

        return quarterlyGrades;
    }

    public async Task<IEnumerable<QuarterlyGrade>> GetQuarterlyGradesByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId)
    {
        var quarterlyGrades = await _unitOfWork.QuarterlyGrades
            .GetByClassSubjectAndTermAsync(classSubjectId, termId);

        return quarterlyGrades;
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

    public async Task CreateQuarterlyGradeAsync(QuarterlyGrade quarterlyGrade)
    {
        await _unitOfWork.QuarterlyGrades.AddAsync(quarterlyGrade);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateQuarterlyGradeAsync(QuarterlyGrade updatedQuarterlyGrade)
    {
        _unitOfWork.QuarterlyGrades.Update(updatedQuarterlyGrade);
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