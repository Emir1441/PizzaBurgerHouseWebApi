using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.ProductCommand
{
    public class CreateProduct : IRequest<Unit>
    {
       
       public Product Product { get; set; }

        public CreateProduct(Product product)
        {
            Product = product;
        }
     
    }


    public class CreateProductCommandHandler : IRequestHandler<CreateProduct, Unit>
    {
        private readonly IProductRepository productRepo;

        public CreateProductCommandHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }
        public async Task<Unit> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
     

            await productRepo.CreateProductAsync(request.Product);

            return  Unit.Value;
        }

             
        
    }
}
