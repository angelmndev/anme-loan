using AccesoData.Contratos;
using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public class AlmacenRepositorio : MasterRepositorio,IAlmacenRepositorio
    {
        private string Listar;
        private string Insertar;
        private string SeleccionarXCodigo;
        private string CantidadProductoAlmacen;
        private string DescontarStocK;
        private string DetalleAlmacenProducto;
        public AlmacenRepositorio()
        {
            Listar = "detalleAlmacen";
            Insertar = "insertarAlmacen";
            SeleccionarXCodigo = "seleccionarProductoXCodigo";
            CantidadProductoAlmacen = "cantidadProductoAlmacen";
            DescontarStocK = "descontarStock";
            DetalleAlmacenProducto = "detalleAlmacenProducto";
        }

        public int insertar(Almacen entidad)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_compra",entidad.fk_compra));
            parameters.Add(new SqlParameter("fk_producto",entidad.fk_producto));
            parameters.Add(new SqlParameter("fk_proveedr",entidad.fk_proveedr));
            parameters.Add(new SqlParameter("prodFechaVencimiento",entidad.prodFechaVencimiento));
            parameters.Add(new SqlParameter("prodCantidad",entidad.prodCantidad));
            int rspta = ExecuteNonQueryDB(Insertar);
            return rspta;
        }

        public DataView listar(string estado)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("estado", estado));
            DataView dv = new DataView();
            dv.Table = DataAdapterDBSentens(Listar);
            return dv;
        }

        public IEnumerable<Almacen> seleccionarProductoXCodigo(string codigo)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("prodCodigo", codigo));
            var AlmacenResult = ExecuteReaderSelect(SeleccionarXCodigo);
            var listaAlmacen = new List<Almacen>();
            foreach(DataRow item in AlmacenResult.Rows)
            {
                listaAlmacen.Add(new Almacen
                {
                    fk_producto = Convert.ToInt32(item["fk_producto"]),
                    prodCodigo = item["prodCodigo"].ToString(),
                });
            }
            return listaAlmacen;
        }


        //Descontar stock producto
        public void listarProductoDescontar(int fk_producto, double cantidad)
        {
            ListarProductoDescontar(fk_producto,cantidad, CantidadProductoAlmacen, DescontarStocK);
        }

        public void descontarStock(int pk_almacen, double cantidad)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_almacen", pk_almacen));
            parameters.Add(new SqlParameter("prodCantidad", cantidad));
            DescontarStock(pk_almacen,cantidad, DescontarStocK);
        }

        //Obtenemos todos los detalles de los productos de almacen
        public IEnumerable<Almacen> detalleAlmacenProducto(int fk_producto)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_producto", fk_producto));
            var resultProducto = ExecuteReaderSelect(DetalleAlmacenProducto);
            var listaProducto = new List<Almacen>();
            foreach(DataRow item in resultProducto.Rows)
            {
                listaProducto.Add(new Almacen
                {
                    fk_producto = Convert.ToInt32(item["fk_producto"]),
                    prodDescripcion = item["prodDescripcion"].ToString(),
                    prodCodigo = item["prodCodigo"].ToString(),
                    prodCantidad = Convert.ToDouble(item["prodCantidad"]),
                    prodFoto= item["prodFoto"].ToString(),
                    cateNombre = item["cateNombre"].ToString(),
                    preseNombre = item["preseNombre"].ToString(),
                    unmeNombre = item["unmeNombre"].ToString(),
                    marcNombre = item["marcNombre"].ToString(),
                    prodFechaVencimiento = item["prodFechaVencimiento"].ToString()

                });
            }

            return listaProducto;
        }
    }
}
