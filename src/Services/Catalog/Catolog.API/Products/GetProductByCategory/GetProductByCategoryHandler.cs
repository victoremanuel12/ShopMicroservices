namespace Catolog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResukt>;
    public record GetProductByCategoryResukt(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResukt>
    {
        public async Task<GetProductByCategoryResukt> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains(query.Category))
                .ToListAsync();
            return new GetProductByCategoryResukt(products);
        }
    }
}
