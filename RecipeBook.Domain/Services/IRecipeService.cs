using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public interface IRecipeService
    {
        Task<Recipe> CreateRecipe(User owner, string title, string content, Dictionary<string, double> ingredients);
    }
}
