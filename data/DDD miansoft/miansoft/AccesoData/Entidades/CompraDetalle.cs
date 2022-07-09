using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class CompraDetalle
	{
		public int pk_compraDetalle { get; set; }
		public int fk_compra { get; set; }
		public int fk_producto { get; set; }
		public double codeCantidad { get; set; }
		public double codePrecioCompra { get; set; }
		public string codeFechaVencimiento { get; set; }
	}
}
