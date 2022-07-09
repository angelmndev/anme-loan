using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Ventas
    {
		public int pk_venta { get; set; }
		public int fk_cliente { get; set; }
		public int fk_personal { get; set; }
		public string ventDocuCodigo { get; set; }
		public string ventDocuNombre { get; set; }
		public int ventDocNumero { get; set; }
		public string ventDocuSerie { get; set; }
		public DateTime ventFechaVenta { get; set; }
		public int fk_formaPago { get; set; }
	}
}
