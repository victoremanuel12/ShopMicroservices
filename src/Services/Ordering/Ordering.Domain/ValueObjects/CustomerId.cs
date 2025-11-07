namespace Ordering.Domain.ValueObjects
{
    public record CustomerId : Id<Guid>
    {
        public CustomerId(Id<Guid> original) : base(original)
        {
        }
    }
}
