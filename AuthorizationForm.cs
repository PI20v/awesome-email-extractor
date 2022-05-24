using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeEmailExtractor
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(entryLogin.Text) || string.IsNullOrEmpty(entryPassword.Text))
                {
                    MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Globals.currentUser = Authorization.Login(entryLogin.Text, entryPassword.Text);
                Logs.Log(Globals.currentUser, Logs.Action.Login, new Dictionary<string, object>());

                var mainForm = FormManager.Current.CreateForm<MainForm>();
                FormManager.Current.Navigate(this, mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var form = FormManager.Current.CreateForm<RegistrationForm>();
            FormManager.Current.Navigate(this, form);
        }
    }
}
