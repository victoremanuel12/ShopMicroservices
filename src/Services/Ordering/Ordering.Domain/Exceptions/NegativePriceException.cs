namespace Ordering.Domain.Exceptions
{
    public class NegativePriceException : DomainException
    {
        public NegativePriceException()
            : base("Price cannot be negative.") { }
    }
}
