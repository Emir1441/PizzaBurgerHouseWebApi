using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries.CategoryQueries
{
    public  class GetAllProductsByIdCategory: IRequest<IEnumerable<Product>>
    {
        public int Id { get; set; }
        public GetAllProductsByIdCategory(int id)
        {
            Id = id;
        }
    }
    public class GetAllProductsByIdCategoryHandler : IRequestHandler<GetAllProductsByIdCategory, IEnumerable<Product>>
    {
        private readonly ICategoryRepository categoryRepo;
        public GetAllProductsByIdCategoryHandler(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsByIdCategory request, CancellationToken cancellationToken)
        {
            return await categoryRepo.GetAllProductsByIdCategoryAsync(request.Id);
        }
    }
}
