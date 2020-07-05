using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
