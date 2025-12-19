using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
   internal class UnsupportedIdAutoGenerationException : DomainException
    {
        public UnsupportedIdAutoGenerationException(string typeName)
            : base($"Cannot auto-generate ID for non-Guid type '{typeName}'.")
        {
        }
    }
}
