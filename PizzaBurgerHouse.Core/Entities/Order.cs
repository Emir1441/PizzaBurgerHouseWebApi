using System;
using System.Collections.Generic;

namespace PizzaBurgerHouse.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreateOrder { get; set; } = DateTime.Now;
        public IEnumerable<CartLine> Products { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
