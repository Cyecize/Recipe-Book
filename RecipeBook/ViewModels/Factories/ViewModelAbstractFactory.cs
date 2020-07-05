using System;
using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<MyRecipesViewModel> _myRecipesViewModelFactory;
        private readonly IViewModelFactory<SearchViewModel> _searchViewModelFactory;
        private readonly IViewModelFactory<AddRecipeViewModel> _addRecipeViewModelFactory;

        public ViewModelAbstractFactory(
            IViewModelFactory<AddRecipeViewModel> addRecipeViewModelFactory,
            IViewModelFactory<SearchViewModel> searchViewModelFactory,
            IViewModelFactory<MyRecipesViewModel> myRecipesViewModelFactory)
        {
            _addRecipeViewModelFactory = addRecipeViewModelFactory;
            _searchViewModelFactory = searchViewModelFactory;
            _myRecipesViewModelFactory = myRecipesViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.MyRecipes:
                    return this._myRecipesViewModelFactory.CreateViewModel();
                case ViewType.Search:
                    return this._searchViewModelFactory.CreateViewModel();
                case ViewType.AddRecipe:
                    return this._addRecipeViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException($"View {viewType} not supported!");
            }
        }
    }
}
