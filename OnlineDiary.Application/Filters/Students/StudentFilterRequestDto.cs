namespace OnlineDiary.Application.Filters.Students;

public class StudentFilterRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ClassId { get; set; }
}