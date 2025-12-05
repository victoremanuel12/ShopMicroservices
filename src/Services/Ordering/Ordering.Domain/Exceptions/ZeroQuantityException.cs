namespace Ordering.Domain.Exceptions
{
    public class ZeroQuantityException : DomainException
    {
        public ZeroQuantityException()
            : base("Quantity cannot be zero.") { }
    }
}
