using System.Threading.Tasks;
using src.Services.Basket.Basket.API.Entities;

namespace src.Services.Basket.Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}