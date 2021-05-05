using AutoMapper;
using src.Services.Ordering.Ordering.Application.Features.Orders.Commands.CheckOutOrder;
using src.Services.Ordering.Ordering.Application.Features.Orders.Commands.UpdateOrder;
using src.Services.Ordering.Ordering.Application.Features.Orders.Queries.GetOrdersList;
using src.Services.Ordering.Ordering.Domain.Entities;

namespace src.Services.Ordering.Ordering.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckOutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}