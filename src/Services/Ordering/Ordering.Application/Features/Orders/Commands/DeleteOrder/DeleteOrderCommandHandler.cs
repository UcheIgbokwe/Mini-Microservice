using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;
using src.Services.Ordering.Ordering.Application.Exceptions;
using src.Services.Ordering.Ordering.Domain.Entities;

namespace src.Services.Ordering.Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
        {
            _logger = logger;
            _orderRepository = orderRepository;

        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
            if(orderToDelete == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
                //_logger.LogError("Order does not exist in the database.");
            }
            await _orderRepository.DeleteAsync(orderToDelete);

            return Unit.Value;
        }
    }
}