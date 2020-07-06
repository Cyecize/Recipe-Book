using System.Collections.Generic;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Constants;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;
using RecipeBook.State.ViewBag;

namespace RecipeBook.ViewModels
{
    public class MyRecipesViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;

        private readonly IAuthenticator _authenticator;

        private readonly INavigator _navigator;

        private readonly IViewBag _viewBag;

        public MyRecipesViewModel(IRecipeService recipeService, IAuthenticator authenticator, INavigator navigator, IViewBag viewBag)
        {
            this._recipeService = recipeService;
            this._authenticator = authenticator;
            this._navigator = navigator;
            this._viewBag = viewBag;
            this.LoadRecipesCommand.Execute(null);
            this.Init();
        }

        public RecipesGridViewModel RecipesViewModel { get; } = new RecipesGridViewModel();
        public ICommand LoadRecipesCommand => new InlineCommand(async payload =>
        {
            if (!this._authenticator.IsLoggedIn) return;
            List<Recipe> recipes = await this._recipeService.FindByUser(this._authenticator.CurrentUser);
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
