using Microsoft.EntityFrameworkCore;
using WebAPI.Entity;

namespace WebAPI.Data
{
    public class ECommerceContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
    }
}