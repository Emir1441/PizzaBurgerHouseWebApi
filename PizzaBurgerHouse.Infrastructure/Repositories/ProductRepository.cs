using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using PizzaBurgerHouse.Infrastructure.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyApplicationContext db;
        private readonly IWebHostEnvironment _appEnvironment;
        public ProductRepository(MyApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;

        }


        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {   
            return await db.Products.Include(x => x.UploadImage).ToListAsync(); 
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {      
            return await db.Products.Include(x => x.UploadImage).FirstOrDefaultAsync(product => product.ProductId == id);
        }


        public async Task CreateProductAsync(Product product)
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
        }



        public async Task UpdateProductAsync( Product product)
        {    
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {      
            var quare = await db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            db.Products.Remove(quare);
            await db.SaveChangesAsync();
        }


        public async Task<int> AddImageAsync(IFormFile uploadedFile)
        {
            // путь к папке Files
            string path = "/Images/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            UploadImage file = new UploadImage { Name = uploadedFile.FileName, Path = path };
            db.UploadImage.Add(file);
            await db.SaveChangesAsync();
            return file.UploadImageId;
        }

    }
}
