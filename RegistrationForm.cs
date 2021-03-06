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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryLogin.Text) || string.IsNullOrEmpty(entryPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.Equals(entryPassword.Text, entryRePassword.Text))
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Globals.currentUser = Authorization.Register(entryLogin.Text, entryPassword.Text);
                Logs.Log(Globals.currentUser, Logs.Action.Registration, new Dictionary<string, object>());
                
                var form = FormManager.Current.CreateForm<MainForm>();
                FormManager.Current.Navigate(this, form);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            AuthorizationForm form = FormManager.Current.CreateForm<AuthorizationForm>();
            FormManager.Current.Navigate(this, form);
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
