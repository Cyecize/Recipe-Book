using System;
using System.Windows.Input;
using RecipeBook.State.Navigation;
using RecipeBook.ViewModels.Factories;

namespace RecipeBook.Commands
{
    /**
     * This command is used in the navbar in order to dynamically switch between view models which
     * leads to switching between views.
     */
    public class UpdateCurrentViewModelCommand : ICommand
    {

        private readonly INavigator _navigator;

        private readonly IViewModelAbstractFactory _viewModelAbstractFactory;

        public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator, IViewModelAbstractFactory viewModelAbstractFactory)
        {
            this._navigator = navigator;
            this._viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is ViewType viewType)) return;
            this._navigator.CurrentViewModel = this._viewModelAbstractFactory.CreateViewModel(viewType);
        }
    }
}
