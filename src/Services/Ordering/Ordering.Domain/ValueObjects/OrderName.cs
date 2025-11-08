namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        private const int MaxLength = 5;
        public string Value { get; }
        private OrderName(string value) => Value = value;
        public static OrderName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Order name cannot be null or empty.");
            }
            if (value.Length > MaxLength)
            {
                throw new ArgumentException("Order name cannot exceed 100 characters.");
            }
            return new OrderName(value);
        }
    }
}
