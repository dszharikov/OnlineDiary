using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using OnlineDiary.Infrastructure.Authorization.Requirements.Grade;
using OnlineDiary.Infrastructure.Services.Authorization;
using OnlineDiary.Infrastructure.Authorization.Handlers.Grades;
using OnlineDiary.Infrastructure.Authorization.Handlers.QuarterlyGrades;

namespace OnlineDiary.Infrastructure.Extensions
{
    public static class AuthorizationServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {
            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("CanCreateGrade", policy => policy.Requirements.Add(new CanCreateGradeRequirement()));
                options.AddPolicy("CanEditGrade", policy => policy.Requirements.Add(new CanEditGradeRequirement()));
                options.AddPolicy("CanViewGrade", policy => policy.Requirements.Add(new CanViewGradeRequirement()));
            });

            services.AddScoped<Services.Authorization.IAuthorizationService, AuthorizationService>();

            // Добавляем обработчики политик
            services.AddScoped<IAuthorizationHandler, CanCreateGradeHandler>();
            services.AddScoped<IAuthorizationHandler, CanEditGradeHandler>();
            services.AddScoped<IAuthorizationHandler, CanViewGradeHandler>();


            return services;
        }
    }
}
