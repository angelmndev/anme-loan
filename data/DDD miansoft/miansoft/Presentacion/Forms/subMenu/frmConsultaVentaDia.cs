using DevExpress.XtraReports.Native;
using Dominio.Models.ReporteVentasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.subMenu
{
    public partial class frmConsultaVentaDia : Form
    {
        private ReporteVentasModel reporteVentasModel = new ReporteVentasModel();
        public frmConsultaVentaDia()
        {
            InitializeComponent();
        }

        private void frmConsultaVentaDia_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            //var fromDay = DateTime.Today;
            //var toDate = DateTime.Now;
            DateTime fromDay = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;
            mostrarReporteVentas(fromDay, toDate);


          
        }

        private void mostrarReporteVentas(DateTime fechaInicio,DateTime fechaFinal)
        {
            reporteVentasModel.reporteVenta(fechaInicio,fechaFinal);
            ReporteVentasModelBindingSource.DataSource = reporteVentasModel;
            ListaReporteVentasBindingSource.DataSource = reporteVentasModel.listaReporteVentas;
            ReporteVentasPeriodoBindingSource.DataSource = reporteVentasModel.reporteVentasPeriodos;
            this.reportViewer1.RefreshReport();
        }
    }
}
