



namespace Basket.API.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can't be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is requires");

        }
    }
    public class handle(IBasketRepository _repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            //ShoppingCart cart = command.Cart;
            await _repository.StoreBasket(command.Cart);
            //TODO:Store basket in database
            //TODO:update cache
            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
