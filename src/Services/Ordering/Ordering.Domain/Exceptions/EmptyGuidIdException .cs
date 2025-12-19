using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal class EmptyGuidIdException : DomainException
    {
        public EmptyGuidIdException(string typeName)
            : base($"{typeName} value cannot be an empty GUID.")
        {
        }
    }
}
