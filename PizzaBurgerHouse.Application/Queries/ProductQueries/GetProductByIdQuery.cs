using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries
{
    public class GetProductByIdQuery: IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository productRepo;

        public GetProductByIdQueryHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
          return productRepo.GetProductByIdAsync(request.Id);
           
        }
    }
}
