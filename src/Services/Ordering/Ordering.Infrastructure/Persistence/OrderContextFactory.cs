using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace src.Services.Ordering.Ordering.Infrastructure.Persistence
{
    public class OrderContextFactory : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=OrderDb;User Id=sa;Password=Ebubechi89;");

            return new OrderContext(optionsBuilder.Options);
        }
    }
}