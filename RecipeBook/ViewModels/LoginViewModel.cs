using System.Windows.Input;
using RecipeBook.Commands;
using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticator _authenticator;

        private readonly INavigator _navigator;

        private string _username;

        private string _password;

        public LoginViewModel(IAuthenticator authenticator, INavigator navigator)
        {
            _authenticator = authenticator;
            _navigator = navigator;
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

            if (isLoginSuccessful) this._navigator.RedirectTo(ViewType.MyRecipes);
            else this.Password = "";
        });
    }
}
