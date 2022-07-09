using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class UsuarioModel
    {
		public int pk_usuario { get; set; }
		public string usuaCodigo { get; set; }
		public string usuaNombre { get; set; }
		public string usuaApellido { get; set; }
		public string usuaUsuario { get; set; }
		public string usuaPassword { get; set; }
		public string usuaPrivilegios { get; set; }
		public int usuaEstado { get; set; }
		public string usuaTipoCuenta { get; set; }
		public string usuaTipoDocumento { get; set; }
		public double usuaNDocumento { get; set; }
		public string usuaSexo { get; set; }
		public string usuaCorreo { get; set; }
		public string usuaFoto { get; set; }
		public double usuaTelefono { get; set; }
		public int fk_sede { get; set; }

		private UsuarioRepositorio usuarioRepositorio;
		public EstadoEntidad estado { get; set; }

		public UsuarioModel()
		{
			usuarioRepositorio = new UsuarioRepositorio();
		}

		public string GuardarCambios()
		{
			string mensaje = string.Empty;
			try
			{
				var usuarioDataModel = new Usuario();
				usuarioDataModel.pk_usuario = pk_usuario;
				usuarioDataModel.usuaCodigo =usuaCodigo;
				usuarioDataModel.usuaNombre =usuaNombre;
				usuarioDataModel.usuaApellido =usuaApellido;
				usuarioDataModel.usuaUsuario =usuaUsuario;
				usuarioDataModel.usuaPassword =usuaPassword;
				usuarioDataModel.usuaPrivilegios =usuaPrivilegios;
				usuarioDataModel.usuaEstado = usuaEstado;
				usuarioDataModel.usuaTipoCuenta =usuaTipoCuenta;
				usuarioDataModel.usuaTipoDocumento =usuaTipoDocumento;
				usuarioDataModel.usuaNDocumento =usuaNDocumento;
				usuarioDataModel.usuaSexo =usuaSexo;
				usuarioDataModel.usuaCorreo =usuaCorreo;
				usuarioDataModel.usuaFoto =usuaFoto;
				usuarioDataModel.usuaTelefono = usuaTelefono;

				switch (estado)
				{
					case EstadoEntidad.insertar:
						usuarioRepositorio.insertar(usuarioDataModel);
						break;
					case EstadoEntidad.modificar:
						usuarioRepositorio.modificar(usuarioDataModel);
						break;
					case EstadoEntidad.eliminar:
						usuarioRepositorio.eliminar(pk_usuario);
						break;
				}
			}
			catch(Exception ex)
			{
				SqlException sqlEx = ex as SqlException;
				if(sqlEx!=null&&sqlEx.Number == 2627)
				{
					mensaje = "El codifo y/o usuario se duplica";
				}
			}
			return mensaje;
		}

		public DataView listarUsuario()
		{
			DataView dv = usuarioRepositorio.listar();
			return dv;
		}

		public void ActualizarEstado(int pk, int estado, string tabla) => usuarioRepositorio.actualizarEstado(pk, estado, tabla);

		public IEnumerable<UsuarioModel> seleccionarUsuarioXSede(int fk_sede, string sedeDireccion, string usuaTipoCuenta)
		{
			var usuarioDataModel = usuarioRepositorio.seleccionarUsuarioXSede(fk_sede, sedeDireccion, usuaTipoCuenta);
			var listaUsuario = new List<UsuarioModel>();
			foreach(var item in usuarioDataModel)
			{
				listaUsuario.Add(new UsuarioModel
				{
					pk_usuario = item.pk_usuario,
					usuaCodigo = item.usuaCodigo,
					usuaNombre = item.usuaNombre,
					usuaApellido = item.usuaApellido,
					usuaUsuario = item.usuaUsuario,
					usuaPassword = item.usuaPassword,
					usuaPrivilegios = item.usuaPrivilegios,
					usuaEstado = item.usuaEstado,
					usuaTipoCuenta = item.usuaTipoCuenta,
					usuaTipoDocumento = item.usuaTipoDocumento,
					usuaNDocumento = item.usuaNDocumento,
					usuaSexo = item.usuaSexo,
					usuaCorreo = item.usuaCorreo,
					usuaFoto = item.usuaFoto,
					usuaTelefono = item.usuaTelefono

				});
			}

			return listaUsuario;
		}
	}
}
