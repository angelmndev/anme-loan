using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public class ReporteVentasRepositorio: MasterRepositorio
    {
        private string ventaReporte;
        private string reporteVentaCategoria;
        private string reporteVentaMarca;
        private string reporteVentaProducto;
        private string totalReporteVenta;
        public ReporteVentasRepositorio()
        {
            ventaReporte = "reporteVentas";
            reporteVentaCategoria = "reporteVentaCategoria";
            reporteVentaMarca = "reporteVentaMarca";
            reporteVentaProducto = "reporteVentaProducto";
            totalReporteVenta = "totalReporteVenta";
        }

        public DataTable ReporteVenta(DateTime fechaInicio,DateTime fechaFinal)
        {
            DataTable dt = reporteVentas(fechaInicio,fechaFinal, ventaReporte);
            return dt;
        }

        public IEnumerable<ReporteVenta> ReporteVentaCategoria(DateTime fechaInicio,DateTime fechaFinal,int Option)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fechaInicio", fechaInicio));
            parameters.Add(new SqlParameter("fechaFinal", fechaFinal));
            parameters.Add(new SqlParameter("Option", Option));
            var categoriaResult = ExecuteReaderSelect(reporteVentaCategoria);
            var listaCategoria = new List<ReporteVenta>();
            foreach(DataRow item in categoriaResult.Rows)
            {
                listaCategoria.Add(new ReporteVenta { 
                    cateNombre = item["cateNombre"].ToString(),
                    vedeCatidad = Convert.ToDouble(item["vedeCantidad"])
                });
            }

            return listaCategoria;
        }

        public IEnumerable<ReporteVenta> ReporteVentaMarca(DateTime fechaInicio, DateTime fechaFinal,int Option)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fechaInicio", fechaInicio));
            parameters.Add(new SqlParameter("fechaFinal", fechaFinal));
            parameters.Add(new SqlParameter("Option", Option));
            var marcaResult = ExecuteReaderSelect(reporteVentaMarca);
            var listaMarca = new List<ReporteVenta>();
            foreach (DataRow item in marcaResult.Rows)
            {
                listaMarca.Add(new ReporteVenta
                {
                    marcNombre = item["marcNombre"].ToString(),
                    vedeCatidad = Convert.ToDouble(item["vedeCantidad"])
                });
            }

            return listaMarca;
        }

        public IEnumerable<ReporteVenta> TotalReporteVenta(DateTime fechaInicio, DateTime fechaFinal)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fechaInicio", fechaInicio));
            parameters.Add(new SqlParameter("fechaFinal", fechaFinal));
            var resultReporteVenta = ExecuteReaderSelect(totalReporteVenta);
            var listaReporteVenta = new List<ReporteVenta>();
            foreach (DataRow item in resultReporteVenta.Rows)
            {
                listaReporteVenta.Add(new ReporteVenta
                {
                    vedeCatidad = Convert.ToDouble(item["totalVenta"])
                });
            }

            return listaReporteVenta;
        }

        public DataView ReporteVentaProducto(DateTime fechaInicio, DateTime fechaFinal,int Option)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fechaInicio", fechaInicio));
            parameters.Add(new SqlParameter("fechaFinal", fechaFinal));
            parameters.Add(new SqlParameter("Option", Option));
            DataView dv = new DataView();
            dv.Table = DataAdapterDBSentens(reporteVentaProducto);
            return dv;
        }

        public IEnumerable<ReporteVenta> ReportSalePreviousDate(int date)
        {
            parameters = new List<SqlParameter>();
            switch (date)
            {
                case 0: //Obtenemos las ventas por dia del presente mes
                    parameters.Add(new SqlParameter("Date", date));
                    
                    break;
                case 1://Obtenemos las ventas por mes del presente año
                    parameters.Add(new SqlParameter("Date", date));                
                    break;
                case 2://Obtenemos las ventas por hora de dia actual
                    parameters.Add(new SqlParameter("Date", date));                 
                    break;
                case 3://Obtenemos las ventas por hora de dia actual
                    parameters.Add(new SqlParameter("Date", date));
                    break;
                case 4://Obtenemos las ventas por hora de dia actual
                    parameters.Add(new SqlParameter("Date", date));
                    break;
            }
            var reporteVenta = ExecuteReaderSelect("ReportSalePreviousDate");
            var listaReporteVenta = new List<ReporteVenta>();
            foreach (DataRow item in reporteVenta.Rows)
            {
                listaReporteVenta.Add(new ReporteVenta
                {
                    vedePrecioVenta = Convert.ToDouble(item["vedePrecioVenta"]),
                    ventFechaVenta = (item["ventFechaVenta"]).ToString()
                });
            }

            return listaReporteVenta;
        }
        
    }
}
