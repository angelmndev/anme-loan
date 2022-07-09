using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class VentaDetalle
    {
		public int pk_ventaDetalle { get; set; }
		public int fk_venta { get; set; }
		public int fk_producto { get; set; }
		public double vedeCantidad { get; set; }
		public double vedePrecioVenta { get; set; }
		public double vedeDscto { get; set; }

	}
}
