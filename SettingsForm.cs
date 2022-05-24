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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите удалить аккаунт?", "Удаление аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Globals.currentUser.Delete();
                Logs.Log(Globals.currentUser, Logs.Action.DeleteAccount, new Dictionary<string, object>());
                MessageBox.Show("Аккаунт удален!", "Аккаунт удален", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                
                AuthorizationForm authorization = FormManager.Current.CreateForm<AuthorizationForm>();
                FormManager.Current.Navigate(this.Owner, authorization);
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryNewPassword.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            if (!string.Equals(entryNewPassword.Text, entryRePassword.Text))
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Globals.currentUser.ChangePassword(entryNewPassword.Text);
            Logs.Log(Globals.currentUser, Logs.Action.ChangePassword, new Dictionary<string, object>());
            MessageBox.Show("Пароль изменен!", "Пароль изменен", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
