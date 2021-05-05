using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;
using src.Services.Ordering.Ordering.Application.Exceptions;
using src.Services.Ordering.Ordering.Domain.Entities;

namespace src.Services.Ordering.Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _orderRepository = orderRepository;

        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if(orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
                //_logger.LogError("Order does not exist");
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(orderToUpdate);
            _logger.LogInformation($"Order {request.Id} has been updated.");

            return Unit.Value;
        }
    }
}