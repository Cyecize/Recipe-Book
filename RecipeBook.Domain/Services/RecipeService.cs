using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IDataService<Recipe, long> _dataService;


        public RecipeService(IDataService<Recipe, long> dataService)
        {
            this._dataService = dataService;
        }

        public async Task<Recipe> CreateRecipe(User owner, string title, string content, Dictionary<string, double> ingredients)
        {
            Recipe recipe = new Recipe()
            {
                CreatedById = owner.Id,
                Title = title,
                Content = content,
                DateAdded = DateTime.Now
            };

            recipe.Ingredients = ingredients.Keys.Select(name => new Ingredient()
            {
                Name = name,
                Quantity = ingredients[name],
                Recipe = recipe
            }).ToList();

            await this._dataService.Create(recipe);

            return recipe;
        }
    }
}
