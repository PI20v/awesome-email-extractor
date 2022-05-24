namespace AwesomeEmailExtractor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.uniqueListBox = new System.Windows.Forms.ListBox();
            this.sourceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.resultCountLabel = new System.Windows.Forms.Label();
            this.resultStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultStatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uniqueListBox
            // 
            this.uniqueListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uniqueListBox.FormattingEnabled = true;
            this.uniqueListBox.ItemHeight = 20;
            this.uniqueListBox.Location = new System.Drawing.Point(424, 32);
            this.uniqueListBox.Name = "uniqueListBox";
            this.uniqueListBox.Size = new System.Drawing.Size(225, 324);
            this.uniqueListBox.TabIndex = 0;
            // 
            // sourceRichTextBox
            // 
            this.sourceRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sourceRichTextBox.Location = new System.Drawing.Point(12, 32);
            this.sourceRichTextBox.Name = "sourceRichTextBox";
            this.sourceRichTextBox.Size = new System.Drawing.Size(406, 288);
            this.sourceRichTextBox.TabIndex = 1;
            this.sourceRichTextBox.Text = "";
            // 
            // executeButton
            // 
            this.executeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executeButton.Location = new System.Drawing.Point(12, 350);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(406, 24);
            this.executeButton.TabIndex = 2;
            this.executeButton.Text = "Выполнить";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // resultCountLabel
            // 
            this.resultCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultCountLabel.AutoSize = true;
            this.resultCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultCountLabel.Location = new System.Drawing.Point(12, 323);
            this.resultCountLabel.Name = "resultCountLabel";
            this.resultCountLabel.Size = new System.Drawing.Size(363, 24);
            this.resultCountLabel.TabIndex = 3;
            this.resultCountLabel.Text = "Введите текст и нажмите \"Выполнить\"";
            // 
            // resultStatusStrip
            // 
            this.resultStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.resultStatusStrip.Location = new System.Drawing.Point(0, 377);
            this.resultStatusStrip.Name = "resultStatusStrip";
            this.resultStatusStrip.Size = new System.Drawing.Size(661, 22);
            this.resultStatusStrip.TabIndex = 4;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.аккаунтToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportResultToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exportResultToolStripMenuItem
            // 
            this.exportResultToolStripMenuItem.Name = "exportResultToolStripMenuItem";
            this.exportResultToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.exportResultToolStripMenuItem.Text = "Экспортировать результат";
            this.exportResultToolStripMenuItem.Click += new System.EventHandler(this.exportResultToolStripMenuItem_Click);
            // 
            // аккаунтToolStripMenuItem
            // 
            this.аккаунтToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.journalToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.аккаунтToolStripMenuItem.Name = "аккаунтToolStripMenuItem";
            this.аккаунтToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.аккаунтToolStripMenuItem.Text = "Аккаунт";
            // 
            // journalToolStripMenuItem
            // 
            this.journalToolStripMenuItem.Name = "journalToolStripMenuItem";
            this.journalToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.journalToolStripMenuItem.Text = "Журнал";
            this.journalToolStripMenuItem.Click += new System.EventHandler(this.journalToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.administrationToolStripMenuItem.Text = "Администрирование";
            this.administrationToolStripMenuItem.Click += new System.EventHandler(this.administrationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 399);
            this.Controls.Add(this.uniqueListBox);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.resultStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.resultCountLabel);
            this.Controls.Add(this.sourceRichTextBox);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(642, 438);
            this.Name = "MainForm";
            this.Text = "Главное окно";
            this.resultStatusStrip.ResumeLayout(false);
            this.resultStatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uniqueListBox;
        private System.Windows.Forms.RichTextBox sourceRichTextBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label resultCountLabel;
        private System.Windows.Forms.StatusStrip resultStatusStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem аккаунтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultToolStripMenuItem;
    }
}

