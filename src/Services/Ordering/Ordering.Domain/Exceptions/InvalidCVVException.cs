using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class InvalidCVVException : DomainException
    {
        public InvalidCVVException(int ccvLenght, string cvv)
        : base($"CVV '{cvv}' is invalid. Expected {ccvLenght} digits.")
        { }
    }
}
