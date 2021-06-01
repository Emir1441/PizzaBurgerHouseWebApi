using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBurgerHouse.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float? Price { get; set; }
        public int? ProductWeight { get; set; }
        [NotMapped]
        public IFormFile UploadedFile { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
