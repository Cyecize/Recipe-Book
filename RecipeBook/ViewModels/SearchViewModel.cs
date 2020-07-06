using System.Collections.Generic;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.State.Authentication;
using RecipeBook.Views;
using RecipeBook.ViewsModels;

namespace RecipeBook.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        private readonly IAuthenticator _authenticator;

        private string _global;

        private string _owner;

        public SearchViewModel(IRecipeService recipeService, IAuthenticator authenticator)
        {
            this._recipeService = recipeService;
            this._authenticator = authenticator;
        }

        public string Global
        {
            get => this._global;
            set
            {
                this._global = value;
                base.OnPropertyChanged(nameof(Global));
            }
        }

        public string Owner
        {
            get => this._owner;
            set
            {
                this._owner = value;
                base.OnPropertyChanged(nameof(Owner));
            }
        }

        public RecipesGridViewModel RecipesViewModel { get; } = new RecipesGridViewModel();

        public ICommand SearchCommand => new InlineCommand(async payload =>
        {
            if (!this._authenticator.IsLoggedIn) return;

            RecipeSearchQuery searchQuery = new RecipeSearchQuery()
            {
                Global = this.Global,
                OwnerName = this.Owner
            };

            List<Recipe> recipes = await this._recipeService.Search(searchQuery);

            this.RecipesViewModel.Recipes = recipes;
        });
    }
}
