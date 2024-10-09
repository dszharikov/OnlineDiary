namespace OnlineDiary.Presentation.DTOs.SubjectSubcategoryDtos;

public class SubjectSubcategoryDto
{
    public Guid SubcategoryId { get; set; }
    public string Name { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
}
