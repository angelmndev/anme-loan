using AccesoData.Entidades;
using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
	public class CompraDetalleModel
	{
		public int pk_compraDetalle { get; set; }
		public int fk_compra { get; set; }
		public int fk_producto { get; set; }
		public double codeCantidad { get; set; }
		public double codePrecioCompra { get; set; }
		public string codeFechaVencimiento { get; set; }

		private CompraDetalleRepositorio compraDetalle;
		public CompraDetalleModel()
		{
			compraDetalle = new CompraDetalleRepositorio();
		}

		public int insertar()
		{
			var codeDataModel = new CompraDetalle();
			codeDataModel.fk_compra = fk_compra;
			codeDataModel.fk_producto = fk_producto;
			codeDataModel.codeCantidad = codeCantidad;
			codeDataModel.codePrecioCompra = codePrecioCompra;
			codeDataModel.codeFechaVencimiento = codeFechaVencimiento;
			int result = compraDetalle.insertar(codeDataModel);

			return result;
		}
	}
}
