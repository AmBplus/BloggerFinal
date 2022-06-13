namespace P.Domain.Exceptions;

public class DuplicateFieldException : Exception
{
    public DuplicateFieldException()
    {
    }

    public DuplicateFieldException(string message) : base(message)
    {
    }
}