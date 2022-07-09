using AccesoData.Entidades;
using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class VentaModel
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

		private VentaRepositorio ventaRepositorio;

		public VentaModel()
		{
			ventaRepositorio = new VentaRepositorio();
		}

		public int insertar()
		{
			var ventaDataModel = new Ventas();
			ventaDataModel.pk_venta = pk_venta;
			ventaDataModel.fk_cliente = fk_cliente;
			ventaDataModel.fk_personal = fk_personal;
			ventaDataModel.ventDocuCodigo = ventDocuCodigo;
			ventaDataModel.ventDocuNombre = ventDocuNombre;
			ventaDataModel.ventDocNumero = ventDocNumero;
			ventaDataModel.ventDocuSerie = ventDocuSerie;
			ventaDataModel.ventFechaVenta = ventFechaVenta;
			ventaDataModel.fk_formaPago = fk_formaPago;
			int result = ventaRepositorio.insertar(ventaDataModel);

			return result;
		}

		public int ultimoPkVenta()
		{
			int pkVenta = ventaRepositorio.ultimoPkVenta();
			return pkVenta;
		}
	}
}
