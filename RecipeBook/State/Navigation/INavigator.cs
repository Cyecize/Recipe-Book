using System.Windows.Input;
using RecipeBook.ViewModels;

namespace RecipeBook.State.Navigation
{
    public enum ViewType
    {
        MyRecipes,
        Search,
        AddRecipe
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
