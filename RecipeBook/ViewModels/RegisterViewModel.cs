using System;
using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthenticator _authenticator;

        private readonly INavigator _navigator;

        private string _username;

        private string _password;

        private string _passwordConfirm;

        private string _errorMessage;

        public RegisterViewModel(IAuthenticator authenticator, INavigator navigator)
        {
            this._authenticator = authenticator;
            this._navigator = navigator;
        }

        public string Username
        {
            get => this._username;
            set
            {
                this._username = value;
                base.OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => this._password;
            set
            {
                this._password = value;
                base.OnPropertyChanged(nameof(Password));
            }
        }

        public string PasswordConfirm
        {
            get => this._passwordConfirm;
            set
            {
                this._passwordConfirm = value;
                base.OnPropertyChanged(nameof(PasswordConfirm));
            }
        }

        public string ErrorMessage
        {
            get => this._errorMessage;
            set
            {
                this._errorMessage = value;
                base.OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand RegisterCommand => new InlineCommand(async payload =>
        {
            try
            {
                await this._authenticator.Register(this.Username, this.Password, this.PasswordConfirm);
                this._navigator.RedirectTo(ViewType.Login);
            }
            catch (Exception ex)
            {
                this.Password = string.Empty;
                this.PasswordConfirm = string.Empty;
                this.ErrorMessage = ex.Message;
            }
        });

        public ICommand RedirectToLoginCommand => new InlineCommand(payload => this._navigator.RedirectTo(ViewType.Login));
    }
}
