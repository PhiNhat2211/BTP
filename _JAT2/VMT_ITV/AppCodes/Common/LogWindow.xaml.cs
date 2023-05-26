using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VMT_ITV
{
	/// <summary>
	/// Interaction logic for LogWin.xaml
	/// </summary>
	public partial class LogWindow : Window
	{
		public LogWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        public void WriteLog(string log, bool newline = true)
        {
            this.Dispatcher.Invoke(new Action(
                delegate()
                {
                    if (this.TB_Log == null)
                        return;

                    if (newline)
                        log += "\r\n";

                    // Add Time Value
                    string now = DateTime.Now.ToString("[HH:MM:ss]");
                    log = now + " " + log;

                    string strLog = log;
                    strLog += TB_Log.Text;

                    if (strLog.Length > 10000)
                        strLog = strLog.Substring(0, 10000);

                    this.TB_Log.Text = strLog;
                }
                ));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            // Hide Log Window
            this.Hide();
        }


	}
}