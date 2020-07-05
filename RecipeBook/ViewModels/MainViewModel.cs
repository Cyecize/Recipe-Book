using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public IAuthenticator Authenticator { get; set; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            this.Navigator = navigator;
            this.Authenticator = authenticator;
            this.Navigator.RedirectTo(ViewType.Login);
        }
    }
}
