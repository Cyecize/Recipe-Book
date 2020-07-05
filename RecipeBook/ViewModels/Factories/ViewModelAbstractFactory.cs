using System;
using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<MyRecipesViewModel> _myRecipesViewModelFactory;
        private readonly IViewModelFactory<SearchViewModel> _searchViewModelFactory;
        private readonly IViewModelFactory<AddRecipeViewModel> _addRecipeViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> _loginViewModelFactory;

        public ViewModelAbstractFactory(
            IViewModelFactory<AddRecipeViewModel> addRecipeViewModelFactory,
            IViewModelFactory<SearchViewModel> searchViewModelFactory,
            IViewModelFactory<MyRecipesViewModel> myRecipesViewModelFactory, 
            IViewModelFactory<LoginViewModel> loginViewModelFactory)
        {
            _addRecipeViewModelFactory = addRecipeViewModelFactory;
            _searchViewModelFactory = searchViewModelFactory;
            _myRecipesViewModelFactory = myRecipesViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.MyRecipes => (BaseViewModel) this._myRecipesViewModelFactory.CreateViewModel(),
                ViewType.Search => this._searchViewModelFactory.CreateViewModel(),
                ViewType.AddRecipe => this._addRecipeViewModelFactory.CreateViewModel(),
                ViewType.Login => this._loginViewModelFactory.CreateViewModel(),
                _ => throw new ArgumentException($"View {viewType} not supported!")
            };
        }
    }
}
