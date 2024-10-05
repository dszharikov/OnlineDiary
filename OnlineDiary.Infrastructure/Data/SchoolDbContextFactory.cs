using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineDiary.Infrastructure.Services.Tenant;

namespace OnlineDiary.Infrastructure.Data;

public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
{
    public SchoolDbContext CreateDbContext(string[] args)
    {
        // Загрузка конфигурации из appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Получаем строку подключения из конфигурации
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Создаем опции для контекста
        var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        // Создаем и возвращаем контекст, передав заглушку для ITenantService
        return new SchoolDbContext(optionsBuilder.Options, new FakeTenantService());
    }
}

// Реализация заглушки для ITenantService для миграций
public class FakeTenantService : ITenantService
{
    public string SchoolId { get; set; } = "default_schema"; // Заглушка схемы
}
