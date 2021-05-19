using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;
using src.Services.Ordering.Ordering.Domain.Entities;
using src.Services.Ordering.Ordering.Infrastructure.Persistence;

namespace src.Services.Ordering.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string username)
        {
            var orderList = await _dbContext.Orders.Where(o => o.UserName == username).ToListAsync();

            return orderList;
        }
    }
}