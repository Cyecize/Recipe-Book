using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeBook.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void PbPasswordConfirm_OnKeyUp(object sender, KeyEventArgs e)
        {
            string text = this.PbPasswordConfirm.Password;
            this.TbPasswordConfirm.Text = text;
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

        private void TbPasswordConfirm_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.PbPasswordConfirm.Password != this.TbPasswordConfirm.Text)
                this.PbPasswordConfirm.Password = this.TbPasswordConfirm.Text;
        }
    }
}
