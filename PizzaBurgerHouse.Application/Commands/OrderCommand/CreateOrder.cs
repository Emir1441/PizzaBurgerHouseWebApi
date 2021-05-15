using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.OrderCommand
{
    public class CreateOrder : IRequest<OrderConfirmation>
    {
       
        public Order Order { get; set; }

        public CreateOrder(Order order)
        {
            Order = order;
        }
     
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrder, OrderConfirmation>
    {

        private readonly IOrderRepository ordertRepo;
        public CreateOrderCommandHandler(IOrderRepository _orderRepo)
        {
            ordertRepo = _orderRepo;
        }

        public async Task<OrderConfirmation> Handle(CreateOrder request, CancellationToken cancellationToken)
        {


         return  await ordertRepo.CreateOrderAsync(request.Order);
        
        }
    }
}
