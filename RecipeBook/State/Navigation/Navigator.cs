using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.Models;
using RecipeBook.ViewModels;

namespace RecipeBook.State.Navigation
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => this._currentViewModel;
            set
            {
                this._currentViewModel = value;
                base.OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
