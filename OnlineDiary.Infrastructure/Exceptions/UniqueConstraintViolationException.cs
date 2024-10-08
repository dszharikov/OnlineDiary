namespace OnlineDiary.Infrastructure.Exceptions;

public class UniqueConstraintViolationException : Exception
{
    public UniqueConstraintViolationException(string message) : base(message)
    {
    }
}