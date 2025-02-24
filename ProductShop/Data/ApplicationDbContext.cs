using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.PurchasePrice)
                .HasColumnType("decimal(18,4)"); // Định dạng chính xác cho decimal

            modelBuilder.Entity<Product>()
                .Property(p => p.SalePrice)
                .HasColumnType("decimal(18,4)");
        }
    }
}
