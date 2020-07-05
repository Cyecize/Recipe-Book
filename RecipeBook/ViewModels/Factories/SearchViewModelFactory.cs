namespace RecipeBook.ViewModels.Factories
{
    public class SearchViewModelFactory : IViewModelFactory<SearchViewModel>
    {
        public SearchViewModel CreateViewModel()
        {
            return new SearchViewModel();
        }
    }
}
