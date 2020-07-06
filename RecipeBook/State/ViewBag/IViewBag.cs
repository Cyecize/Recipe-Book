namespace RecipeBook.State.ViewBag
{
    public interface IViewBag
    {
        void Set(string key, object value);

        object Get(string key, bool oneTime = true);
    }
}
