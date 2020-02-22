using IPChanger.SubForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPChanger
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

            if (System.Environment.MachineName == "GIG001P10345")
            {
                Application.Run(new frmPezeshki());
            }
            else
            {
                Application.Run(new Main());
            }
            
        }
    }
}
