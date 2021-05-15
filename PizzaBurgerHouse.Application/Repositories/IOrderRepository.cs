using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllDeliveryOrdersAsync();
        Task<Order> GetDeliveryOrderByIdAsync(int id);
        Task<OrderConfirmation> CreateOrderAsync(Order order);         
    }
}
