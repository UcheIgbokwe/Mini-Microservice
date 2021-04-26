using AutoMapper;
using Discount.Grpc.Protos;
using src.Services.Discount.Discount.Grpc.Entities;

namespace src.Services.Discount.Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}