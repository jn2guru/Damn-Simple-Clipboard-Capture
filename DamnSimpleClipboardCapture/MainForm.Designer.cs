namespace DamnSimpleClipboardCapture
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.WriteToFileButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.clipboardMonitor1 = new DamnSimpleClipboardCapture.ClipboardMonitor();
            this.AutoSaveCheckbox = new System.Windows.Forms.CheckBox();
            this.UpdatePathFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.RunningLogTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WriteToFileButton
            // 
            this.WriteToFileButton.Location = new System.Drawing.Point(322, 255);
            this.WriteToFileButton.Name = "WriteToFileButton";
            this.WriteToFileButton.Size = new System.Drawing.Size(193, 23);
            this.WriteToFileButton.TabIndex = 1;
            this.WriteToFileButton.Text = "Write To File";
            this.WriteToFileButton.UseVisualStyleBackColor = true;
            this.WriteToFileButton.Click += new System.EventHandler(this.WriteToFileButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(12, 12);
            this.LogTextBox.MaxLength = 100000;
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(632, 202);
            this.LogTextBox.TabIndex = 2;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(138, 255);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(178, 23);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // clipboardMonitor1
            // 
            this.clipboardMonitor1.BackColor = System.Drawing.Color.Red;
            this.clipboardMonitor1.Location = new System.Drawing.Point(12, 12);
            this.clipboardMonitor1.Name = "clipboardMonitor1";
            this.clipboardMonitor1.Size = new System.Drawing.Size(75, 23);
            this.clipboardMonitor1.TabIndex = 0;
            this.clipboardMonitor1.Text = "MainClipboardMonitor";
            this.clipboardMonitor1.Visible = false;
            this.clipboardMonitor1.ClipboardChanged += new System.EventHandler<DamnSimpleClipboardCapture.ClipboardChangedEventArgs>(this.MainClipboardMonitor_ClipboardChanged);
            // 
            // AutoSaveCheckbox
            // 
            this.AutoSaveCheckbox.AutoSize = true;
            this.AutoSaveCheckbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AutoSaveCheckbox.Location = new System.Drawing.Point(531, 243);
            this.AutoSaveCheckbox.Name = "AutoSaveCheckbox";
            this.AutoSaveCheckbox.Size = new System.Drawing.Size(76, 17);
            this.AutoSaveCheckbox.TabIndex = 4;
            this.AutoSaveCheckbox.Text = "Auto Save";
            this.AutoSaveCheckbox.UseVisualStyleBackColor = true;
            this.AutoSaveCheckbox.CheckedChanged += new System.EventHandler(this.AutoSaveCheckbox_CheckedChanged);
            // 
            // UpdatePathFolderBrowserDialog
            // 
            this.UpdatePathFolderBrowserDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "UpdatePathButton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UpdatePathButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(138, 226);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(296, 20);
            this.PathTextBox.TabIndex = 7;
            // 
            // RunningLogTimer
            // 
            this.RunningLogTimer.Enabled = true;
            this.RunningLogTimer.Interval = 60000;
            this.RunningLogTimer.Tick += new System.EventHandler(this.RunningLogTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 287);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AutoSaveCheckbox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.WriteToFileButton);
            this.Controls.Add(this.clipboardMonitor1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClipboardMonitor clipboardMonitor1;
        private System.Windows.Forms.Button WriteToFileButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox AutoSaveCheckbox;
        private System.Windows.Forms.FolderBrowserDialog UpdatePathFolderBrowserDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Timer RunningLogTimer;
    }
}

