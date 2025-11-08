namespace Ordering.Domain.ValueObjects
{
    public sealed record ProductId : Id<Guid>
    {
        private ProductId(Guid value) : base(value)
        {
        }
        public static ProductId New() => New<ProductId>();
        public static ProductId Rehydrate(Guid value) => Rehydrate<ProductId>(value);

    }
}
