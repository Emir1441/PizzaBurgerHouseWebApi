namespace PizzaBurgerHouse.Domain.Entities
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float? Price { get; set; }
        public int? ProductWeight { get; set; }
        public int UploadImageId { get; set; }
        public UploadImage UploadImage { get; set; } ///Add new property
    }
}
