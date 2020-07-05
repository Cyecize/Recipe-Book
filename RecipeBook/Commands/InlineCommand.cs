using System;
using System.Windows.Input;

namespace RecipeBook.Commands
{
    public class InlineCommand : ICommand
    {

        private readonly Action<object> _action;

        public InlineCommand(Action<object> action)
        {
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
