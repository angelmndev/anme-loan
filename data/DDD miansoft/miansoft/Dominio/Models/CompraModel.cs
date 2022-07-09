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
    public class CompraModel
    {

        public int pk_compra { get; set; }
        public int fk_proveedor { get; set; }
        public int fk_personal { get; set; }
        public string compDocuCodigo { get; set; }
        public string compDocuNombre { get; set; }
        public int compDocuNumero { get; set; }
        public string compFechaCompra { get; set; }
        public int compEstado { get; set; }

        private CompraRepositorio compraRepositorio;

        public CompraModel()
        {
            compraRepositorio = new CompraRepositorio();
        }

        public int insertar()
        {
            var compraDataModel = new Compra();
            compraDataModel.fk_proveedor = fk_proveedor;
            compraDataModel.fk_personal = fk_personal;
            compraDataModel.compDocuCodigo = compDocuCodigo;
            compraDataModel.compDocuNombre = compDocuNombre;
            compraDataModel.compDocuNumero = compDocuNumero;
            compraDataModel.compFechaCompra = compFechaCompra;
            compraDataModel.compEstado = compEstado;
            int result = compraRepositorio.insertar(compraDataModel);

            return result;

        }

        public DataView listarProductoCompra()
        {
            DataView dv = compraRepositorio.listarProductoCompra();
            return dv;
        }

        public int ultimoPkCompra()
        {
            int pkCompra = compraRepositorio.ultimoPkCompra();
            return pkCompra;
        }
    }
}
