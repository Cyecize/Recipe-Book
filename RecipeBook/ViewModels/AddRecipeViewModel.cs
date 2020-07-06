using RecipeBook.Commands;
using RecipeBook.Models;
using RecipeBook.State.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using RecipeBook.Domain.Services;
using RecipeBook.State.Authentication;

namespace RecipeBook.ViewModels
{
    public class AddRecipeViewModel : BaseViewModel
    {

        private readonly INavigator _navigator;

        private readonly IRecipeService _recipeService;

        private readonly IAuthenticator _authenticator;

        private List<IngredientDto> _ingredients;

        private List<string> _errorMessages;

        public AddRecipeViewModel(INavigator navigator, IRecipeService recipeService, IAuthenticator authenticator)
        {
            this._navigator = navigator;
            this._recipeService = recipeService;
            this._authenticator = authenticator;
            this.Ingredients = new List<IngredientDto>();
        }

        public RecipeDto Recipe { get; } = new RecipeDto();

        public IngredientDto Ingredient { get; } = new IngredientDto();

        public List<IngredientDto> Ingredients
        {
            get => this._ingredients;
            set
            {
                this._ingredients = value;
                base.OnPropertyChanged(nameof(Ingredients));
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

        public ICommand CreateRecipeCommand => new InlineCommand(async payload =>
        {
            List<string> errorMessages = this.Recipe.GetValidationMessages();
            if (this.Ingredients.Count == 0) errorMessages.Add("Add at least one ingredient!");

            this.ErrorMessages = errorMessages;

            if (errorMessages.Count == 0)
            {
                await this._recipeService.CreateRecipe(
                    this._authenticator.CurrentUser,
                    this.Recipe.Title,
                    this.Recipe.Content,
                    this.Ingredients.ToDictionary(dto => dto.Name, dto => dto.Quantity)
                );

                this.ResetFieldsCommand.Execute(null);
                this._navigator.RedirectTo(ViewType.MyRecipes);
            }
        });

        public ICommand AddIngredientCommand => new InlineCommand(payload =>
        {
            List<string> errorMessages = this.Ingredient.GetValidationMessages();

            this.ErrorMessages = errorMessages;

            if (errorMessages.Count == 0)
            {
                this.Ingredients.Add(new IngredientDto()
                {
                    Name = this.Ingredient.Name,
                    Quantity = this.Ingredient.Quantity
                });

                this.Ingredients = new List<IngredientDto>(this.Ingredients);

                this.Ingredient.Name = string.Empty;
                this.Ingredient.Quantity = 0D;
            }
        });

        public ICommand ResetFieldsCommand => new InlineCommand(payload =>
        {
            this.Recipe.Content = string.Empty;
            this.Recipe.Title = string.Empty;
            this.Ingredients = new List<IngredientDto>();
            this.Ingredient.Quantity = 0D;
            this.Ingredient.Name = string.Empty;
            this.ErrorMessages = new List<string>();
        });
    }
}
