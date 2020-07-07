using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IDataService<Recipe, long> _dataService;

        private readonly IIngredientService _ingredientService;


        public RecipeService(IDataService<Recipe, long> dataService, IIngredientService ingredientService)
        {
            this._dataService = dataService;
            this._ingredientService = ingredientService;
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

        public async Task<Recipe> EditRecipe(Recipe recipe, Dictionary<string, double> ingredients)
        {
            await this._ingredientService.Remove(await this._ingredientService.FindByRecipe(recipe));

            recipe.Ingredients = ingredients.Keys.Select(name => new Ingredient()
            {
                Name = name,
                Quantity = ingredients[name],
                Recipe = recipe
            }).ToList();

            await this._dataService.Update(recipe);

            return recipe;
        }

        public async Task<List<Recipe>> FindByUser(User owner)
        {
            return await this._dataService.FindBy(
                recipe => recipe.CreatedById == owner.Id,
                new Expression<Func<Recipe, object>>[]
                {
                    recipe => recipe.CreatedBy,
                    recipe => recipe.Ingredients
                }
                );
        }

        public async Task<List<Recipe>> Search(RecipeSearchQuery query)
        {
            return await this._dataService.FindBy(
                recipe =>
                {
                    bool isMatch = true;
                    if (query.OwnerName != null)
                        isMatch = recipe.CreatedBy.Username.ToLower().Contains(query.OwnerName.ToLower());

                    if (query.Global != null)
                    {
                        string q = query.Global.ToLower();
                        bool globalMatch = recipe.Title.ToLower().Contains(q)
                                           || recipe.Content.ToLower().Contains(q)
                                           || recipe.Ingredients.Any(
                                               ingredient => ingredient.Name.ToLower().Contains(q));

                        isMatch = isMatch && globalMatch;
                    }

                    return isMatch;
                },
                new Expression<Func<Recipe, object>>[]
                {
                    recipe => recipe.CreatedBy,
                    recipe => recipe.Ingredients
                }
            );
        }

        public Task<Recipe> FindById(long id)
        {
            return this._dataService.FindOneBy(
                recipe => recipe.Id == id,
                new Expression<Func<Recipe, object>>[]
                {
                    recipe => recipe.CreatedBy,
                    recipe => recipe.Ingredients
                }
            );
        }
    }
}
