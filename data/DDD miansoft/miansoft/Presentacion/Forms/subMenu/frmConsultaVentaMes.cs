using DevExpress.XtraCharts;
using Dominio.Models;
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
    public partial class frmConsultaVentaMes : Form
    {
        private ReporteVentaModel reporteVenta = new ReporteVentaModel();
        public frmConsultaVentaMes()
        {
            InitializeComponent();
        }

        private void ReportSalePreviousDate()
        {
            IEnumerable<ReporteVentaModel> listaReporteVenta = reporteVenta.ReportSalePreviousDate(2);
            IEnumerable<ReporteVentaModel> listaReporteVentaToday = reporteVenta.ReportSalePreviousDate(3);
            // Create two area series.
            Series serieYesterday = new Series("Series 1", ViewType.Area);
            Series serieToday = new Series("Series 2", ViewType.Area);

            foreach (var item in listaReporteVenta)
            {
                serieYesterday.Points.Add(new SeriesPoint("Ayer", item.vedePrecioVenta));

            }

            foreach (var item in listaReporteVentaToday)
            {
                serieToday.Points.Add(new SeriesPoint("Hoy", item.vedePrecioVenta));
            }
            // Add both series to the chart.
            chrtComparacionVentas.Series.AddRange(new Series[] { serieToday, serieYesterday });
        }
        private void chartVentaCategoria()
        {
            Series serie = new Series("Pie Series 1", ViewType.Pie3D);

            IEnumerable<ReporteVentaModel> listaVenta = reporteVenta.ReporteVentaCategoria(DateTime.Now, DateTime.Now,1);
            foreach (var item in listaVenta)
            {
                serie.Points.Add(new SeriesPoint(item.cateNombre, item.vedeCatidad));
            }

            chrtCategoria.Series.Add(serie);
            serie.Label.TextPattern = "{A}: {V}";

            //Specify how series points are sorted.
            serie.SeriesPointsSorting = SortingMode.Ascending;
            serie.SeriesPointsSortingKey = SeriesPointKey.Argument;

            ((Pie3DSeriesLabel)serie.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((Pie3DSeriesLabel)serie.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
            ((Pie3DSeriesLabel)serie.Label).ResolveOverlappingMinIndent = 5;
        }

        private void chartVentaMarca()
        {
            try
            {
                Series serie = new Series("Pie Series 1", ViewType.Doughnut3D);

                IEnumerable<ReporteVentaModel> listaVenta = reporteVenta.ReporteVentaMarca(DateTime.Now, DateTime.Now,1);
                foreach (var item in listaVenta)
                {
                    serie.Points.Add(new SeriesPoint(item.marcNombre, item.vedeCatidad));
                }

                //Se agrega los series al chart
                chrtMarca.Series.Add(serie);

                //Muestra los label con nombre y vlaor
                serie.Label.TextPattern = "{A}: {V}";

                //Muestra la leyenda de forma ascendente
                serie.SeriesPointsSorting = SortingMode.Ascending;
                serie.SeriesPointsSortingKey = SeriesPointKey.Argument;

                //Separa los labels de los charts
                ((Doughnut3DSeriesLabel)serie.Label).Position = PieSeriesLabelPosition.TwoColumns;
                ((Doughnut3DSeriesLabel)serie.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
                ((Doughnut3DSeriesLabel)serie.Label).ResolveOverlappingMinIndent = 5;

                //separa un point en especifico
                ((Doughnut3DSeriesView)serie.View).ExplodedPoints.Add(serie.Points[0]);
                ((Doughnut3DSeriesView)serie.View).ExplodedDistancePercentage = 10;
            }
            catch
            {

            }

        }
        private void reporteVentaProducto()
        {
            gridVentasDia.DataSource = reporteVenta.ReporteVentaProducto(DateTime.Now, DateTime.Now,1);
        }

        private void EstiloDG()
        {
            dgVentasDia.Columns["fk_producto"].Visible = false;
            dgVentasDia.Columns["vedePrecioVenta"].Caption = "PRECIO VENTA";
            dgVentasDia.Columns["vedeCantidad"].Caption = "CANTIDAD";
        }
        private void frmConsultaVentaMes_Load(object sender, EventArgs e)
        {
            chartVentaCategoria();
            chartVentaMarca();
            reporteVentaProducto();
            EstiloDG();
            ReportSalePreviousDate();
        }
    }
}
