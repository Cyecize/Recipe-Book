using System.Collections.Generic;

namespace RecipeBook.State.ViewBag
{
    public class ViewBag : IViewBag
    {
        private readonly Dictionary<string, object> _bag;

        public ViewBag()
        {
            this._bag = new Dictionary<string, object>();
        }

        public void Set(string key, object value)
        {
            this._bag[key] = value;
        }

        public object Get(string key, bool oneTime = true)
        {
            if (!this._bag.ContainsKey(key)) return null;

            object value = this._bag[key];
            if (oneTime) this._bag[key] = null;

            return value;
        }
    }
}
