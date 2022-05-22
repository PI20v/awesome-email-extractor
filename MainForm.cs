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
        public MainForm()
        {
            InitializeComponent();
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
            List<string> uniqueEmails = new List<string>();

            // Вызываем метод для извлечения e-mail-ов
            int count = ExtactEmailsAlgorithm.Extract(sourceText, out uniqueEmails);

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
    }
}
