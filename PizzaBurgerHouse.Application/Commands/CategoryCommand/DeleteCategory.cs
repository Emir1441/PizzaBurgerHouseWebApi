using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.CategoryCommand
{
    public class DeleteCategory : IRequest<Unit>
    {

        public int Id { get; set; }
        public DeleteCategory(int id)
        {
            Id = id;
        }
    }
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategory, Unit>
        {
        private readonly ICategoryRepository categoryRepo;
        public DeleteCategoryCommandHandler(ICategoryRepository _categoryRepo)
        {
                categoryRepo = _categoryRepo;
        }
        public async Task<Unit> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
              await categoryRepo.DeleteCategoryAsync(request.Id);
              return Unit.Value;
        }
    }
}
