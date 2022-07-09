using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Almacen
    {
		public int pk_almacen { get; set; }
		public int fk_compra { get; set; }
		public int fk_producto { get; set; }
		public int fk_proveedr { get; set; }
		public string prodFechaVencimiento { get; set; }
		public double prodCantidad { get; set; }

		//atributos adicionales
		public string prodCodigo { get; set; }
		public string prodDescripcion { get; set; }
		public string prodFoto { get; set; }
		public string cateNombre { get; set; }
		public string preseNombre { get; set; }
		public string marcNombre { get; set; }
		public string unmeNombre { get; set; }

	}
}
