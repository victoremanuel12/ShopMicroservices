
using Catolog.API.Products.GetProductById;

namespace Catolog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool Deleted);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (ISender sender, Guid id) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                var response  =  result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
               .WithName("DeleteProduct")
               .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Delete Product By Id")
               .WithDescription("Delete Product By Id");
        }
    }
}
