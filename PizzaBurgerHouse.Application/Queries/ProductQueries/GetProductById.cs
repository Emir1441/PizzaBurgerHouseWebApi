using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries
{
    public class GetProductById: IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductById(int id)
        {
            Id = id;
        }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductById, Product>
    {
        private readonly IProductRepository productRepo;
        public GetProductByIdQueryHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }
        public Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
          return productRepo.GetProductByIdAsync(request.Id);    
        }
    }
}
