using System.Collections.Generic;
using MediatR;

namespace src.Services.Ordering.Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<IEnumerable<OrdersVm>>
    {
        public string UserName { get; set; }

        public GetOrdersListQuery(string userName)
        {
            UserName = userName;
        }
    }
}