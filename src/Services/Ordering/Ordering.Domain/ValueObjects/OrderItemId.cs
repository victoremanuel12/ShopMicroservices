namespace Ordering.Domain.ValueObjects
{
    public record OrderItemId : Id<Guid>
    {
        //construtor sendo chamado em tempo de execução pelo Activator.CreateInstance da classe base
        private OrderItemId(Guid value) : base(value){}
        public static OrderItemId New() => New<OrderItemId>();
        public static OrderItemId Rehydrate(Guid value) => Rehydrate<OrderItemId>(value);

    }
}
