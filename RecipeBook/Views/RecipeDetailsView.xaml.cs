using System.Windows;
using System.Windows.Controls;

namespace RecipeBook.Views
{
    /// <summary>
    /// Interaction logic for RecipeDetailsView.xaml
    /// </summary>
    public partial class RecipeDetailsView : UserControl
    {
        public RecipeDetailsView()
        {
            InitializeComponent();
        }

        private void BtnPrint_OnClick(object sender, RoutedEventArgs e)
        {
            this.StActionsStack.Visibility = Visibility.Collapsed;
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog().GetValueOrDefault(false))
                {
                    printDialog.PrintVisual(this, this.TbRecipeTitle.Text);
                }
            }
            finally
            {
                this.StActionsStack.Visibility = Visibility.Visible;
            }
           
        }
    }
}
