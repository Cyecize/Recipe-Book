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
    public class RecipeDetailsViewModel : BaseViewModel
    {
        private readonly IViewBag _viewBag;

        private readonly IRecipeService _recipeService;

        private readonly INavigator _navigator;

        private readonly IAuthenticator _authenticator;

        private Recipe _recipe;

        private bool _canEdit;

        public RecipeDetailsViewModel(
            IViewBag viewBag,
            IRecipeService recipeService,
            INavigator navigator,
            IAuthenticator authenticator)
        {
            this._viewBag = viewBag;
            this._recipeService = recipeService;
            this._navigator = navigator;
            this._authenticator = authenticator;
            this.Init();
        }

        public Recipe Recipe
        {
            get => this._recipe;
            set
            {
                this._recipe = value;
                base.OnPropertyChanged(nameof(Recipe));
            }
        }

        public bool CanEdit
        {
            get => this._canEdit;
            set
            {
                this._canEdit = value;
                base.OnPropertyChanged(nameof(CanEdit));
            }
        }

        public ICommand EditRecipeCommand => new InlineCommand(payload =>
        {
            if (!this.CanEdit) return;

            this._viewBag.Set(ViewBagItems.SelectedRecipeId, this.Recipe.Id);
            this._navigator.RedirectTo(ViewType.EditRecipe);
        });

        private async void Init()
        {
            this.CanEdit = false;
            object recipeId = this._viewBag.Get(ViewBagItems.SelectedRecipeId) ?? 0L;

            this.Recipe = await this._recipeService.FindById((long)recipeId);
            this.CanEdit = this.Recipe.CreatedById == this._authenticator.CurrentUser.Id;
        }
    }
}
