namespace Ordering.Domain.Abstraction
{
    public abstract record Id<TValue>
    {
        public TValue Value { get; protected set; }
        protected Id(TValue value)
        {
            var typeName = GetType().Name;
            if (value == null)
                throw new DomainException($"{typeName} value cannot be null.");

            if (value is Guid guid && guid == Guid.Empty)
                throw new DomainException($"{typeName}  value cannot be  empty ");

            Value = value;
        }
    }
}
