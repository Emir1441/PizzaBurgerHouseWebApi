using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaBurgerHouse.Application.Commands.ProductCommand;
using PizzaBurgerHouse.Application.Dto;
using PizzaBurgerHouse.Application.Queries;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController( IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpGet]    
        public async Task<IEnumerable<Product>> GetAllProducsAsync()
        {
          return await mediator.Send(new GetAllProducts());        
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await mediator.Send(new GetProductById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task AddProductAsync([FromForm]Product product) 
        {
            await mediator.Send(new CreateProduct(product));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task DeleteProductAsync(int id)
        {
            await mediator.Send(new DeleteProduct(id));
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public async Task UpdateProductAsync([FromForm]ProductDto product)
        {

            await mediator.Send(new UpdateProduct(product));
        }                   
    }
}
                            