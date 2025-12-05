namespace Ordering.Domain.Abstraction.interfaces
{
    public interface IAggregate<T> : IAggregate, IEntity<T> { }
    public interface IAggregate : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
