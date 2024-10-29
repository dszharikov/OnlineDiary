namespace OnlineDiary.Presentation.DTOs.Authentication;

public class TokenResponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}