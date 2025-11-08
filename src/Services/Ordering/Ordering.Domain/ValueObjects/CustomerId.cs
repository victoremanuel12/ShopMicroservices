namespace Ordering.Domain.ValueObjects
{
    public record CustomerId : Id<Guid>
    {
        private CustomerId(Guid value) : base(value)
        {
        }
        public static CustomerId New() => New<CustomerId>();
        public static CustomerId Rehydrate(Guid value) => Rehydrate<CustomerId>(value);
    }
}
