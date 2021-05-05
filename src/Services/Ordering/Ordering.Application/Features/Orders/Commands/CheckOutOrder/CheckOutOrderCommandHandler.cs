using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using src.Services.Ordering.Ordering.Application.Contracts.Infrastructure;
using src.Services.Ordering.Ordering.Application.Contracts.Persistence;
using src.Services.Ordering.Ordering.Application.Models;
using src.Services.Ordering.Ordering.Domain.Entities;

namespace src.Services.Ordering.Ordering.Application.Features.Orders.Commands.CheckOutOrder
{
    public class CheckOutOrderCommandHandler : IRequestHandler<CheckOutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckOutOrderCommandHandler> _logger;

        public CheckOutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<CheckOutOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
            _orderRepository = orderRepository;

        }
        public async Task<int> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            await SendMail(newOrder);

            return newOrder.Id;
        }

        private async Task SendMail(Order newOrder)
        {
            var email = new Email()
            {
                To = "uchehenryigbokwe@gmail.com",
                Body = "Order was created",
                Subject = "Order Dispatch"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (System.Exception ex)
            {
                 _logger.LogError($"Order {newOrder.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}