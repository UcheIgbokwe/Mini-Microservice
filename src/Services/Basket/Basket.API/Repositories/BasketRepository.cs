using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using src.Services.Basket.Basket.API.Entities;

namespace src.Services.Basket.Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName).ConfigureAwait(false);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket)).ConfigureAwait(false);

            return await GetBasket(basket.UserName).ConfigureAwait(false);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName).ConfigureAwait(false);
        }
    }
}