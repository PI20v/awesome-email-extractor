using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace AwesomeEmailExtractor
{
    public partial class AdministrationForm : Form
    {
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "SELECT * FROM app_settings";

            var reader = command.ExecuteReader();

            var Row = reader.Read();

            pathToJournalTextBox.Text = reader.GetString(0);

            AdminUtils adminUtils = new AdminUtils(Globals.currentUser);

            var users = adminUtils.GetAllUsers();

            usersDataGridView.DataSource = users;            
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SQLite база с журналом (*.db)|*.db";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathToJournalTextBox.Text = dialog.FileName;

                SqliteCommand command = new SqliteCommand();
                command.Connection = Globals.db;
                command.CommandText = "UPDATE app_settings SET logs_db_path = @path";
                command.Parameters.AddWithValue("@path", pathToJournalTextBox.Text);
                command.ExecuteNonQuery();
            }

        }

        private void journalTabPage_Click(object sender, EventArgs e)
        {

        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count == 1)
            {
                var user = usersDataGridView.SelectedRows[0].DataBoundItem as User;

                var form = new EditUserForm();
                form.User = user;
                
                form.ShowDialog();

                AdminUtils adminUtils = new AdminUtils(Globals.currentUser);
                var users = adminUtils.GetAllUsers();
                usersDataGridView.DataSource = users;
            } else
            {
                MessageBox.Show("Выберите 1 пользователя для редактирования!");
            }
        }
    }
}
