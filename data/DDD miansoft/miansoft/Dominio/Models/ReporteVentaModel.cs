using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class ReporteVentaModel
    {
        public string cateNombre { get; set; }
        public string marcNombre { get; set; }
        public double vedeCatidad { get; set; }
        public string ventFechaVenta { get; set; }
        public double totalVenta { get; set; }
        public double vedePrecioVenta { get; set; }

        private ReporteVentasRepositorio reporteVentasRepositorio;

        public ReporteVentaModel()
        {
            reporteVentasRepositorio = new ReporteVentasRepositorio();
        }

        public IEnumerable<ReporteVentaModel> ReporteVentaCategoria(DateTime fechaInicio, DateTime fechaFinal,int Option)
        {
            var reporteDataVenta = reporteVentasRepositorio.ReporteVentaCategoria(fechaInicio, fechaFinal, Option);
            var listaVentaCategoria = new List<ReporteVentaModel>();
            foreach(var item in reporteDataVenta)
            {
                listaVentaCategoria.Add(new ReporteVentaModel
                {
                    cateNombre = item.cateNombre,
                    vedeCatidad = item.vedeCatidad
                });
            }
            return listaVentaCategoria;
        }

        public IEnumerable<ReporteVentaModel> ReporteVentaMarca(DateTime fechaInicio, DateTime fechaFinal,int Option)
        {
            var reporteDataVenta = reporteVentasRepositorio.ReporteVentaMarca(fechaInicio, fechaFinal, Option);
            var listaVentaMarca = new List<ReporteVentaModel>();
            foreach (var item in reporteDataVenta)
            {
                listaVentaMarca.Add(new ReporteVentaModel
                {
                    marcNombre = item.marcNombre,
                    vedeCatidad = item.vedeCatidad
                });
            }
            return listaVentaMarca;
        }

        public IEnumerable<ReporteVentaModel> ReportSalePreviousDate(int date)
        {
            var resultDataVenta = reporteVentasRepositorio.ReportSalePreviousDate(date);
            var listaReporteVenta = new List<ReporteVentaModel>();
            foreach(var item in resultDataVenta)
            {
                listaReporteVenta.Add(new ReporteVentaModel
                {
                    vedePrecioVenta = item.vedePrecioVenta,
                    ventFechaVenta = item.ventFechaVenta
                });
            }
            return listaReporteVenta;
        }

        public IEnumerable<ReporteVentaModel> TotalReporteVenta(DateTime fechaInicio, DateTime fechaFinal,int Option)
        {
            var reporteDataVenta = reporteVentasRepositorio.ReporteVentaMarca(fechaInicio, fechaFinal, Option);
            var listaReportVenta = new List<ReporteVentaModel>();
            foreach (var item in reporteDataVenta)
            {
                listaReportVenta.Add(new ReporteVentaModel
                {
                    vedePrecioVenta = item.vedePrecioVenta
                });
            }
            return listaReportVenta;
        }

        public DataView ReporteVentaProducto(DateTime fechaInicio, DateTime fechaFinal,int Option)
        {
            DataView dv = reporteVentasRepositorio.ReporteVentaProducto(fechaInicio, fechaFinal,Option);
            return dv;
        }
    }
}
