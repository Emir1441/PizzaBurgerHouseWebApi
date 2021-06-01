using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries.OrderQueries
{
    public class GetAllDeliveryOrders : IRequest<IEnumerable<Order>> {}
    public class GetAllDeliveryOrdersQueryHandler : IRequestHandler<GetAllDeliveryOrders, IEnumerable<Order>>
    {

        private readonly IOrderRepository orderRepo;
        public GetAllDeliveryOrdersQueryHandler(IOrderRepository _orderRepo)
        {
            orderRepo = _orderRepo;
        }
        public async Task<IEnumerable<Order>> Handle(GetAllDeliveryOrders request, CancellationToken cancellationToken)
        {
            return await orderRepo.GetAllDeliveryOrdersAsync();
        }
    }
}
