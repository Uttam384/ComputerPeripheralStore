using Microsoft.EntityFrameworkCore;
using ComputerPeripheralStore.Models;

namespace ComputerPeripheralStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Peripheral> Peripherals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure decimal precision for Price
            modelBuilder.Entity<Peripheral>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // 18 total digits, 2 decimal places

            // Seed some initial data with static dates
            modelBuilder.Entity<Peripheral>().HasData(
                new Peripheral
                {
                    Id = 1,
                    Name = "Mechanical Keyboard",
                    Category = "Keyboard",
                    QuantityInStock = 10,
                    Price = 89.99m,
                    AddedDate = new DateTime(2024, 1, 15, 10, 0, 0) // Static date
                },
                new Peripheral
                {
                    Id = 2,
                    Name = "Gaming Mouse",
                    Category = "Mouse",
                    QuantityInStock = 15,
                    Price = 49.99m,
                    AddedDate = new DateTime(2024, 1, 15, 10, 0, 0) // Static date
                },
                new Peripheral
                {
                    Id = 3,
                    Name = "4K Monitor",
                    Category = "Monitor",
                    QuantityInStock = 5,
                    Price = 299.99m,
                    AddedDate = new DateTime(2024, 1, 15, 10, 0, 0) // Static date
                }
            );
        }
    }
}