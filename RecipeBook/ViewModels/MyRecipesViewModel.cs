using System.Collections.Generic;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.State.Authentication;
using RecipeBook.ViewsModels;

namespace RecipeBook.ViewModels
{
    public class MyRecipesViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        private readonly IAuthenticator _authenticator;

        public MyRecipesViewModel(IRecipeService recipeService, IAuthenticator authenticator)
        {
            this._recipeService = recipeService;
            this._authenticator = authenticator;
            this.LoadRecipesCommand.Execute(null);
        }

        public RecipesGridViewModel RecipesViewModel { get; } = new RecipesGridViewModel();
        public ICommand LoadRecipesCommand => new InlineCommand(async payload =>
        {
            if (!this._authenticator.IsLoggedIn) return;
            List<Recipe> recipes = await this._recipeService.FindByUser(this._authenticator.CurrentUser);
            this.RecipesViewModel.Recipes = recipes;
        });
    }
}
