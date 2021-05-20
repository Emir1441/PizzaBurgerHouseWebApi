using MediatR;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Queries.CategoryQueries
{
   public class GetCategoryById : IRequest<Category>
    {
        public int Id { get; set; }
        public GetCategoryById(int id)
        {
            Id = id;
        }
    } 



    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, Category>
    {
        private readonly ICategoryRepository categoryRepo;

        public GetCategoryByIdHandler(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }

        public Task<Category> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            return categoryRepo.GetCategoryByIdAsync(request.Id);

        }
    }
}
