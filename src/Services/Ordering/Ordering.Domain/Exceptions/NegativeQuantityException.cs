namespace Ordering.Domain.Exceptions
{
    public class NegativeQuantityException : DomainException
    {
        public NegativeQuantityException()
            : base("Quantity cannot be negative") { }
    }
}
