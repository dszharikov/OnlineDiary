using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILessonService _lessonService;

    public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper, ILessonService lessonService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _lessonService = lessonService;
    }

    public async Task<Schedule> GetScheduleByIdAsync(Guid scheduleId)
    {
        var schedule = await _unitOfWork.Schedules.GetByIdAsync(scheduleId);

        if (schedule == null)
        {
            throw new NotFoundException($"Расписание с ID {scheduleId} не найдено.");
        }

        return schedule;
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesByTermClassAsync(Guid termId, Guid classId)
    {
        var schedules = await _unitOfWork.Schedules.GetByTermClassAsync(termId, classId);

        return schedules;
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesByTermTeacherAsync(Guid termId, Guid teacherId)
    {
        var schedules = await _unitOfWork.Schedules.GetByTermTeacherAsync(termId, teacherId);

        return schedules;
    }

    public async Task CreateScheduleAsync(Schedule schedule)
    {
        var scheduleEntity = await _unitOfWork.Schedules.GetByTermClassSubjectDayOfWeekTimeAsync(
            schedule.TermId,
            schedule.ClassSubjectId,
            schedule.DayOfWeek,
            schedule.Time);

        if (scheduleEntity != null)
        {
            throw new DuplicateException("Расписание уже существует.");
        }


        await _unitOfWork.Schedules.AddAsync(schedule);
        await _unitOfWork.SaveChangesAsync();
        
        await _lessonService.CreateLessonsByScheduleAsync(schedule);
    }

    public async Task UpdateScheduleAsync(Guid scheduleId, Schedule schedule)
    {
        var scheduleEntity = await _unitOfWork.Schedules.GetByIdAsync(scheduleId);

        if (scheduleEntity == null)
        {
            throw new NotFoundException($"Расписание с ID {scheduleId} не найдено.");
        }

        _mapper.Map(schedule, scheduleEntity);

        _unitOfWork.Schedules.Update(scheduleEntity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteScheduleAsync(Guid scheduleId)
    {
        var schedule = await _unitOfWork.Schedules.GetByIdAsync(scheduleId);

        if (schedule == null)
        {
            throw new NotFoundException($"Расписание с ID {scheduleId} не найдено.");
        }

        _unitOfWork.Schedules.Remove(schedule);
        await _unitOfWork.SaveChangesAsync();
    }


}