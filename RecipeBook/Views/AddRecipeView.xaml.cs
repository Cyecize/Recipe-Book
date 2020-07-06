using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeBook.Views
{
    /// <summary>
    /// Interaction logic for AddRecipeView.xaml
    /// </summary>
    public partial class AddRecipeView : UserControl
    {
        public AddRecipeView()
        {
            InitializeComponent();
        }

        private void TbQuantity_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
