using BuildBlocks.CQRS;
using Catolog.API.Models;

namespace Catolog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreatreProductResult>;
    public record CreatreProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreatreProductResult>
    {
        public Task<CreatreProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //var product = new Product();
            // save product in database;
            //return Guid of product created 
            throw new NotImplementedException();
        }
    }
}
