namespace Ordering.Domain.Exceptions
{
    public class InvalidCardNumberException : DomainException
    {
        public InvalidCardNumberException(string cardNumber)
            : base($"The card number '{cardNumber}' is invalid.") { }
    }
}
