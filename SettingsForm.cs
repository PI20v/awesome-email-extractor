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
            DialogResult result = MessageBox.Show("Вы уверены что хотите удалить аккаунт?", "Удаление аккаунта", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Globals.currentUser.Delete();
                MessageBox.Show("Аккаунт удален");

                this.Close();
                
                AuthorizationForm authorization = FormManager.Current.CreateForm<AuthorizationForm>();
                FormManager.Current.Navigate(this.Owner, authorization);
            }
        }
    }
}
