using Microsoft.AspNetCore.Http;
using PizzaBurgerHouse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Dto
{
   public class ProductDto
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
