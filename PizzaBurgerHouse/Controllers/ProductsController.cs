using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBurgerHouse.Application.Commands.ImageCommand;
using PizzaBurgerHouse.Application.Commands.ProductCommand;
using PizzaBurgerHouse.Application.Queries;
using PizzaBurgerHouse.Domain.Entities;
using PizzaBurgerHouse.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator mediator;

      

        public ProductsController( IMediator _mediator, MyApplicationContext context)
        {        
            mediator = _mediator;
           
        }












        [HttpGet]    
        public async Task<IEnumerable<Product>> GetProducsAsync()
        {
          return await mediator.Send(new GetAllProductsQuery());        
        }



        [HttpGet("{id}")]
        //[Authorize]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await mediator.Send(new GetProductByIdQuery(id));
        }



        [HttpPost]
        public async Task AddProductAsync(Product product) //
        {
            await mediator.Send(new CreateProduct(product));

        }


     







        [HttpDelete("{id}")]
        //[Authorize]
        public async Task DeleteProductAsync(int id)
        {
            await mediator.Send(new DeleteProduct(id));
        }



        [HttpPatch]
        //[Authorize]
        public async Task UpdateProductAsync(Product product)
        {

            await mediator.Send(new UpdateProduct(product));
        }



                        
        [HttpPost("upload")]
        //[Authorize]
        public async Task<int> AddImageAsync(IFormFile uploadedFile)
        {
            return await mediator.Send(new AddImage(uploadedFile));
        }
    }
}
                            