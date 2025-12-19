using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class OrderItemNotFoundException : DomainException
    {
        public OrderItemNotFoundException(ProductId productId)
            : base($"Order item with ProductId '{productId}' was not found.") { }
    }
}
