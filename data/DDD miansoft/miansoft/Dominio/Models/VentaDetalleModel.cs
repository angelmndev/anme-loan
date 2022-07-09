using AccesoData.Entidades;
using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class VentaDetalleModel
    {
		public int pk_ventaDetalle { get; set; }
		public int fk_venta { get; set; }
		public int fk_producto { get; set; }
		public double vedeCantidad { get; set; }
		public double vedePrecioVenta { get; set; }
		public double vedeDscto { get; set; }

		private VentaDetalleRepositorio ventaDetalleRepositorio;
		public VentaDetalleModel()
		{
			ventaDetalleRepositorio = new VentaDetalleRepositorio();
		}

		public int insertar()
		{
			var vedeDataModel = new VentaDetalle();
			vedeDataModel.fk_venta = fk_venta;
			vedeDataModel.fk_producto = fk_producto;
			vedeDataModel.vedeCantidad = vedeCantidad;
			vedeDataModel.vedePrecioVenta = vedePrecioVenta;
			vedeDataModel.vedeDscto = vedeDscto;

			int result = ventaDetalleRepositorio.insertar(vedeDataModel);
			return result;
		}
	}
}
