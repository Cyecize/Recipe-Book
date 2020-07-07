using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Constants;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.Models;
using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;
using RecipeBook.State.ViewBag;

namespace RecipeBook.ViewModels
{
    public class EditRecipeViewModel : BaseViewModel
    {
        private readonly IViewBag _viewBag;

        private readonly IRecipeService _recipeService;

        private readonly INavigator _navigator;

        private readonly IAuthenticator _authenticator;

        private Recipe _recipeToEdit;

        private RecipeDto _recipe;

        private List<string> _errorMessages;

        private IngredientsGridViewModel _ingredientsGridViewModel;

        public EditRecipeViewModel(
            IViewBag viewBag,
            IRecipeService recipeService,
            INavigator navigator,
            IAuthenticator authenticator)
        {
            this._viewBag = viewBag;
            this._recipeService = recipeService;
            this._navigator = navigator;
            this._authenticator = authenticator;
            this.IngredientsGridViewModel = new IngredientsGridViewModel();
            this.Init();
        }

        public RecipeDto Recipe
        {
            get => this._recipe;
            set
            {
                this._recipe = value;
                base.OnPropertyChanged(nameof(Recipe));
            }
        }

        public List<string> ErrorMessages
        {
            get => this._errorMessages;
            set
            {
                this._errorMessages = value;
                base.OnPropertyChanged(nameof(ErrorMessages));
            }
        }

        public IngredientsGridViewModel IngredientsGridViewModel
        {
            get => this._ingredientsGridViewModel;
            set
            {
                this._ingredientsGridViewModel = value;
                base.OnPropertyChanged(nameof(IngredientsGridViewModel));
            }
        }

        public IngredientDto Ingredient { get; } = new IngredientDto();

        public ICommand SaveRecipeCommand => new InlineCommand(async payload =>
        {
            if (this._authenticator.CurrentUser.Id != this._recipeToEdit.CreatedById) return;

            List<string> errorMessages = this.Recipe.GetValidationMessages();
            if (this.IngredientsGridViewModel.Ingredients.Count == 0) errorMessages.Add("Add at least one ingredient!");

            this.ErrorMessages = errorMessages;

            if (errorMessages.Count > 0) return;

            this._recipeToEdit.Title = this.Recipe.Title;
            this._recipeToEdit.Content = this.Recipe.Content;

            await this._recipeService.EditRecipe(
                this._recipeToEdit,
                this.IngredientsGridViewModel.Ingredients.ToDictionary(dto => dto.Name, dto => dto.Quantity)
            );

            this._viewBag.Set(ViewBagItems.SelectedRecipeId, this._recipeToEdit.Id);
            this._navigator.RedirectTo(ViewType.RecipeDetails);
        });

        public ICommand AddIngredientCommand => new InlineCommand(payload =>
        {
            List<string> errorMessages = this.Ingredient.GetValidationMessages();

            this.ErrorMessages = errorMessages;

            if (errorMessages.Count == 0)
            {
                this.IngredientsGridViewModel.AddIngredient(this.Ingredient.Name, this.Ingredient.Quantity);

                this.Ingredient.Name = string.Empty;
                this.Ingredient.Quantity = 0D;
            }
        });

        private async void Init()
        {
            object recipeId = this._viewBag.Get(ViewBagItems.SelectedRecipeId) ?? 0L;

            Recipe recipe = await this._recipeService.FindById((long)recipeId);
            this._recipeToEdit = recipe;

            this.Recipe = new RecipeDto()
            {
                Title = recipe.Title,
                Content = recipe.Content
            };

            this.IngredientsGridViewModel.Ingredients = recipe.Ingredients.Select(ingredient => new IngredientDto()
            {
                Quantity = ingredient.Quantity,
                Name = ingredient.Name,
                Number = (int) ingredient.Id
            }).ToList();
        }
    }
}
