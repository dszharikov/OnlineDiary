namespace OnlineDiary.Presentation.DTOs.TermDtos;

public class CreateTermDto
{
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
