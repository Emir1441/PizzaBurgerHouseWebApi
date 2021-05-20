using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries
{
    public class GetAllProducts : IRequest<IEnumerable<Product>>
    {

    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<Product>>
    {
        private readonly IProductRepository productRepo;

        public GetAllProductsHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return await productRepo.GetAllProductsAsync();                  
        }
    }
}
