using System;
using RecipeBook.ViewModels;

namespace RecipeBook.State.Navigation
{
    public class ViewType
    {
        public static readonly ViewType MyRecipes = new ViewType(typeof(MyRecipesViewModel));
        public static readonly ViewType Search = new ViewType(typeof(SearchViewModel));
        public static readonly ViewType AddRecipe = new ViewType(typeof(AddRecipeViewModel));
        public static readonly ViewType Login = new ViewType(typeof(LoginViewModel));
        public static readonly ViewType Register = new ViewType(typeof(RegisterViewModel));
        public static readonly ViewType RecipeDetails = new ViewType(typeof(RecipeDetailsViewModel));

        public Type ViewModelType { get; }

        private ViewType(Type viewModelType)
        {
            this.ViewModelType = viewModelType;
        }
    }

}
