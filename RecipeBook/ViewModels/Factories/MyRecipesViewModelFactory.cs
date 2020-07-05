namespace RecipeBook.ViewModels.Factories
{
    public class MyRecipesViewModelFactory : IViewModelFactory<MyRecipesViewModel>
    {
        public MyRecipesViewModel CreateViewModel()
        {
            return new MyRecipesViewModel();
        }
    }
}
