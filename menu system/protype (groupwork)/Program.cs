using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace protype__groupwork_
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
            //Application.Run(new frmMenus());
            Application.Run(new FrmTableIdentification());

            //Application.Run(new FrmPayment());
            //Application.Run(new frmMenus());
            //Application.Run(new FrmTrackOrder());
        }
    }
}
