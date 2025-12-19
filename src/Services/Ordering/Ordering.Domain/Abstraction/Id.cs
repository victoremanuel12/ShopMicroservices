namespace Ordering.Domain.Abstraction
{
    public abstract record Id<TValue>
    {
        public TValue Value { get; protected set; }
        protected Id(TValue value)
        {
            var typeName = GetType().Name;
            if (value == null)
                throw new IdValueNullException(typeName);

            if (value is Guid guid && guid == Guid.Empty)
                throw new EmptyGuidIdException(typeName);
        }
        public static TId New<TId>() where TId : Id<TValue>
        {
            if (typeof(TValue) == typeof(Guid))
            {
                var newValue = (TValue)(object)Guid.NewGuid();
                return (TId)Activator.CreateInstance(typeof(TId), newValue)!;
            }

            throw new UnsupportedIdAutoGenerationException(typeof(TValue).Name);
        }

        public static TId Rehydrate<TId>(TValue value) where TId : Id<TValue>
        {
            return (TId)Activator.CreateInstance(typeof(TId), value)!;
        }
    }
}
