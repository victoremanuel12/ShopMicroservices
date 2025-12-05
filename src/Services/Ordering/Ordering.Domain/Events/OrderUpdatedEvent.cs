using Ordering.Domain.Abstraction.interfaces;
using Ordering.Domain.Models;

namespace Ordering.Domain.Events
{
    internal record OrderUpdatedEvent(Order Order) : IDomainEvent
    {
    }
}
