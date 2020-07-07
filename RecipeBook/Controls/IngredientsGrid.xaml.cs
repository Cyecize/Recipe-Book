using System.Windows;
using System.Windows.Controls;
using RecipeBook.Models;

namespace RecipeBook.Controls
{
    /// <summary>
    /// Interaction logic for IngredientsGrid.xaml
    /// </summary>
    public partial class IngredientsGrid : UserControl
    {
        public IngredientsGrid()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            IngredientDto ingredient = this.DgIngredientsGrid.SelectedItem as IngredientDto;

            if (ingredient != null)
                this.TbSelectedIngredientNumberToRemove.Text = ingredient.Number.ToString();
        }
    }
}
