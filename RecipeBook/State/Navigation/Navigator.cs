using System;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Commands;
using RecipeBook.Models;
using RecipeBook.ViewModels;

namespace RecipeBook.State.Navigation
{
    public class Navigator : ObservableObject, INavigator
    {
        private readonly IServiceProvider _serviceProvider;

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

        public Navigator(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public ICommand UpdateCurrentViewModelCommand => new InlineCommand(payload =>
        {
            if (!(payload is ViewType viewType)) return;

            this.CurrentViewModel = (BaseViewModel)
                this._serviceProvider.GetRequiredService(viewType.ViewModelType);
        });

        public void RedirectTo(ViewType view)
        {
            this.UpdateCurrentViewModelCommand.Execute(view);
        }
    }
}
