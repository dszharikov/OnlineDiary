using OnlineDiary.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
