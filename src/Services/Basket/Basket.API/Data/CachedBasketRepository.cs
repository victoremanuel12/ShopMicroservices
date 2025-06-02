
namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository _repository) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            return await _repository.GetBasket(userName, cancellationToken);
        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            return _repository.StoreBasket(basket, cancellationToken);
        }
        public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteBasket(userName, cancellationToken);
        }

    }
}
