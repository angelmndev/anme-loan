using AccesoData.Entidades;
using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
	public class ProveedorModel
	{
		public int pk_proveedor { get; set; }
		public string provNombre { get; set; }
		public double provRuc { get; set; }
		public string provDireccion { get; set; }
		public string provEmail { get; set; }
		public string provGiro { get; set; }
		public int provEstado { get; set; }

		private ProveedorRepositorio proveedorRepositorio;

		public ProveedorModel()
		{
			proveedorRepositorio = new ProveedorRepositorio();
		}

		private Proveedor dataProveedor()
		{
			var proveedorDataModel = new Proveedor();
			proveedorDataModel.pk_proveedor = pk_proveedor;
			proveedorDataModel.provNombre = provNombre;
			proveedorDataModel.provRuc = provRuc;
			proveedorDataModel.provDireccion = provDireccion;
			proveedorDataModel.provEmail = provEmail;
			proveedorDataModel.provGiro = provGiro;
			proveedorDataModel.provEstado = provEstado;

			return proveedorDataModel;
		}

		public int insertar()
		{
			int result = 0;
			try
			{
				result = proveedorRepositorio.insertar(dataProveedor());

			} catch (Exception ex)
			{
				SqlException sqlException = ex as SqlException;
				if (sqlException != null && sqlException.Number == 2627)
				{
					result = 0;
				}
			}
			return result;
		}

		public int modificar()
		{
			int result = 0;
			try
			{
				result = proveedorRepositorio.modificar(dataProveedor());

			}
			catch (Exception ex)
			{
				SqlException sqlException = ex as SqlException;
				if (sqlException != null && sqlException.Number == 2627)
				{
					result = 0;
				}
			}
			return result;
		}

		public DataView listar()
		{
			DataView dv = proveedorRepositorio.listar();
			return dv;
		}

		public int eliminar(int pk)
		{
			int result = proveedorRepositorio.eliminar(pk);
			return result;
		}

		public IEnumerable<ProveedorModel> seleccionarProveedorXRuc(double ruc)
		{
			var proveedorDataModel = proveedorRepositorio.seleccionarProveedor(ruc);
			var listaProveedor = new List<ProveedorModel>();
			foreach (var item in proveedorDataModel)
			{
				listaProveedor.Add(new ProveedorModel
				{
					pk_proveedor = item.pk_proveedor,
					provNombre = item.provNombre,
					provRuc = item.provRuc,
					provDireccion = item.provDireccion,
					provEmail = item.provEmail,
					provGiro = item.provGiro,
					provEstado = item.provEstado
				});
			}
			return listaProveedor;
		}

		public void ActualizarEstado(int pk, int estado, string tabla)
		{
			proveedorRepositorio.actualizarEstado(pk, estado, tabla);
		}
	}
}
