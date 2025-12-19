using Ordering.Domain.Exceptions.Abstraction;

namespace Ordering.Domain.Exceptions
{
    internal sealed class RequiredFieldException : DomainException
    {
        public RequiredFieldException(string fieldName)
            : base($"The field '{fieldName}' is required and cannot be empty.")
        {
        }
    }
}
