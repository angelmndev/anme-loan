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
    public class ComprobanteModel
    {
		public int pk_comprobante { get; set; }
		public string comCodigo { get; set; }
		public string comNombre { get; set; }
		public string comSerie { get; set; }
		public int comCorrelativo { get; set; }
		public int comEstado { get; set; }

		private ComprobanteRepositorio comprobanteRepositorio;
		public EstadoEntidad estado { get; set; }

		public ComprobanteModel()
		{
			comprobanteRepositorio = new ComprobanteRepositorio();
		}

		public string GuardarCambios()
		{
			string mensaje = string.Empty;
			try
			{
				var comprobanteDataModel = new Comprobante();
				comprobanteDataModel.pk_comprobante = pk_comprobante;
				comprobanteDataModel.comCodigo = comCodigo;
				comprobanteDataModel.comNombre = comNombre;
				comprobanteDataModel.comSerie = comSerie;
				comprobanteDataModel.comCorrelativo = comCorrelativo;
				comprobanteDataModel.comEstado = comEstado;

				switch (estado)
				{
					case EstadoEntidad.insertar:
						comprobanteRepositorio.insertar(comprobanteDataModel);
						break;
					case EstadoEntidad.modificar:
						comprobanteRepositorio.modificar(comprobanteDataModel);
						break;
					case EstadoEntidad.eliminar:
						comprobanteRepositorio.eliminar(pk_comprobante);
						break;
				}
			}
			catch(Exception ex)
			{
				SqlException sqlException = ex as SqlException;
				if(sqlException != null && sqlException.Number == 2627)
				{
					mensaje = "El codigo ya existe en la base de datos";
				}
			}
			return mensaje;
		}

		public DataView listarComprobante()
		{
			DataView dv = comprobanteRepositorio.listar();
			return dv;
		}

		public void ActualizarEstado(int pk, int estado, string tabla) => comprobanteRepositorio.actualizarEstado(pk, estado, tabla);

		public IEnumerable<ComprobanteModel> seleccionarComprobante(int pk_comprobante)
		{
			var comprobanteDataModel = comprobanteRepositorio.seleccionarComrobante(pk_comprobante);
			var listaComprobante = new List<ComprobanteModel>();
			foreach(var item in comprobanteDataModel)
			{
				listaComprobante.Add(new ComprobanteModel
				{
					pk_comprobante = item.pk_comprobante,
					comCodigo = item.comCodigo,
					comNombre = item.comNombre,
					comSerie = item.comSerie,
					comCorrelativo = item.comCorrelativo,
					comEstado = item.comEstado

				});
			}
			return listaComprobante;
		} 
	}
}
