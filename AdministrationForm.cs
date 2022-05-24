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

            List<string> columns = new List<string>() { "ID", "Логин", "Роль" };

            for (int i = 0; i < usersDataGridView.Columns.Count; i++)
            {
                usersDataGridView.Columns[i].HeaderText = columns[i];
                usersDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            var logs = Logs.GetLogsList();
            journalDataGridView.DataSource = logs;

            columns = new List<string>() { "ID", "Пользователь", "Дата", "Событие", "Сообщение" };

            for (int i = 0; i < journalDataGridView.Columns.Count; i++)
            {
                journalDataGridView.Columns[i].HeaderText = columns[i];
                journalDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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

        private void journalDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (journalDataGridView.SelectedRows.Count > 0)
            {
                var row = journalDataGridView.SelectedRows[0].DataBoundItem as Logs.LogData;

                dateLabel.Text = row.Date;
                userLabel.Text = $"{row.User.Login} ({row.User.ID}) - {row.User.Role}";
                actionLabel.Text = row.Action.ToString();
                messageRichTextBox.Text = row.Message;
            }
            else
            {
                dateLabel.Text = "";
                actionLabel.Text = "";
                userLabel.Text = "";
                messageRichTextBox.Text = "";
            }
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

                var logs = Logs.GetLogsList();
                journalDataGridView.DataSource = logs;
            } else
            {
                MessageBox.Show("Выберите 1 пользователя для редактирования!");
            }
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            bool selfDelete = false;

            if (usersDataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены что хотите удалить аккаунты?", "Удаление аккаунтов", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < usersDataGridView.SelectedRows.Count; i++)
                    {
                        var user = usersDataGridView.SelectedRows[i].DataBoundItem as User;
                        if (user.ID != Globals.currentUser.ID)
                        {
                            user.Delete();
                        }
                        else
                        {
                            selfDelete = true;
                        }
                    }

                    if (selfDelete)
                    {
                        DialogResult result2 = MessageBox.Show("Вы уверены что хотите удалить СВОЙ аккаунт?", "Удаление аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result2 == DialogResult.Yes)
                        {
                            Globals.currentUser.Delete();
                            MessageBox.Show("Аккаунт удален!", "Аккаунт удален", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();

                            AuthorizationForm authorization = FormManager.Current.CreateForm<AuthorizationForm>();
                            FormManager.Current.Navigate(this.Owner, authorization);
                        }
                    }

                    AdminUtils adminUtils = new AdminUtils(Globals.currentUser);
                    var users = adminUtils.GetAllUsers();
                    usersDataGridView.DataSource = users;

                    var logs = Logs.GetLogsList();
                    journalDataGridView.DataSource = logs;
                }
            }
            else
            {
                MessageBox.Show("Выберите хотя бы одного пользователя для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteJournalButton_Click(object sender, EventArgs e)
        {
            if (journalDataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены что хотите удалить записи в журнале?", "Удаление записей в журнале", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < journalDataGridView.SelectedRows.Count; i++)
                    {
                        var logData = journalDataGridView.SelectedRows[i].DataBoundItem as Logs.LogData;
                        logData.Delete();
                    }
                    var logs = Logs.GetLogsList();
                    journalDataGridView.DataSource = logs;
                }
            }
            else
            {
                MessageBox.Show("Выберите хотя бы одну запись для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
