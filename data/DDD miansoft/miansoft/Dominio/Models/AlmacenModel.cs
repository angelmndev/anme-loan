using AccesoData.Entidades;
using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class AlmacenModel
    {
		public int pk_almacen { get; set; }
		public int fk_compra { get; set; }
		public int fk_producto { get; set; }
		public int fk_proveedr { get; set; }
		public string prodFechaVencimiento { get; set; }
		public double prodCantidad { get; set; }

		//propiedades adicionales
		public string prodCodigo { get; set; }
		public string prodDescripcion { get; set; }
		public string prodFoto { get; set; }
		public string cateNombre { get; set; }
		public string marcNombre { get; set; }
		public string unmeNombre { get; set; }
		public string preseNombre { get; set; }


		private AlmacenRepositorio almacenRepositorio;
		
		public AlmacenModel()
		{
			almacenRepositorio = new AlmacenRepositorio();
		}

		public DataView listarAlmacen(string estado)
		{
			DataView dv = almacenRepositorio.listar(estado);
			return dv;
		} 

		public int insertar()
		{
			var almacenDataModel = new Almacen();

			almacenDataModel.fk_compra = fk_compra;
			almacenDataModel.fk_producto = fk_producto;
			almacenDataModel.fk_proveedr = fk_proveedr;
			almacenDataModel.prodFechaVencimiento = prodFechaVencimiento;
			almacenDataModel.prodCantidad = prodCantidad;
			int result = almacenRepositorio.insertar(almacenDataModel);
			return result;
		}

		public IEnumerable<AlmacenModel> seleccionarProductoXCodigo(string codigo)
		{
			var almacenDataModel = almacenRepositorio.seleccionarProductoXCodigo(codigo);
			List<AlmacenModel> listaAlmacen = new List<AlmacenModel>();
			foreach(Almacen item in almacenDataModel)
			{
				listaAlmacen.Add(new AlmacenModel
				{
					fk_producto = item.fk_producto,
					prodCodigo = item.prodCodigo,
				});
			}

			return listaAlmacen;
		}

		public void listarProductoDescontar(int fk_producto, double cantidad)
		{
			almacenRepositorio.listarProductoDescontar(fk_producto,cantidad);
		}

		public IEnumerable<AlmacenModel> detalleAlmacenProducto(int fk_producto)
		{
			var dataProductoModel = almacenRepositorio.detalleAlmacenProducto(fk_producto);
			var listaProducto = new List<AlmacenModel>();
			foreach(var item in dataProductoModel)
			{
				listaProducto.Add(new AlmacenModel
				{
					fk_producto = item.fk_producto,
					prodDescripcion = item.prodDescripcion,
					prodCantidad = item.prodCantidad,
					prodCodigo = item.prodCodigo,
					prodFoto = item.prodFoto,
					cateNombre = item.cateNombre,
					preseNombre = item.preseNombre,
					unmeNombre = item.unmeNombre,
					marcNombre = item.marcNombre,
					prodFechaVencimiento = item.prodFechaVencimiento
				});
			}
			return listaProducto;
		}
	}
}
