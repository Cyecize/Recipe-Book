using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public interface IRecipeService
    {
        Task<Recipe> CreateRecipe(User owner, string title, string content, Dictionary<string, double> ingredients);

        Task<List<Recipe>> FindByUser(User owner);

        Task<List<Recipe>> Search(RecipeSearchQuery query);
    }
}
