
namespace RecipeBook.Domain.Models
{
    public class Ingredient
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public Recipe Recipe { get; set; }
    }
}
