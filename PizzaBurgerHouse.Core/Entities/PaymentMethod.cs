namespace PizzaBurgerHouse.Domain.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string PaymentType { get; set; }
        public float TotalPrice { get; set; }
    }
}
