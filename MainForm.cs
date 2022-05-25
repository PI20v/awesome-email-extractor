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
    public partial class MainForm : Form
    {
        public int count;
        public List<string> uniqueEmails;

        public MainForm()
        {
            InitializeComponent();

            administrationToolStripMenuItem.Enabled = Globals.currentUser.Role == UserRoles.ADMIN;
        }
        
        private void executeButton_Click(object sender, EventArgs e)
        {
            // Получаем исходный текст из sourceRichTextBox
            string sourceText = sourceRichTextBox.Text;

            if (sourceText.Length == 0)
            {
                MessageBox.Show("Введите текст в поле исходного текста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Чистим предыдущий результат
            toolStripStatusLabel.Text = "";
            resultCountLabel.Text = "";
            uniqueListBox.DataSource = null;

            // Объявляем список уникальных e-mail-ов
            uniqueEmails = new List<string>();

            // Вызываем метод для извлечения e-mail-ов
            count = ExtactEmailsAlgorithm.Extract(sourceText, out uniqueEmails);

            // Выводим результат
            toolStripStatusLabel.Text = "Успех!";
            resultCountLabel.Text = $"Количество e-mail-ов в тексте: {count}";
            uniqueListBox.DataSource = uniqueEmails;

            Logs.Log(
                Globals.currentUser, 
                Logs.Action.Execute, 
                new Dictionary<string, object>() { 
                    { "sourceText", sourceText }, 
                    { "count", count }, 
                    { "uniqueEmails", uniqueEmails } 
                });
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = FormManager.Current.CreateForm<SettingsForm>();
            settingsForm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.currentUser = null;
            AuthorizationForm authorization = FormManager.Current.CreateForm<AuthorizationForm>();
            FormManager.Current.Navigate(this, authorization);
        }

        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JournalForm journalForm = FormManager.Current.CreateForm<JournalForm>();
            journalForm.ShowDialog(this);
        }

        private void administrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrationForm administrationForm = FormManager.Current.CreateForm<AdministrationForm>();
            administrationForm.ShowDialog(this);
        }

        private void exportResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Показать окно с выбором файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";
            saveFileDialog.FileName = "Результат.txt";

            var res = saveFileDialog.ShowDialog();


            // Сохранить результат в файл
            if (res == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string resultText = $"Количество e-mail-ов в тексте: {count}\nСписок уникальных e-mail-ов:\n{string.Join("\n", uniqueEmails)}";

                System.IO.File.WriteAllText(fileName, resultText);

                MessageBox.Show("E-mail-ы успешно сохранены в файл", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = FormManager.Current.CreateForm<HelpForm>();
            helpForm.ShowDialog(this);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Показать окно с выбором файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";

            var res = openFileDialog.ShowDialog();

            // Загрузить текст из файла
            if (res == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string sourceText = System.IO.File.ReadAllText(fileName);

                sourceRichTextBox.Text = sourceText;
            }
            
        }
    }
}
