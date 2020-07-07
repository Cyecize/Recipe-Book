using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> FindByRecipe(Recipe recipe);

        Task<bool> Remove(List<Ingredient> ingredients);
    }
}
