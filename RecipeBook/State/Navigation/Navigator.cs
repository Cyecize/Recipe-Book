using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Models;
using RecipeBook.ViewModels;
using RecipeBook.ViewModels.Factories;

namespace RecipeBook.State.Navigation
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;

        private readonly IViewModelAbstractFactory _viewModelAbstractFactory;

        public BaseViewModel CurrentViewModel
        {
            get => this._currentViewModel;
            set
            {
                this._currentViewModel = value;
                base.OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this, this._viewModelAbstractFactory);

        public Navigator(IViewModelAbstractFactory viewModelAbstractFactory)
        {
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }
    }
}
