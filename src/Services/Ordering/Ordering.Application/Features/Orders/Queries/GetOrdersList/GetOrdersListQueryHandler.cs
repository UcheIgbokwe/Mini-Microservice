using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;

namespace src.Services.Ordering.Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;

        }
        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}