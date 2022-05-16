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
            // Чистим предыдущий результат
            toolStripStatusLabel.Text = "";
            resultCountLabel.Text = "";
            uniqueListBox.DataSource = null;

            // Объявляем список уникальных e-mail-ов
            List<string> uniqueEmails = new List<string>();

            // Получаем исходный текст из sourceRichTextBox
            string sourceText = sourceRichTextBox.Text;

            // Вызываем метод для извлечения e-mail-ов
            int count = ExtactEmailsAlgorithm.Extract(sourceText, out uniqueEmails);

            // Выводим результат
            toolStripStatusLabel.Text = "Успех!";
            resultCountLabel.Text = $"Количество e-mail-ов в тексте: {count}";
            uniqueListBox.DataSource = uniqueEmails;
        }
    }
}
