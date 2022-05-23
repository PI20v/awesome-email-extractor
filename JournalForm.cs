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
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataLabel.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                actionLabel.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            } else {
                dataLabel.Text = "";
                actionLabel.Text = "";
                richTextBox1.Text = "";
            }
        }
    }
}
