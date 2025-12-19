using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class NegativeQuantityException : DomainException
    {
        public NegativeQuantityException()
            : base("Quantity cannot be negative") { }
    }
}
