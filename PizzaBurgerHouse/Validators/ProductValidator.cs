using FluentValidation;
using PizzaBurgerHouse.Domain.Entities;

namespace PizzaBurgerHouse.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(x => x.ProductType).NotNull();
            //RuleFor(x => x.ProductName).NotNull();
            //RuleFor(x => x.ProductDescription).NotNull();
            //RuleFor(x => x.Price).NotNull();
            //RuleFor(x => x.ProductWeight).NotNull();
            //RuleFor(x => x.UploadImageId).NotNull();
        }

    }
}
