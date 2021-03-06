using FluentValidation;
using PizzaBurgerHouse.Application.Dto;

namespace PizzaBurgerHouse.Validators
{
    public class LoginValidator: AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull().Length(0,6);
        }
    }
}
