using CategoryModels;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;



namespace CategoryServices.Data   // <--- Important: use a proper namespace,
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        //using override (OnModelCreating)   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },

                new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },

                new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                new Category { CategoryID = 4, CategoryName = "Dairy", Description = "Cheeses" },
                new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },

                new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
                new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },

                new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
            );
        }
    }
}