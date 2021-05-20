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
  public  class UpdateCategory: IRequest<Unit>
    {
        public Category Category { get; set; }

        public UpdateCategory(Category  category)
        {
            Category = category;
        }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategory, Unit>
    {
        private readonly ICategoryRepository categoryRepo;
        public UpdateCategoryCommandHandler(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }


        public async Task<Unit> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            await categoryRepo.UpdateCategoryAsync(request.Category);
            return Unit.Value;
        }
    }

}
