using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class IdValueNullException : DomainException
    {
        public IdValueNullException(string typeName)
            : base($"{typeName} value cannot be null.")
        {
        }
    }
}
