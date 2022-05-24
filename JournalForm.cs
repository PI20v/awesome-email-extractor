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
    public partial class JournalForm : Form
    {
        public JournalForm()
        {
            InitializeComponent();
        }

        private void JournalForm_Load(object sender, EventArgs e)
        {
            var logs = Logs.GetLogsList(Globals.currentUser);

            dataGridView1.DataSource = logs;

            List<string> columns = new List<string>() { "Дата", "Событие", "Сообщение" };

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["user"].Visible = false;

            for (int i = 0; i < columns.Count; i++)
            {
                dataGridView1.Columns[i + 2].HeaderText = columns[i];
            };

            dataGridView1.Columns["message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataLabel.Text = dataGridView1.SelectedRows[0].Cells["date"].Value.ToString();
                actionLabel.Text = dataGridView1.SelectedRows[0].Cells["action"].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["message"].Value.ToString();
            } else {
                dataLabel.Text = "";
                actionLabel.Text = "";
                richTextBox1.Text = "";
            }
        }
    }
}
