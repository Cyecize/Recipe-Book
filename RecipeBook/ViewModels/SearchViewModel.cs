using System.Collections.Generic;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Constants;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;
using RecipeBook.State.ViewBag;

namespace RecipeBook.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        private readonly IAuthenticator _authenticator;

        private readonly IViewBag _viewBag;

        private readonly INavigator _navigator;

        private string _global;

        private string _owner;

        public SearchViewModel(IRecipeService recipeService, IAuthenticator authenticator, IViewBag viewBag, INavigator navigator)
        {
            this._recipeService = recipeService;
            this._authenticator = authenticator;
            this._viewBag = viewBag;
            this._navigator = navigator;
            this.Init();
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

        private void Init()
        {
            this.RecipesViewModel.OnSelectedRecipeIdChanged += recipeId =>
            {
                this._viewBag.Set(ViewBagItems.SelectedRecipeId, recipeId);
                this._navigator.RedirectTo(ViewType.RecipeDetails);
            };
        }
    }
}
