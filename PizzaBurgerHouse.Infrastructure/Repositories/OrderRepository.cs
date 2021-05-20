using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using PizzaBurgerHouse.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly  MyApplicationContext db;
        private readonly IMapper mapper;
 

        public OrderRepository(MyApplicationContext context, IMapper _mapper)
        {
            db = context;
            mapper = _mapper;
        }

        public async Task<IEnumerable<Order>> GetAllDeliveryOrdersAsync()
        {
           
            return await db.Orders.AsNoTracking().OrderByDescending(x => x.CreateOrder).Include(x => x.PaymentMethod)
                .Include(x => x.DeliveryOrder).Include(x => x.Products).AsNoTracking().ToListAsync();

        }


        public async Task<Order> GetDeliveryOrderByIdAsync(int id)
        {
           return await db.Orders.AsNoTracking().Include(x => x.Products).AsNoTracking().FirstOrDefaultAsync(x => x.OrderId == id);
        }

 
        public async Task<OrderConfirmation> CreateOrderAsync(Order order)
        {
            order.PaymentMethod.TotalPrice = GetPrice(order.Products);
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            var orderConfirmation = mapper.Map<OrderConfirmation>(order);
            return orderConfirmation;  

        }

        private float GetPrice(IEnumerable<CartLine> lines)
        {
            IEnumerable<int> ids = lines.Select(l => l.ProductId);
            IEnumerable<Product> prods
                = db.Products.Where(p => ids.Contains(p.ProductId));
            return (float)prods.Select(p => lines
                    .First(l => l.ProductId == p.ProductId).Quantity * p.Price)
                .Sum();
        }

    }
}
