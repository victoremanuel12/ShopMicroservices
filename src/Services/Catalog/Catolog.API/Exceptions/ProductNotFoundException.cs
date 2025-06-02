using BuildBlocks.Exceptions;

namespace Catolog.API.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid Id) : base("Product",Id)
        {
            
        }
    }
}
