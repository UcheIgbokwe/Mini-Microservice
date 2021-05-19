using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using src.Services.Ordering.Ordering.Domain.Entities;

namespace src.Services.Ordering.Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreConfiguredOrder());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associate with {typeof(OrderContext).Name} successful.");
            }
        }

        private static IEnumerable<Order> GetPreConfiguredOrder()
        {
            return new List<Order>
            {
                new Order() {UserName = "uche", FirstName = "Uche", LastName = "Igbokwe", EmailAddress = "u@gmail.com", AddressLine = "Lekki", Country = "Nigeria", TotalPrice = 350}
            };
        }
    }
}