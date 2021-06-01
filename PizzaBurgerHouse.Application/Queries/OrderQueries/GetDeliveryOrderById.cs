using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries.OrderQueries
{
    public class GetDeliveryOrderById:  IRequest<Order>
    {
        public int Id { get; set; }
        public GetDeliveryOrderById(int id)
        {
            Id = id;
        }
    }
    public class GetDeliveryOrderByIdHandler : IRequestHandler<GetDeliveryOrderById, Order>
    {
        private readonly IOrderRepository orderRepo;
        public GetDeliveryOrderByIdHandler(IOrderRepository _orderRepo)
        {
             orderRepo = _orderRepo;
        }
        public async Task<Order> Handle(GetDeliveryOrderById request, CancellationToken cancellationToken)
        {
            return await orderRepo.GetDeliveryOrderByIdAsync(request.Id);
        }
    }
}
