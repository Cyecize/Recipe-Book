using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IDataService<Ingredient, long> _dataService;

        public IngredientService(IDataService<Ingredient, long> dataService)
        {
            this._dataService = dataService;
        }

        public async Task<List<Ingredient>> FindByRecipe(Recipe recipe)
        {
            return await this._dataService.FindBy(ingredient => ingredient.RecipeId == recipe.Id);
        }

        public async Task<bool> Remove(List<Ingredient> ingredients)
        {
            return await this._dataService.DeleteAll(ingredients);
        }
    }
}
