using Ordering.Domain.Abstraction.interfaces;
using Ordering.Domain.Models;

namespace Ordering.Domain.Events
{
    internal record OrderCreatedEvent(Order Order) : IDomainEvent;
  
}
