using System.Collections.Generic;
using Shopping.Aggregator.Models;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public interface IOrderService
    {
       Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);

    }
}