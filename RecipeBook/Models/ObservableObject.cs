using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeBook.Models
{
    /**
     * This object can be extended if we want to subscribe to property change.
     * See INavigator implementation for example usage.
     */
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
