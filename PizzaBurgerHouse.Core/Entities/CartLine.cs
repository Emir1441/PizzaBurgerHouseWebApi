namespace PizzaBurgerHouse.Domain.Entities
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }  
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
