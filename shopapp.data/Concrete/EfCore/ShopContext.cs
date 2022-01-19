using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class ShopContext :DbContext
    {
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=shopDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
            .HasKey(c=>new{c.CategoryId,c.ProductId});
        }
    }
}