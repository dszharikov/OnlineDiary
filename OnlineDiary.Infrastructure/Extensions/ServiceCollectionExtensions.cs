using Microsoft.Extensions.DependencyInjection;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Data;
using OnlineDiary.Infrastructure.UnitOfWorks;
using OnlineDiary.Infrastructure.Services.Tenant;
using OnlineDiary.Infrastructure.Services.Authentication;
using OnlineDiary.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OnlineDiary.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace OnlineDiary.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Регистрация AuthDbContext
            services.AddDbContext<AuthDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("AuthConnection")));
            services.AddDbContext<SchoolDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("SchoolConnection")));

            // Настройка Identity
            services.AddIdentity<InfrastructureUser, InfrastructureRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

            // Регистрация репозиториев
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
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

            // Регистрация UserManager и RoleManager
            services.AddScoped<UserManager<InfrastructureUser>>();
            services.AddScoped<RoleManager<InfrastructureRole>>();

            // Регистрация сервисов
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITenantService, TenantService>();

            return services;
        }
    }
}
