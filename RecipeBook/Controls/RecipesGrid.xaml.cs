using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RecipeBook.Domain.Models;

namespace RecipeBook.Controls
{
    /// <summary>
    /// Interaction logic for RecipesGrid.xaml
    /// </summary>
    public partial class RecipesGrid : UserControl
    {
        public RecipesGrid()
        {
            InitializeComponent();
        }

        private void DgRecipesGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Ensure row was clicked and not empty space
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) return;

            Recipe recipe = row.DataContext as Recipe;
            this.TbSelectedRecipeId.Text = recipe.Id.ToString();
        }
    }
}
