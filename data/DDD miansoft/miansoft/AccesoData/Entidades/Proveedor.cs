using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Proveedor
    {
		public int pk_proveedor { get; set; }
		public string provNombre { get; set; }
		public double provRuc { get; set; }
		public string provDireccion { get; set; }
		public string provEmail { get; set; }
		public string provGiro { get; set; }
		public int provEstado { get; set; }

	}
}
