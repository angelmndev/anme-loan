using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Usuario
    {
		public int pk_usuario { get; set; }
		public string usuaCodigo { get; set; }
		public string usuaNombre { get; set; }
		public string usuaApellido { get; set; }
		public string usuaUsuario { get; set; }
		public string usuaPassword { get; set; }
		public string usuaPrivilegios { get; set; }
		public string usuaTipoCuenta { get; set; }
		public string usuaTipoDocumento { get; set; }
		public double usuaNDocumento { get; set; }
		public string usuaSexo { get; set; }
		public string usuaCorreo { get; set; }
		public string usuaFoto { get; set; }
		public double usuaTelefono { get; set; }
		public int fk_sede { get; set; }
		public int usuaEstado { get; set; }
	}
}
