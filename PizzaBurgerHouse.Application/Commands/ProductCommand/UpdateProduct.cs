using MediatR;
using PizzaBurgerHouse.Application.Dto;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.ProductCommand
{
    public class UpdateProduct: IRequest<Unit>
    {
        public ProductDto Product { get; set; }
        public UpdateProduct(ProductDto product)
        {
            Product = product;
        }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProduct, Unit>
    {

        private readonly IProductRepository productRepo;
        public UpdateProductCommandHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }
        public async Task<Unit> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {           
            await productRepo.UpdateProductAsync(request.Product);
            return Unit.Value;
        }
    }
}
