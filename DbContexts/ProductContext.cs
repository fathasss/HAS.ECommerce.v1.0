using HasMicroService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace HasMicroService.DbContexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>()
                .Property(p => p.PriceUSD)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>()
                .Property(p => p.PriceEUR)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Currency>()
            .Property(c => c.Ratio)
            .HasColumnType("decimal(18, 6)");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic Items",
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Dresses",
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery Items",
                }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory
                {
                    Id = 1,
                    Name = "Phone",
                    Description = "Phone Items",
                    CategoryId = 1
                },
                new SubCategory
                {
                    Id = 2,
                    Name = "Computer",
                    Description = "Notebook Items",
                    CategoryId = 1
                },
                new SubCategory
                {
                    Id = 3,
                    Name = "TV",
                    Description = "TV Items",
                    CategoryId = 1
                }
            );

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = Convert.ToInt32(CurrencyItem.TR),
                    Name = "Turkish Lira",
                    Ratio = 1,
                    Symbol = "₺"
                },
                new Currency
                {
                    Id = Convert.ToInt32(CurrencyItem.EUR),
                    Name = "Euro",
                    Ratio = 31,
                    Symbol = "€"
                },
                new Currency
                {
                    Id = Convert.ToInt32(CurrencyItem.USD),
                    Name = "USD",
                    Ratio = 28,
                    Symbol = "$"
                }
            );
        }
    }
}
