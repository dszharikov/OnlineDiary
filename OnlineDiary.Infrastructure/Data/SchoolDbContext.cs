using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Infrastructure.Data.Configurations;
using OnlineDiary.Infrastructure.Services.Tenant;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineDiary.Infrastructure.Data
{
    public class SchoolDbContext : DbContext
    {
        private readonly ITenantService _tenantService;

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options, ITenantService tenantService)
            : base(options)
        {
            _tenantService = tenantService;
        }

        // DbSet для сущностей
        public DbSet<School> Schools { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectSubcategory> SubjectSubcategories { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<QuarterlyGrade> QuarterlyGrades { get; set; }
        public DbSet<QuarterlySubgrade> QuarterlySubgrades { get; set; }
        public DbSet<ClassLevelSubject> ClassLevelSubjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Настройка схемы базы данных на основе school_id
            string schema = _tenantService.SchoolId;

            if (!optionsBuilder.IsConfigured)
            {
                // TODO: Подключение к базе данных
                optionsBuilder.UseNpgsql("YourConnectionString", options =>
                {
                    options.MigrationsAssembly("OnlineDiary.Infrastructure");
                    options.MigrationsHistoryTable("__EFMigrationsHistory", schema);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string schema = _tenantService.SchoolId;
            modelBuilder.HasDefaultSchema(schema);

            // Применение конфигураций
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectSubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TermConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new QuarterlyGradeConfiguration());
            modelBuilder.ApplyConfiguration(new QuarterlySubgradeConfiguration());
            modelBuilder.ApplyConfiguration(new ClassLevelSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new ClassSubjectConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        // Переопределение метода SaveChangesAsync для установки схемы перед сохранением
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            // Дополнительные действия перед сохранением (например, аудирование)

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}