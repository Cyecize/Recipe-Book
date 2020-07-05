using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.State.Authentication;

namespace RecipeBook.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticator _authenticator;

        private string _username;

        private string _password;

        public LoginViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
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

        public ICommand LoginCommand => new InlineCommand(payload =>
        {
            bool isLoginSuccessful = this._authenticator.Login(this.Username, this.Password);


        });
    }
}
