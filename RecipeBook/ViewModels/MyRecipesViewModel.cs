using System.Collections.Generic;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.State.Authentication;

namespace RecipeBook.ViewModels
{
    public class MyRecipesViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        private readonly IAuthenticator _authenticator;

        private List<Recipe> _recipes;

        public MyRecipesViewModel(IRecipeService recipeService, IAuthenticator authenticator)
        {
            this._recipeService = recipeService;
            this._authenticator = authenticator;
            this.LoadRecipesCommand.Execute(null);
        }

        public List<Recipe> Recipes
        {
            get => this._recipes;
            set
            {
                this._recipes = value;
                base.OnPropertyChanged(nameof(Recipes));
            }
        }

        public ICommand LoadRecipesCommand => new InlineCommand(async payload =>
        {
            if (!this._authenticator.IsLoggedIn) return;
            List<Recipe> recipes = await this._recipeService.FindByUser(this._authenticator.CurrentUser);
            this.Recipes = recipes;
        });
    }
}
