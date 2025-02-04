using Microsoft.EntityFrameworkCore;
using BlazorWebShop.Models;

namespace BlazorWebShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Här använder vi Fluent API för att konfigurera primärnyckeln
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurera primärnyckeln för Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
