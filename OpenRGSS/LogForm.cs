using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace OpenRGSS
{
    partial class LogForm : Form
    {
        private static Thread logThread = new Thread(RunLogForm);
        private static LogForm instance;

        public static LogForm GetInstance()
        {
            if (instance == null)
            {
                lock (logThread)
                {
                    if (instance == null)
                    {
                        instance = new LogForm();
                        logThread.Start();
                    }
                }
            }

            return instance;
        }

        private static void RunLogForm()
        {
            Application.Run(instance);
        }

        public LogForm()
        {
            InitializeComponent();
        }

        public void Debug(string text)
        {
            if (this.logBox.IsHandleCreated)
            {
                this.logBox.Invoke(new Action(() =>
                {
                    this.logBox.AppendText(text + "\r\n");
                }));
            }
        }
    }
}
