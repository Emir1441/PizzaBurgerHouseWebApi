using Microsoft.EntityFrameworkCore;
using PizzaBurgerHouse.Domain.Entities;

namespace PizzaBurgerHouse.Infrastructure.Data
{
    public class MyApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<DeliveryOrder> Deliveries { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UploadImage> UploadImage { get; set; }

      

        public MyApplicationContext(DbContextOptions<MyApplicationContext> options) : base(options) { }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account { AccountId = 1, Login = "admin@mail.ru", Password = "123456", Role="admin" });
                
              
        }


    }
}
