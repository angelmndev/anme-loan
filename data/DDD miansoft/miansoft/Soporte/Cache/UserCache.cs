using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soporte.Cache
{
    public static class UserCache
    {
		public static int pk_usuario { get; set; }
		public static string usuaCodigo { get; set; }
		public static string usuaNombre { get; set; }
		public static string usuaApellido { get; set; }
		public static string usuaUsuario { get; set; }
		public static string usuaPassword { get; set; }
		public static string usuaPrivilegios { get; set; }
		public static int usuaEstado { get; set; }
		public static string usuaTipoCuenta { get; set; }
		public static string usuaTipoDocumento { get; set; }
		public static double usuaNDocumento { get; set; }
		public static string usuaSexo { get; set; }
		public static string usuaCorreo { get; set; }
		public static string usuaFoto { get; set; }
		public static double usuaTelefono { get; set; }
	}
}
