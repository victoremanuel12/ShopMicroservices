using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            // Check if any product already exists
            if (await session.Query<Product>().AnyAsync())
                return;

            // Add preconfigured products to the database
            session.Store(GetPreconfiguredProducts);
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts => new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Description = "This phone is the best",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S21",
                Description = "Flagship Samsung phone with great features",
                ImageFile = "product-2.png",
                Price = 850.00M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Google Pixel 6",
                Description = "Pixel phone with the latest Android experience",
                ImageFile = "product-3.png",
                Price = 800.00M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Sony WH-1000XM4",
                Description = "Industry-leading noise-canceling headphones",
                ImageFile = "product-4.png",
                Price = 300.00M,
                Category = new List<string> { "Headphones" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 13",
                Description = "High-end laptop for productivity and performance",
                ImageFile = "product-5.png",
                Price = 1200.00M,
                Category = new List<string> { "Laptop" }
            }
        };
    }
}
