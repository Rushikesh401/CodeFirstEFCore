
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFCore.Models


{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)  
        {
            
        }

        public DbSet<Product> Products { get; set; } 
    }
}
