namespace PizzaBurgerHouse.Domain.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
