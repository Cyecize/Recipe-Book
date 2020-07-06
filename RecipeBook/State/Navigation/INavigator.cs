using System.Windows.Input;
using RecipeBook.ViewModels;

namespace RecipeBook.State.Navigation
{
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }

        void RedirectTo(ViewType view);
    }
}
