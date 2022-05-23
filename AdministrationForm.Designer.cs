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
            this.journalTabPage = new System.Windows.Forms.TabPage();
            this.mainTabControl.SuspendLayout();
            this.mainSettingsTabPage.SuspendLayout();
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
            this.mainTabControl.Size = new System.Drawing.Size(800, 450);
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
            this.mainSettingsTabPage.Size = new System.Drawing.Size(792, 424);
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
            this.usersTabPage.Location = new System.Drawing.Point(4, 22);
            this.usersTabPage.Name = "usersTabPage";
            this.usersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.usersTabPage.Size = new System.Drawing.Size(792, 424);
            this.usersTabPage.TabIndex = 1;
            this.usersTabPage.Text = "Пользователи";
            this.usersTabPage.UseVisualStyleBackColor = true;
            // 
            // journalTabPage
            // 
            this.journalTabPage.Location = new System.Drawing.Point(4, 22);
            this.journalTabPage.Name = "journalTabPage";
            this.journalTabPage.Size = new System.Drawing.Size(792, 424);
            this.journalTabPage.TabIndex = 2;
            this.journalTabPage.Text = "Журнал";
            this.journalTabPage.UseVisualStyleBackColor = true;
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTabControl);
            this.Name = "AdministrationForm";
            this.Text = "Администрирование";
            this.Load += new System.EventHandler(this.AdministrationForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.mainSettingsTabPage.ResumeLayout(false);
            this.mainSettingsTabPage.PerformLayout();
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
    }
}