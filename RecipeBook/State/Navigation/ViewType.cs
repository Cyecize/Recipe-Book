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

        public Type ViewModelType { get; }

        private ViewType(Type viewModelType)
        {
            this.ViewModelType = viewModelType;
        }
    }

}
