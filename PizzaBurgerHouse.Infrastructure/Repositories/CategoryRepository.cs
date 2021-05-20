using Microsoft.EntityFrameworkCore;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using PizzaBurgerHouse.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyApplicationContext db;
        public CategoryRepository(MyApplicationContext context)
        {
            db = context;
        }


        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await db.Categories.AsNoTracking().ToListAsync();
        }


        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await db.Categories.FirstOrDefaultAsync(category => category.CategoryId == id);
        }



        public async Task<IEnumerable<Product>> GetAllProductsByIdCategoryAsync(int id)
        {
            return await db.Products.Where(x => x.CategoryId == id).Include(x => x.UploadImage).ToListAsync();
        }


        public async Task CreateCategoryAsync(Category category)
        {
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync( Category category)
        {


           


             db.Categories.Update(category);
            await db.SaveChangesAsync();
        }


        public async Task DeleteCategoryAsync(int id)
        {
            var category = await db.Categories.FirstOrDefaultAsync(category => category.CategoryId == id);
             db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }      
    }
}
