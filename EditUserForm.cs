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
    public partial class EditUserForm : Form
    {
        public User User { get; set; }

        public EditUserForm()
        {
            InitializeComponent();
        }

        

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            idTextBox.Text = User.ID.ToString();
            loginTextBox.Text = User.Login;


            roleComboBox.Items.Add(UserRoles.DEFAULT.ToString());
            roleComboBox.Items.Add(UserRoles.ADMIN.ToString());

            roleComboBox.SelectedIndex = (int)User.Role;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            AdminUtils adminUtils = new AdminUtils(Globals.currentUser);

            User editedUser = new User(User.ID, loginTextBox.Text, (UserRoles)roleComboBox.SelectedIndex);

            if (passwordTextBox.Text != "")
            {
                adminUtils.editUser(editedUser, passwordTextBox.Text);
            }
            else
            {

                adminUtils.editUser(editedUser);
            }

            this.Close();
        }
    }
}
