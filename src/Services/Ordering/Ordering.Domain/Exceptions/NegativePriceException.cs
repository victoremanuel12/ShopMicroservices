using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class NegativePriceException : DomainException
    {
        public NegativePriceException()
            : base("Price cannot be negative.") { }
    }
}
