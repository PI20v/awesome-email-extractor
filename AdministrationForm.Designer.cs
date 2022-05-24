namespace AwesomeEmailExtractor
{
    partial class AdministrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainSettingsTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.pathToJournalTextBox = new System.Windows.Forms.TextBox();
            this.usersTabPage = new System.Windows.Forms.TabPage();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.editUserButton = new System.Windows.Forms.Button();
            this.journalTabPage = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.journalDataGridView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.deleteJournalButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            this.mainTabControl.SuspendLayout();
            this.mainSettingsTabPage.SuspendLayout();
            this.usersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.journalTabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalDataGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.mainSettingsTabPage);
            this.mainTabControl.Controls.Add(this.usersTabPage);
            this.mainTabControl.Controls.Add(this.journalTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(998, 557);
            this.mainTabControl.TabIndex = 0;
            // 
            // mainSettingsTabPage
            // 
            this.mainSettingsTabPage.Controls.Add(this.label1);
            this.mainSettingsTabPage.Controls.Add(this.browseButton);
            this.mainSettingsTabPage.Controls.Add(this.pathToJournalTextBox);
            this.mainSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.mainSettingsTabPage.Name = "mainSettingsTabPage";
            this.mainSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainSettingsTabPage.Size = new System.Drawing.Size(990, 531);
            this.mainSettingsTabPage.TabIndex = 0;
            this.mainSettingsTabPage.Text = "Общие настройки";
            this.mainSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к файлу с журналом:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(678, 26);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(106, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Обзор";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pathToJournalTextBox
            // 
            this.pathToJournalTextBox.Enabled = false;
            this.pathToJournalTextBox.Location = new System.Drawing.Point(8, 28);
            this.pathToJournalTextBox.Name = "pathToJournalTextBox";
            this.pathToJournalTextBox.Size = new System.Drawing.Size(664, 20);
            this.pathToJournalTextBox.TabIndex = 0;
            // 
            // usersTabPage
            // 
            this.usersTabPage.Controls.Add(this.usersDataGridView);
            this.usersTabPage.Controls.Add(this.panel2);
            this.usersTabPage.Location = new System.Drawing.Point(4, 22);
            this.usersTabPage.Name = "usersTabPage";
            this.usersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.usersTabPage.Size = new System.Drawing.Size(990, 531);
            this.usersTabPage.TabIndex = 1;
            this.usersTabPage.Text = "Пользователи";
            this.usersTabPage.UseVisualStyleBackColor = true;
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersDataGridView.Location = new System.Drawing.Point(3, 31);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGridView.Size = new System.Drawing.Size(984, 497);
            this.usersDataGridView.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deleteUserButton);
            this.panel2.Controls.Add(this.editUserButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 28);
            this.panel2.TabIndex = 2;
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(140, 3);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(131, 20);
            this.deleteUserButton.TabIndex = 2;
            this.deleteUserButton.Text = "Удалить";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // editUserButton
            // 
            this.editUserButton.Location = new System.Drawing.Point(3, 3);
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(131, 20);
            this.editUserButton.TabIndex = 1;
            this.editUserButton.Text = "Редактировать";
            this.editUserButton.UseVisualStyleBackColor = true;
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // journalTabPage
            // 
            this.journalTabPage.Controls.Add(this.panel3);
            this.journalTabPage.Controls.Add(this.panel1);
            this.journalTabPage.Location = new System.Drawing.Point(4, 22);
            this.journalTabPage.Name = "journalTabPage";
            this.journalTabPage.Size = new System.Drawing.Size(990, 531);
            this.journalTabPage.TabIndex = 2;
            this.journalTabPage.Text = "Журнал";
            this.journalTabPage.UseVisualStyleBackColor = true;
            this.journalTabPage.Click += new System.EventHandler(this.journalTabPage_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.journalDataGridView);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 531);
            this.panel3.TabIndex = 2;
            // 
            // journalDataGridView
            // 
            this.journalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.journalDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.journalDataGridView.Location = new System.Drawing.Point(0, 37);
            this.journalDataGridView.Name = "journalDataGridView";
            this.journalDataGridView.ReadOnly = true;
            this.journalDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.journalDataGridView.Size = new System.Drawing.Size(536, 494);
            this.journalDataGridView.TabIndex = 0;
            this.journalDataGridView.SelectionChanged += new System.EventHandler(this.journalDataGridView_SelectionChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.deleteJournalButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 37);
            this.panel4.TabIndex = 1;
            // 
            // deleteJournalButton
            // 
            this.deleteJournalButton.Location = new System.Drawing.Point(8, 3);
            this.deleteJournalButton.Name = "deleteJournalButton";
            this.deleteJournalButton.Size = new System.Drawing.Size(131, 20);
            this.deleteJournalButton.TabIndex = 3;
            this.deleteJournalButton.Text = "Удалить";
            this.deleteJournalButton.UseVisualStyleBackColor = true;
            this.deleteJournalButton.Click += new System.EventHandler(this.deleteJournalButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(536, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 531);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.messageRichTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.userLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.actionLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 531);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Дата:";
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageRichTextBox.Location = new System.Drawing.Point(103, 93);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.ReadOnly = true;
            this.messageRichTextBox.Size = new System.Drawing.Size(348, 435);
            this.messageRichTextBox.TabIndex = 3;
            this.messageRichTextBox.Text = "";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(103, 30);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(0, 13);
            this.userLabel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Событие:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(103, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(0, 13);
            this.dateLabel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Пользователь:";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(103, 60);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(0, 13);
            this.actionLabel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Сообщение:";
            // 
            // sqliteCommand1
            // 
            this.sqliteCommand1.CommandTimeout = 30;
            this.sqliteCommand1.Connection = null;
            this.sqliteCommand1.Transaction = null;
            this.sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 557);
            this.Controls.Add(this.mainTabControl);
            this.Name = "AdministrationForm";
            this.Text = "Администрирование";
            this.Load += new System.EventHandler(this.AdministrationForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.mainSettingsTabPage.ResumeLayout(false);
            this.mainSettingsTabPage.PerformLayout();
            this.usersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.journalTabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.journalDataGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage mainSettingsTabPage;
        private System.Windows.Forms.TabPage usersTabPage;
        private System.Windows.Forms.TabPage journalTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pathToJournalTextBox;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView journalDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Panel panel3;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteJournalButton;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label label5;
    }
}