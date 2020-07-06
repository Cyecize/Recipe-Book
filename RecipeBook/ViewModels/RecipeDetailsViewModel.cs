using RecipeBook.Constants;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.State.Navigation;
using RecipeBook.State.ViewBag;

namespace RecipeBook.ViewModels
{
    public class RecipeDetailsViewModel : BaseViewModel
    {
        private readonly IViewBag _viewBag;

        private readonly IRecipeService _recipeService;

        private readonly INavigator _navigator;

        private Recipe _recipe;

        public RecipeDetailsViewModel(IViewBag viewBag, IRecipeService recipeService, INavigator navigator)
        {
            this._viewBag = viewBag;
            this._recipeService = recipeService;
            this._navigator = navigator;
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

        private async void Init()
        {
            object recipeId = this._viewBag.Get(ViewBagItems.SelectedRecipeId) ?? 0L;

            this.Recipe = await this._recipeService.FindById((long)recipeId);
        }
    }
}
