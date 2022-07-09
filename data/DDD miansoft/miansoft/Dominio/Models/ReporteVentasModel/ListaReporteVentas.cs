using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models.ReporteVentasModel
{
    public class ListaReporteVentas
    {
        public string prodDescripcion { get; set; }
        public double vedeCantidad { get; set; } 
        public double vedePrecioVenta { get; set; }
        public string cateNombre { get; set; }
        public string preseNombre { get; set; }
        public string unmeNombre { get; set; }
        public string marcNombre { get; set; }
        public string persNombre { get; set; }
        public string clieNombre { get; set; }
        public DateTime ventFechaVenta { get; set; }
        public double vedeImporte { get; set; }

       
    }
}
