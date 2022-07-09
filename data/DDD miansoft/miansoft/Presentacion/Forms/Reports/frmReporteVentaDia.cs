using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;
using Dominio.Models;
using Presentacion.MyLibrary;
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
    public partial class frmReporteVentaDia : Form
    {
        private ProductoModel productoModel = new ProductoModel();
        private ReporteVentaModel reporteVenta = new ReporteVentaModel();

        public frmReporteVentaDia()
        {
            InitializeComponent();
            dgVentasDia.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgVentasDia.OptionsView.EnableAppearanceEvenRow = true;
            reporteVentaProducto();
           
        }

        private void reporteVentaProducto()
        {
            gridVentasDia.DataSource = reporteVenta.ReporteVentaProducto(DateTime.Now, DateTime.Now,0);
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
        private void frmReporteVentaDia_Load(object sender, EventArgs e)
        {
            chartVentaCategoria();
            chartVentaMarca();
            ReportSalePreviousDate();
            EstiloDG();        
        }

        private void ReportSalePreviousDate()
        {
            //0=>Obtenemos las ventas por dia del presente mes    
            //1=>Obtenemos las ventas por mes del presente año         
            //2=>Obtenemos las ventas por hora de dia actual
            //3=>Obtenemos las ventas por dia anterior
            IEnumerable<ReporteVentaModel> listaReporteVentaToday = reporteVenta.ReportSalePreviousDate(2);
            IEnumerable<ReporteVentaModel> listaReporteVentaYesterday = reporteVenta.ReportSalePreviousDate(3);

            //Creamos series de tipo Spline
            Series seriesToday = new Series("Hoy", ViewType.Spline);
            Series seriesYesterday = new Series("Ayer", ViewType.Spline);

            //Agregamos Point de venta del dia de hoy
            foreach(var item in listaReporteVentaToday)
            {
                seriesToday.Points.Add(new SeriesPoint(item.ventFechaVenta+" Horas", item.vedePrecioVenta));
            }

            //Agregamos Point de venta del dia anterior
            foreach (var item in listaReporteVentaYesterday)
            {
                seriesYesterday.Points.Add(new SeriesPoint(item.ventFechaVenta+" Horas", item.vedePrecioVenta));
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

            IEnumerable<ReporteVentaModel> listaVenta = reporteVenta.ReporteVentaCategoria(DateTime.Now,DateTime.Now,0);
            foreach(var item in listaVenta)
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

                IEnumerable<ReporteVentaModel> listaVenta = reporteVenta.ReporteVentaMarca(DateTime.Now, DateTime.Now,0);
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

        private void dgVentasDia_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
        }

        private void dgVentasDia_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style st = new style();
            st.rowStyle(sender, e);
        }

        private void dgVentasDia_ShownEditor(object sender, EventArgs e)
        {
         
        }

        private void dgVentasDia_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                e.Cancel = true;
        }
    }
}
