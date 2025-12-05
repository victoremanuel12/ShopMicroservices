namespace Ordering.Domain.Exceptions
{
    public class EmptyFirstNameException : DomainException
    {
        public EmptyFirstNameException() : base($"First name cannot be empty.") { }

    }
}
