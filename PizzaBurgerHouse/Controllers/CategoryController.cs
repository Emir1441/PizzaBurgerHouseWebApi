using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBurgerHouse.Application.Commands.CategoryCommand;
using PizzaBurgerHouse.Application.Queries.CategoryQueries;
using PizzaBurgerHouse.Domain.Entities;
using PizzaBurgerHouse.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
       

        public CategoryController(IMediator _mediator)
        {
            mediator = _mediator;
           
        }

        [HttpGet]   
        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await mediator.Send(new GetAllCategory());
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await mediator.Send(new GetCategoryById(id));
        }


        [HttpGet("product/{id}")]
        public async Task<IEnumerable<Product>> GetCategoryByIdAndProduct(int id)
        {
            return await mediator.Send(new GetAllProductsByIdCategory(id));
        }



        [HttpPost]
        [Authorize]
        public async Task AddCategoryAsync(Category category) 
        {
            await mediator.Send(new CreateCategory(category));

        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task DeleteCategoryAsync(int id)
        {
            await mediator.Send(new DeleteCategory(id));
        }


        [HttpPatch]
        [Authorize]
        public async Task UpdateCategoryAsync(Category category)
        {

            await mediator.Send(new UpdateCategory(category));
        }


    }
}
 