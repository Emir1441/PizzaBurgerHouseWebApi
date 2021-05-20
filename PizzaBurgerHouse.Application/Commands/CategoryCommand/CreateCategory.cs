using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.CategoryCommand
{
   public class CreateCategory : IRequest<Unit>
    {
        public Category Category { get; set; }
        public CreateCategory(Category category)
        {
            Category = category;
        }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategory, Unit>
    {
        private readonly ICategoryRepository categoryRepo;
        public CreateCategoryCommandHandler(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }
        public async Task<Unit> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            await categoryRepo.CreateCategoryAsync(request.Category);
            return Unit.Value;
        }
    }
}
