namespace Ordering.Domain.Exceptions
{
    internal class EmptyPaymentMethodException : DomainException
    {
        public EmptyPaymentMethodException() : base("Payment method cannot be empty.")
        {
        }
    }
}
