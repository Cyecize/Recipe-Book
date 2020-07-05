using RecipeBook.State.Authentication;

namespace RecipeBook.ViewModels.Factories
{
    public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {

        private readonly IAuthenticator _authenticator;

        public LoginViewModelFactory(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(this._authenticator);
        }
    }
}
