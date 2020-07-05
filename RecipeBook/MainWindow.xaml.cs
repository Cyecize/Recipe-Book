using System.Windows;

namespace RecipeBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            this.DataContext = dataContext;
            InitializeComponent();
        }
    }
}
