using Presentacion.Forms;
using Presentacion.Forms.frmDetails;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.Main;
using Presentacion.Forms.subMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain/*Forms.Reports.frmReporteVentaMes*/());
        }
    }
}
