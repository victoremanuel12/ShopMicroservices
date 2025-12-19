using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class InvalidCardNumberException : DomainException
    {
        public InvalidCardNumberException(string cardNumber)
            : base($"The card number '{cardNumber}' is invalid.") { }
    }
}
