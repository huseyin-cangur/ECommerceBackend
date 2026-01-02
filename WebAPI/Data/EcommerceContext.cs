using Microsoft.EntityFrameworkCore;
using WebAPI.Entity;

namespace WebAPI.Data
{
    public class ECommerceContext : DbContext
    {

        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Sample Product 1",
                        Description = "This is a sample product description.",
                        Price = 19.99M,
                        Stock = 100,
                        ImageUrl = "https://example.com/sample-product-1.jpg",
                        IsActive = true
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Sample Product 2",
                        Description = "This is another sample product description.",
                        Price = 29.99M,
                        Stock = 50,
                        ImageUrl = "https://example.com/sample-product-2.jpg",
                        IsActive = true
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Sample Product 3",
                        Description = "This is yet another sample product description.",
                        Price = 9.99M,
                        Stock = 200,
                        ImageUrl = "https://example.com/sample-product-3.jpg",
                        IsActive = true
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Sample Product 4",
                        Description = "This is a fourth sample product description.",
                        Price = 49.99M,
                        Stock = 30,
                        ImageUrl = "https://example.com/sample-product-4.jpg",
                        IsActive = true
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Sample Product 5",
                        Description = "This is a fifth sample product description.",
                        Price = 15.99M,
                        Stock = 150,
                        ImageUrl = "https://example.com/sample-product-5.jpg",
                        IsActive = false
                    }

                }
            );
        }


        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();

    }
}