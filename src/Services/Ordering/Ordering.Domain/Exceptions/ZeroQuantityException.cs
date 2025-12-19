using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class ZeroQuantityException : DomainException
    {
        public ZeroQuantityException()
            : base("Quantity cannot be zero.") { }
    }
}
