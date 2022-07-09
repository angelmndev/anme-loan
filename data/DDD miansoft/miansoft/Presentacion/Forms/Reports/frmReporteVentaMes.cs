using DevExpress.Utils;
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

namespace Presentacion.Forms.Reports
{
    public partial class frmReporteVentaMes : Form
    {
        private ReporteVentaModel reporteVenta = new ReporteVentaModel();
        public frmReporteVentaMes()
        {
            InitializeComponent();
        }

        private void ReportSalePreviousDate()
        {
            //0=>Obtenemos las ventas por dia del presente mes    
            //1=>Obtenemos las ventas por mes del presente año         
            //2=>Obtenemos las ventas por hora de dia actual
            //3=>Obtenemos las ventas por dia anterior
            //4=>Obtenemos las ventas por mes anterior
            IEnumerable<ReporteVentaModel> listaReporteVentaMonth = reporteVenta.ReportSalePreviousDate(0);
            IEnumerable<ReporteVentaModel> listaReporteVentaLastMonth = reporteVenta.ReportSalePreviousDate(4);

            //Creamos series de tipo Spline
            Series seriesToday = new Series("Mes actual", ViewType.Spline);
            Series seriesYesterday = new Series("Mes anterior", ViewType.Spline);

            //Agregamos Point de venta del dia de hoy
            foreach (var item in listaReporteVentaMonth)
            {
                seriesToday.Points.Add(new SeriesPoint(item.ventFechaVenta, item.vedePrecioVenta));
            }

            //Agregamos Point de venta del dia anterior
            foreach (var item in listaReporteVentaLastMonth)
            {
                seriesYesterday.Points.Add(new SeriesPoint(item.ventFechaVenta, item.vedePrecioVenta));
            }

            //Hacenos que la leyenda sea visible ↓
            chrtComparacionVentas.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            //Hacemos que EjeX sea ordenado por horas
            seriesToday.ArgumentScaleType = ScaleType.Qualitative;
            seriesYesterday.ArgumentScaleType = ScaleType.Qualitative;

            //Agregamos los series al chart
            chrtComparacionVentas.Series.Add(seriesToday);
            chrtComparacionVentas.Series.Add(seriesYesterday);

            //mostramos valor en los labels y pintamos de fondo de Transparente
            XYDiagram xYDiagram = chrtComparacionVentas.Diagram as XYDiagram;
            xYDiagram.DefaultPane.BackColor = Color.Transparent;
            xYDiagram.AxisY.Label.TextPattern = "{V:C}";

            //Se cambia el color de las lineas
            Series s1 = chrtComparacionVentas.Series[1];
            s1.View.Color = Color.Red;
            ((LineSeriesView)s1.View).LineStyle.DashStyle = DashStyle.Solid;
            Series s2 = this.chrtComparacionVentas.Series[0];
            s2.View.Color = Color.Green;
            ((LineSeriesView)s2.View).LineStyle.DashStyle = DashStyle.Solid;

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

            //Se especifica el orden de los Points
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
            dgVentasDia.Columns["prodDescripcion"].Caption = "DESCRIPCION";
            dgVentasDia.Columns["vedePrecioVenta"].Caption = "PRECIO VENTA";
            dgVentasDia.Columns["vedeCantidad"].Caption = "CANTIDAD";

            //Colocamos numeros con formato de moneda ↓
            dgVentasDia.Columns["vedePrecioVenta"].DisplayFormat.FormatType = FormatType.Numeric;
            dgVentasDia.Columns["vedePrecioVenta"].DisplayFormat.FormatString = "c2";


            dgVentasDia.OptionsBehavior.AutoPopulateColumns = true;
            dgVentasDia.BestFitColumns();
        }
        private void frmReporteVentaMes_Load(object sender, EventArgs e)
        {
            ReportSalePreviousDate();
            chartVentaCategoria();
            chartVentaMarca();
            reporteVentaProducto();
            EstiloDG();
        }
    }
}
