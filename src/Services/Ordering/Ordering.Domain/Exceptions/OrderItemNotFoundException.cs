namespace Ordering.Domain.Exceptions
{
    public class OrderItemNotFoundException : DomainException
    {
        public OrderItemNotFoundException(ProductId productId)
            : base($"Order item with ProductId '{productId}' was not found.") { }
    }
}
