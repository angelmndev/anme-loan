using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models.ReporteVentasModel
{
    public class ReporteVentasModel
    {
        public DateTime reportDate { get; private set; }
        public DateTime fechaInicial { get; private set; }
        public DateTime fechaFinal { get; private set; }
        public List<ListaReporteVentas> listaReporteVentas { get; private set; }
        public List<ReporteVentasPeriodo> reporteVentasPeriodos { get; private set; }
        public double totalVentas { get; private set; }

        private ReporteVentasRepositorio reporteVentas;

        public ReporteVentasModel()
        {
            reporteVentas = new ReporteVentasRepositorio();
        }

        public void reporteVenta(DateTime dateInicio, DateTime dateFinal)
        {
            reportDate = DateTime.Now;
            fechaFinal = dateInicio;
            fechaFinal = dateFinal;
            var resultVenta = reporteVentas.ReporteVenta(dateInicio,dateFinal);
            listaReporteVentas = new List<ListaReporteVentas>();

            foreach (DataRow item in resultVenta.Rows)
            {
                var ventaModel = new ListaReporteVentas()
                {
                    prodDescripcion = item["prodDescripcion"].ToString(),
                    vedeCantidad = Convert.ToDouble(item["vedeCantidad"]),
                    vedePrecioVenta = Convert.ToDouble(item["vedePrecioVenta"]),
                    cateNombre = item["cateNombre"].ToString(),
                    preseNombre = item["preseNombre"].ToString(),
                    unmeNombre = item["unmeNombre"].ToString(),
                    marcNombre = item["marcNombre"].ToString(),
                    persNombre = item["persNombre"].ToString(),
                    clieNombre = item["clieNombre"].ToString(),
                    ventFechaVenta = Convert.ToDateTime(item["ventFechaVenta"]),
                    vedeImporte =  Convert.ToDouble(item["vedeImporte"])
                };

                listaReporteVentas.Add(ventaModel);
                totalVentas += Convert.ToDouble(item["vedeImporte"]);
            }

            var reporteVentaFecha = (from ventas in listaReporteVentas
                                     group ventas by ventas.ventFechaVenta
                                          into listaVentas
                                          select new
                                          {
                                              date = listaVentas.Key,
                                              montoTotal = listaVentas.Sum(item => item.vedeImporte)
                                          }).AsEnumerable();

            int totalDias = Convert.ToInt32((dateFinal - dateInicio).Days);

            //agrupar por dias
            if(totalDias <= 7)
            {
                reporteVentasPeriodos = (from ventas in reporteVentaFecha
                                         group ventas by ventas.date.ToString("dd-MMM-yyyy")
                                         into listaVentas
                                         select new ReporteVentasPeriodo
                                         {
                                             periodo = listaVentas.Key,
                                             ventaTotal = listaVentas.Sum(item => item.montoTotal)
                                         }).ToList();
            }

            else if(totalDias <= 30)
            {
                reporteVentasPeriodos = (from ventas in reporteVentaFecha
                                         group ventas by
                                         System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                             ventas.date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                        into listaVentas
                                         select new ReporteVentasPeriodo
                                         {
                                             periodo = "Semana"+listaVentas.Key.ToString(),
                                             ventaTotal = listaVentas.Sum(item => item.montoTotal)
                                         }).ToList();
            }

            else if(totalDias <= 365)
            {
                reporteVentasPeriodos = (from ventas in reporteVentaFecha
                                         group ventas by ventas.date.ToString("MMM-yyyy")
                                       into listaVentas
                                         select new ReporteVentasPeriodo
                                         {
                                             periodo = listaVentas.Key,
                                             ventaTotal = listaVentas.Sum(item => item.montoTotal)
                                         }).ToList();
            }
            else
            {
                reporteVentasPeriodos = (from ventas in reporteVentaFecha
                                         group ventas by ventas.date.ToString("yyyy")
                                       into listaVentas
                                         select new ReporteVentasPeriodo
                                         {
                                             periodo = listaVentas.Key,
                                             ventaTotal = listaVentas.Sum(item => item.montoTotal)
                                         }).ToList();
            }
                                          
        }
        
    }
}
