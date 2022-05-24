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
            // dataGridView1.Columns["id"].Visible = false;
            // dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
