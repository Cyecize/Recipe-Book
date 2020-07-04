using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Models;

namespace RecipeBook.EntityFramework
{
    public class RecipeBookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: import the connection string!
            //optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["recipe_book_db"].ConnectionString);
            optionsBuilder.UseMySQL(
                "server=localhost;database=recipe_book_db;user=root;password=toor"
            );

            base.OnConfiguring(optionsBuilder);
        }
    }
}
