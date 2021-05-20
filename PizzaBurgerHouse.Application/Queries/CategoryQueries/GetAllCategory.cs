using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries.CategoryQueries
{
   public class GetAllCategory : IRequest<IEnumerable<Category>> 
    {

    }

    public class GetAllCategoryHandler : IRequestHandler<GetAllCategory, IEnumerable<Category>>
    {
        private readonly ICategoryRepository categoryRepo;

        public GetAllCategoryHandler(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }
        public async Task<IEnumerable<Category>> Handle(GetAllCategory request, CancellationToken cancellationToken)
        {
            return await categoryRepo.GetAllCategoryAsync();
        }
    }
}
