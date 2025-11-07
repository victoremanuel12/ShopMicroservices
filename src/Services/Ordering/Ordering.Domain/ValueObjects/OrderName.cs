namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        public string Value { get; private set; }
        public OrderName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Order name cannot be null or empty.", nameof(value));
            }
            if (value.Length > 100)
            {
                throw new ArgumentException("Order name cannot exceed 100 characters.", nameof(value));
            }
            Value = value;
        }
    }
}
