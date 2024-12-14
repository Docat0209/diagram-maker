

using System.Security.Principal;
using System.Xml.Linq;

namespace DiagramMaker
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterNameDialog registerNameDialog = new RegisterNameDialog();

            if (registerNameDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            if (AuthenticationService.RegisterUser(accountTextBox.Text, passwordTextBox.Text, registerNameDialog.UserInput))
            {
                loginErrorLabel.Text = "註冊成功！";
            }
            else
            {
                loginErrorLabel.Text = "註冊失敗，帳號可能已存在。";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int? userId = AuthenticationService.AuthenticateUser(accountTextBox.Text, passwordTextBox.Text);

            if (userId.HasValue)
            {
                DiagramMakerForm diagramMakerForm = new DiagramMakerForm(userId.Value);
                diagramMakerForm.Show();
                this.Hide();
            }
            else
            {
                loginErrorLabel.Text = "登入失敗，帳號或密碼錯誤。";
            }

        }
    }
}
