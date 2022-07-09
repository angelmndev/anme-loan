using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class ReporteVenta
    {
        public string cateNombre { get; set; }
        public string marcNombre { get; set; }
        public double vedeCatidad { get; set; }
        public string ventFechaVenta { get; set; }
        public double totalVenta { get; set; }
        public double vedePrecioVenta { get; set; }
    }
}
