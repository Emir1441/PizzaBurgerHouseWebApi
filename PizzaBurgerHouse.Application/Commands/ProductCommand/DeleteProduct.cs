using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.ProductCommand
{
    public class DeleteProduct: IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteProduct(int id)
        {
            Id = id;
        }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProduct, Unit>
    {
        private readonly IProductRepository productRepo;
        public DeleteProductCommandHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }
        public async Task<Unit> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            await productRepo.DeleteProductAsync(request.Id);
            return Unit.Value;
        }
    }
}
