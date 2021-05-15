using AutoMapper;
using PizzaBurgerHouse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Infrastructure.Mapper
{
  public  class ObjectsMapper : Profile
    {
        public ObjectsMapper()
        {
            CreateMap<Order, OrderConfirmation >()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(x => x.OrderId))
                .ForMember(dest => dest.OrderName, opt => opt.MapFrom(x => x.CustomerName))
                .ForMember(dest => dest.OrderPhone, opt => opt.MapFrom(x => x.CustomerPhoneNumber))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.PaymentMethod.TotalPrice));

            
           
        }
    }
}
