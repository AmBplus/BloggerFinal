namespace P.Domain.Exceptions;

public class NullOrEmptyException : Exception
{
    public NullOrEmptyException()
    {
    }

    public NullOrEmptyException(string message) : base(message)
    {
    }
}