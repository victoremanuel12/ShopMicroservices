using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class InvalidExpirationException : DomainException
    {
        public InvalidExpirationException(string exp) : 
            base($"Expiration date '{exp}' is invalid. Expected format MM/YY and cannot be expired."){}
    }
}
