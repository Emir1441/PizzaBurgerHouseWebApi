using AutoMapper;
using PizzaBurgerHouse.Application.Dto;
using PizzaBurgerHouse.Domain.Entities;

namespace PizzaBurgerHouse.Infrastructure.Mapper
{
    public  class ObjectsMapper : Profile
    {
        public ObjectsMapper()
        {
            CreateMap<Order, OrderConfirmation>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(x => x.OrderId))
                .ForMember(dest => dest.OrderName, opt => opt.MapFrom(x => x.CustomerName))
                .ForMember(dest => dest.OrderPhone, opt => opt.MapFrom(x => x.CustomerPhoneNumber))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.PaymentMethod.TotalPrice));
            CreateMap<ProductDto, Product>()
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(x => x.ProductId))
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(x => x.ProductName))
                    .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(x => x.ProductDescription))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Price))
                    .ForMember(dest => dest.ProductWeight, opt => opt.MapFrom(x => x.ProductWeight))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                    .ForMember(dest => dest.Path, opt => opt.MapFrom(x => x.Path))
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => x.CategoryId));
        }
    }
}
