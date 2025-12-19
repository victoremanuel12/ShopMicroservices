namespace Ordering.Domain.Exceptions.Abstraction;

public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
    }
}
