﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamnSimpleClipboardCapture
{
    /// <summary>
    /// Monitors the clipboard for changes
    /// See: http://stackoverflow.com/questions/621577/clipboard-event-c-sharp/2487582#2487582
    /// </summary>
    [DefaultEvent("ClipboardChanged")]
    public partial class ClipboardMonitor : Control
    {
        private IntPtr nextClipboardViewer;

        public ClipboardMonitor()
        {
            this.BackColor = Color.Red;
            this.Visible = false;
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        /// <summary>
        /// Clipboard contents changed.
        /// </summary>
        public event EventHandler<ClipboardChangedEventArgs> ClipboardChanged;

        protected override void Dispose(bool disposing)
        {
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    OnClipboardChanged();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected void OnClipboardChanged()
        {
            try
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (ClipboardChanged != null)
                {
                    ClipboardChanged(this, new ClipboardChangedEventArgs(iData));
                }

            }
            catch (Exception e)
            {
                // Swallow or pop-up, not sure
                // Trace.Write(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(int hWndNewViewer);
    }

    public class ClipboardChangedEventArgs : EventArgs
    {
        public readonly IDataObject DataObject;

        public ClipboardChangedEventArgs(IDataObject dataObject)
        {
            DataObject = dataObject;
        }
    }
}
