using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsByIdCategoryAsync(int id);
        Task CreateCategoryAsync(Category category);   
        Task UpdateCategoryAsync(Category categoryModel);
        Task DeleteCategoryAsync(int id);
    }
}
