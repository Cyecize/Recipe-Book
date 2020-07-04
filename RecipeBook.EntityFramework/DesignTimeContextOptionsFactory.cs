using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipeBook.EntityFramework
{
    public class DesignTimeContextOptionsFactory : IDesignTimeDbContextFactory<RecipeBookDbContext>
    {
        public RecipeBookDbContext CreateDbContext(string[] args)
        {
            //TODO: import the connection string!
            //optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["recipe_book_db"].ConnectionString);
            var optionsBuilder = new DbContextOptionsBuilder<RecipeBookDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;database=recipe_book_db;user=root;password=toor"
            );

            return new RecipeBookDbContext(optionsBuilder.Options);
        }
    }
}
