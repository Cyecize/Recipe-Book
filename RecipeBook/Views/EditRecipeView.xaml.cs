using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeBook.Views
{
    /// <summary>
    /// Interaction logic for EditRecipeView.xaml
    /// </summary>
    public partial class EditRecipeView : UserControl
    {
        public EditRecipeView()
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
