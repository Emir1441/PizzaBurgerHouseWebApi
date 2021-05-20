using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaBurgerHouse.Application.Commands.OrderCommand;
using PizzaBurgerHouse.Application.Queries.OrderQueries;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediatr;
        public OrderController(IMediator _mediatr)
        {
            mediatr = _mediatr;
          
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Order>> GetAllDeliveryOrdersAsync()
        {
            return await mediatr.Send(new GetAllDeliveryOrders());
        }

       
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Order> GetAllDeliveryOrderByIdAsync(int id)
        {
            return await mediatr.Send(new GetDeliveryOrderById(id));
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<OrderConfirmation> CreateOrderAsync(Order order)
        {       
            return await mediatr.Send(new CreateOrder(order));
        }
    }
}
