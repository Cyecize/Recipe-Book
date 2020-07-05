using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            this.Navigator = navigator;
        }
    }
}
