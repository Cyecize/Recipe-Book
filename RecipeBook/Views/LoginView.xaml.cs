using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeBook.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PbPassword_OnKeyUp(object sender, KeyEventArgs e)
        {
            string text = this.PbPassword.Password;
            this.TbPassword.Text = text;
        }

        private void TbPassword_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.PbPassword.Password != this.TbPassword.Text)
                this.PbPassword.Password = this.TbPassword.Text;
        }
    }
}
