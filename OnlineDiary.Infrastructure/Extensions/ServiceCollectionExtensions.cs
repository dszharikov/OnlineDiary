using Microsoft.Extensions.DependencyInjection;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Data;
using OnlineDiary.Infrastructure.UnitOfWorks;
using OnlineDiary.Infrastructure.Services.Tenant;
using OnlineDiary.Infrastructure.Services.Authentication;
using OnlineDiary.Infrastructure.Repositories;

namespace OnlineDiary.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Регистрация контекстов базы данных
            services.AddDbContext<AuthDbContext>(/* настройки */);
            services.AddDbContext<SchoolDbContext>(/* настройки */);

            // Регистрация репозиториев
             services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectSubcategoryRepository, SubjectSubcategoryRepository>();
            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IHomeworkRepository, HomeworkRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IQuarterlyGradeRepository, QuarterlyGradeRepository>();
            services.AddScoped<IQuarterlySubgradeRepository, QuarterlySubgradeRepository>();
            services.AddScoped<IClassLevelSubjectRepository, ClassLevelSubjectRepository>();
            services.AddScoped<IClassSubjectRepository, ClassSubjectRepository>();

            // Регистрация UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Регистрация сервисов
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITenantService, TenantService>();

            return services;
        }
    }
}
