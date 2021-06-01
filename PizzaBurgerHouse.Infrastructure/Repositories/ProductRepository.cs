using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PizzaBurgerHouse.Application.Dto;
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
        private readonly IMapper mapper;
        public ProductRepository(MyApplicationContext context, IWebHostEnvironment appEnvironment, IMapper _mapper)
        {
            db = context;
            _appEnvironment = appEnvironment;
            mapper = _mapper;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
        }

        public async Task CreateProductAsync(Product product)
        {        
            string path = "/Images/" + product.UploadedFile.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await product.UploadedFile.CopyToAsync(fileStream);
            }
            var productModel = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                ProductWeight = product.ProductWeight,
                Name = product.UploadedFile.FileName,
                Path = path,
                CategoryId = product.CategoryId
            };
            await db.Products.AddAsync(productModel);
            await db.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(ProductDto productDto)
        {
            if (productDto.UploadedFile != null)
            {
                string path = "/Images/" + productDto.UploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await productDto.UploadedFile.CopyToAsync(fileStream);
                }
                var productModel = new Product
                {
                    ProductId = productDto.ProductId,
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    ProductWeight = productDto.ProductWeight,
                    Name = productDto.UploadedFile.FileName,
                    Path = path,
                    CategoryId = productDto.CategoryId
                };
                db.Products.Update(productModel);
                await db.SaveChangesAsync();
            }
            else
            {     
                var productModel = mapper.Map<Product>(productDto);
                db.Products.Update(productModel);
                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteProductAsync(int id)
        {
            var quare = await db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            db.Products.Remove(quare);
            await db.SaveChangesAsync();
        }

     
    }
}
