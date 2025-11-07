namespace Ordering.Domain.ValueObjects
{
    public sealed record ProductId : Id<Guid>
    {
        public ProductId(Guid value) : base(value)
        {
        }

    }
}
