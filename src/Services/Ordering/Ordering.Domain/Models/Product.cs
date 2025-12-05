namespace Ordering.Domain.Models
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;
        private Product(ProductId id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public static Product Create(ProductId id, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new EmptyFirstNameException();

            if (decimal.IsNegative(price))
                throw new NegativePriceException();

            return new Product(id, name, price);
        }
    }
}
