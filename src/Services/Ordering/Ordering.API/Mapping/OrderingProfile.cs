using AutoMapper;
using EventBus.Messages.Events;
using src.Services.Ordering.Ordering.Application.Features.Orders.Commands.CheckOutOrder;

namespace Ordering.API.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckOutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}