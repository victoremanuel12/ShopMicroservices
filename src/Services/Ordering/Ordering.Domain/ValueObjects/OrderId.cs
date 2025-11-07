namespace Ordering.Domain.ValueObjects
{
    public record OrderId : Id<Guid>
    {
        public OrderId(Id<Guid> original) : base(original)
        {
        }
    }
}
