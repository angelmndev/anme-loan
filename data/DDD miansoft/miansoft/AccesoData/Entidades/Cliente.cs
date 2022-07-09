using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Cliente
    {
		public int pk_cliente { get; set; }
		public string clieNombre { get; set; }
		public double clieRucDni { get; set; }
		public string clieDireccion { get; set; }
		public string clieEmail { get; set; }
		public double clieDeuda { get; set; }
		public int clieEstado { get; set; }
	}
}
