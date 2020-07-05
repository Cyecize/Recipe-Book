using System;
using System.Windows.Input;
using RecipeBook.State.Navigation;
using RecipeBook.ViewModels;

namespace RecipeBook.Commands
{
    /**
     * This command is used in the navbar in order to dynamically switch between view models which
     * leads to switching between views.
     */
    public class UpdateCurrentViewModelCommand : ICommand
    {

        private readonly INavigator _navigator;

        public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            this._navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is ViewType viewType)) return;

            this._navigator.CurrentViewModel = viewType switch
            {
                ViewType.AddRecipe => new AddRecipeViewModel(),
                ViewType.MyRecipes => new MyRecipesViewModel(),
                ViewType.Search => new SearchViewModel(),
                _ => this._navigator.CurrentViewModel
            };
        }
    }
}
