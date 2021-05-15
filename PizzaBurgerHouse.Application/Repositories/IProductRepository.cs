using Microsoft.AspNetCore.Http;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<int> AddImageAsync(IFormFile uploadedFile);


    }
}
