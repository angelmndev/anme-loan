using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class ClienteModel
    {
		public int pk_cliente { get; set; }
		public string clieNombre { get; set; }
		public double clieRucDni { get; set; }
		public string clieDireccion { get; set; }
		public string clieEmail { get; set; }
		public double clieDeuda { get; set; }
		public int clieEstado { get; set; }

		private ClienteRepositorio clienteRepositorio;
		public EstadoEntidad estado { get; set; }
		public ClienteModel()
		{
			clienteRepositorio = new ClienteRepositorio();
		}

		public string GuardarCambios()
		{
			string mensaje="";
			try
			{
				var clienteDataModel = new Cliente();
				clienteDataModel.pk_cliente = pk_cliente;
				clienteDataModel.clieNombre = clieNombre;
				clienteDataModel.clieRucDni = clieRucDni;
				clienteDataModel.clieDireccion = clieDireccion;
				clienteDataModel.clieEmail = clieEmail;
				clienteDataModel.clieDeuda = clieDeuda;
				clienteDataModel.clieEstado = clieEstado;

				switch (estado)
				{
					case EstadoEntidad.insertar:
						clienteRepositorio.insertar(clienteDataModel);
						break;
					case EstadoEntidad.modificar:
						clienteRepositorio.modificar(clienteDataModel);
						break;
					case EstadoEntidad.eliminar:
						clienteRepositorio.eliminar(pk_cliente);
						break;
				}
			}
			catch(Exception ex)
			{
				System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
				if (sqlEx != null && sqlEx.Number == 2627)
				{
					mensaje = "Se dato se duplica";
				}
			}
			return mensaje;
		}

		public DataView listarCliente()
		{
			DataView dv = clienteRepositorio.listar();
			return dv;
		}

		public void ActualizarEstado(int pk, int estado, string tabla) => clienteRepositorio.actualizarEstado(pk, estado, tabla);

		public IEnumerable<ClienteModel> seleccionarCliente(double dni)
		{
			var clienteDataModel = clienteRepositorio.seleccionarCliente(dni);
			List<ClienteModel> listaCliente = new List<ClienteModel>();
			foreach(var item in clienteDataModel)
			{
				listaCliente.Add(new ClienteModel
				{
					pk_cliente = item.pk_cliente,
					clieNombre = item.clieNombre,
					clieRucDni = item.clieRucDni,
					clieDireccion = item.clieDireccion,
					clieEmail = item.clieEmail,
					clieDeuda = item.clieDeuda,
					clieEstado = item.clieEstado

				});
			}

			return listaCliente;
		}
	}
}
