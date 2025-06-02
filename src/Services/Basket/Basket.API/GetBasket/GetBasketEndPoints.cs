﻿
namespace Basket.API.GetBasket
{
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(userName));
                var response = result.Adapt<GetBasketResult>();

                return Results.Ok(response);

            }).WithName("GetProductById")
              .Produces<GetBasketResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Product By Id")
              .WithDescription("Get Product By Id");
        }
    }
}
