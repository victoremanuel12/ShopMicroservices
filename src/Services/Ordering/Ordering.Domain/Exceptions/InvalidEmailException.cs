using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string email)
            : base($"The email '{email}' is invalid. Provide a valid email address.")
        {
        }
    }
}
