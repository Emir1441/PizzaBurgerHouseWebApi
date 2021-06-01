namespace PizzaBurgerHouse.Domain.Entities
{
    public class DeliveryOrder
    {
        public int DeliveryOrderId { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerHouseNumber { get; set; }
        public string CustomerApartmentNumber { get; set; }
        public string CustomerEntranceNumber { get; set; }
    }
}
