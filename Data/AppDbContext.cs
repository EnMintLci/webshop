using Microsoft.EntityFrameworkCore;

using Webshop.Models;

namespace Webshop.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        
    }

}
