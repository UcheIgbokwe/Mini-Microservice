using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Mappings;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;

namespace src.Services.Ordering.Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, IEnumerable<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }
        public async Task<IEnumerable<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
            return OrderMapper.Mapper.Map<IEnumerable<OrdersVm>>(orderList);
        }
    }
}