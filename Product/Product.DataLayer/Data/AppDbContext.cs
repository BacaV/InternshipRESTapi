using Microsoft.EntityFrameworkCore;
using Product.Datalayer.Model;

namespace Product.Datalayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
    }
}
