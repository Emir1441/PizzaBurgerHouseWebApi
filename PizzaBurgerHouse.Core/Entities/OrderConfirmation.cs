namespace PizzaBurgerHouse.Domain.Entities
{
    public class OrderConfirmation
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string OrderPhone { get; set; }
        public float Amount { get; set; }
    }
}
