using RecipeBook.State.Navigation;

namespace RecipeBook.ViewModels.Factories
{
   public interface IViewModelAbstractFactory
   {
       BaseViewModel CreateViewModel(ViewType viewType);
   }
}
