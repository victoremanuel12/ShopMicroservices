namespace Ordering.Domain.ValueObjects
{
    public record OrderItemId : Id<Guid>
    {
        public OrderItemId(Guid value) : base(value)
        {
        }
    }
}
