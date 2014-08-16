using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamnSimpleClipboardCapture
{
    public partial class MainForm : Form
    {
        private bool AutoSaveEnabled = false;
        private string basePath = string.Empty;
        private string ClipboardLog = string.Empty;
        private string RunningLog = string.Empty; 

        public MainForm()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string basepath = Properties.Settings.Default["basePath"].ToString();
            bool useDesktop = bool.Parse(Properties.Settings.Default["useDesktop"].ToString());
            InitializeComponent();
            SetPath(path, basepath, useDesktop);
        }

        private void SetPath(string path, string basepath = "", bool useDesktop = false, bool updateConfig = false)
        {
            if (useDesktop)
            {
                path = path + "\\" + basepath;
            }
            else if(string.IsNullOrEmpty(basepath))
            {
                //do nothing (for now)
            }
            else
            {
                path = basepath;
            }
            //set the final base path
            this.basePath = path;
            PathTextBox.Text = this.basePath;

            if(updateConfig)
            {
                Properties.Settings.Default["basePath"] = this.basePath;
                Properties.Settings.Default["useDesktop"] = false;
                Properties.Settings.Default.Save();
            }
        }

        private void WriteToLog(string message)
        {
            ClipboardLog += message;
            RunningLog += message;
            LogTextBox.Text = ClipboardLog;
            if(AutoSaveEnabled)
            {
                string path = string.Format("{0}\\autosave_{1}.txt", this.basePath, DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss"));
                File.WriteAllText(path, ClipboardLog);
            }
        }

        private void ClearLog()
        {
            ClipboardLog = string.Empty;
            RunningLog = string.Empty;
            LogTextBox.Text = ClipboardLog;
        }
        private void WriteToFileButton_Click(object sender, EventArgs e)
        {
            string path = string.Format("{0}\\clipboard_log_{1}.txt", this.basePath, DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss"));
            File.WriteAllText(path, ClipboardLog);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void MainClipboardMonitor_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
        {
            string clipboardText = string.Empty;

            try
            {
                clipboardText = e.DataObject.GetData(System.Windows.Forms.DataFormats.UnicodeText).ToString();
            }
            catch (Exception ex)
            {
                clipboardText = "Exception Occured while capturing clipboard: " + ex.ToString();
            }
            finally
            {
                WriteToLog(clipboardText);
            }
           
        }

        private void AutoSaveCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            AutoSaveEnabled = AutoSaveCheckbox.Checked;
        }

        private void UpdatePathButton_Click(object sender, EventArgs e)
        {
            //SetPath(PathTextBox.Text);
            DialogResult result = UpdatePathFolderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                SetPath(UpdatePathFolderBrowserDialog.SelectedPath, updateConfig:true);
            }
        }




        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void RunningLogTimer_Tick(object sender, EventArgs e)
        {
            string path = string.Format("{0}\\running_log_{1}.txt", this.basePath, DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss"));
            File.WriteAllText(path, RunningLog);
            RunningLog = string.Empty;
        }
    }
}
