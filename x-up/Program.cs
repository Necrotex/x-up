using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace x_up
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
            Logs.getLatestFleetLog();
            Application.Run(new Form1());
        }
    }
}
