using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository productRepo;

        public GetAllProductsHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepo.GetAllProductsAsync();                  
        }
    }
}
