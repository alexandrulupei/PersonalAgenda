using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Comenzi
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
            if (new LoginWindow().ShowDialog() == DialogResult.Cancel)
                Application.Exit();
            else
                Application.Run(new MainWindow());
        }
    }
}
