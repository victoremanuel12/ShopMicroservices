namespace Ordering.Domain.ValueObjects
{
    public record OrderId : Id<Guid>
    {
        private OrderId(Guid value) : base(value)
        {
        }
        public static OrderId New() => New<OrderId>();
        public static OrderId Rehydrate(Guid value) => Rehydrate<OrderId>(value);
    }
}
