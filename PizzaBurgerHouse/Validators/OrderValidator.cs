using FluentValidation;
using PizzaBurgerHouse.Domain.Entities;

namespace PizzaBurgerHouse.Validators
{
    public class OrderValidator: AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerName).NotNull();
            RuleFor(x => x.CustomerPhoneNumber).NotNull();
            RuleFor(x => x.Products).NotNull();
            RuleFor(x => x.DeliveryOrder).NotNull();
            RuleFor(x => x.PaymentMethod).NotNull();    
        }
    }
}
