using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Timer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Mutex s_Mutex = new Mutex(true, "m_Timer");
            if (s_Mutex.WaitOne(0, false))
                Application.Run(new Timer());
            else
            {
                MessageBox.Show(
                    "Another Timer is already running! (we have to close this one)",
                    "Timer Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}