namespace RecipeBook.ViewModels.Factories
{
    public class AddRecipeViewModelFactory : IViewModelFactory<AddRecipeViewModel>
    {
        public AddRecipeViewModel CreateViewModel()
        {
            return new AddRecipeViewModel();
        }
    }
}
