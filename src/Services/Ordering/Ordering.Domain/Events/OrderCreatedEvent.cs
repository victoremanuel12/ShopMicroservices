using Ordering.Domain.Abstraction.interfaces;
using Ordering.Domain.Models;

namespace Ordering.Domain.Events
{
    public record OrderCreatedEvent(Order Order) : IDomainEvent;
  
}
