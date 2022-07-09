using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Comprobante
    {
		public int pk_comprobante { get; set; }
		public string comCodigo { get; set; }
		public string comNombre { get; set; }
		public string comSerie { get; set; }
		public int comCorrelativo { get; set; }
		public int comEstado { get; set; }
	}
}
