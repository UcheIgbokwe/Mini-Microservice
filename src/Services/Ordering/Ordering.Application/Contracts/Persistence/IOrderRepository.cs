using System.Collections.Generic;
using System.Threading.Tasks;
using src.Services.Ordering.Ordering.Domain.Entities;

namespace src.Services.Ordering.Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string username);
    }
}