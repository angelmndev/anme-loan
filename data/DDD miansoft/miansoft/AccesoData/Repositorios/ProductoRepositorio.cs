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
    public class ProductoRepositorio : MasterRepositorio, IProductoRepositorio
    {
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string Listar;
        private string Seleccionar;
        private string ModificarPrecioVenta;
        public ProductoRepositorio()
        {
            Insertar = "insertarProducto";
            Modificar = "actualizarProducto";
            Eliminar = "eliminarProducto";
            Listar = "listarProducto";
            Seleccionar = "modificarProducto";
            ModificarPrecioVenta = "modificarProdPrecioUnitario";
        }

     
        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);

            return dv;
        }
        public int insertar(Producto entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("prodDescripcion", entidades.prodDescripcion));
            parameters.Add(new SqlParameter("prodCodigo", entidades.prodCodigo));
            parameters.Add(new SqlParameter("prodPrecioUnitario", entidades.prodPrecioUnitario));
            parameters.Add(new SqlParameter("prodFoto", entidades.prodFoto));
            parameters.Add(new SqlParameter("prodStkMin", entidades.prodStkMin));
            parameters.Add(new SqlParameter("prodStkMax", entidades.prodStkMax));
            parameters.Add(new SqlParameter("fk_categoria", entidades.fk_categoria));
            parameters.Add(new SqlParameter("fk_presentacion", entidades.fk_presentacion));
            parameters.Add(new SqlParameter("fk_unidadMedida", entidades.fk_unidadMedida));
            parameters.Add(new SqlParameter("fk_marca", entidades.fk_marca));
            parameters.Add(new SqlParameter("prodEstado", entidades.prodEstado));
            parameters.Add(new SqlParameter("prodPerecedero", entidades.prodPerecedero));
            int resultado = ExecuteNonQueryDB(Insertar);
            return resultado;
        }
        public int modificar(Producto entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_producto", entidades.pk_producto));
            parameters.Add(new SqlParameter("prodDescripcion", entidades.prodDescripcion));
            parameters.Add(new SqlParameter("prodCodigo", entidades.prodCodigo));
            parameters.Add(new SqlParameter("prodPrecioUnitario", entidades.prodPrecioUnitario));
            parameters.Add(new SqlParameter("prodFoto", entidades.prodFoto));
            parameters.Add(new SqlParameter("prodStkMin", entidades.prodStkMin));
            parameters.Add(new SqlParameter("prodStkMax", entidades.prodStkMax));
            parameters.Add(new SqlParameter("fk_categoria", entidades.fk_categoria));
            parameters.Add(new SqlParameter("fk_presentacion", entidades.fk_presentacion));
            parameters.Add(new SqlParameter("fk_unidadMedida", entidades.fk_unidadMedida));
            parameters.Add(new SqlParameter("fk_marca", entidades.fk_marca));
            parameters.Add(new SqlParameter("prodEstado", entidades.prodEstado));
            parameters.Add(new SqlParameter("prodPerecedero", entidades.prodPerecedero));
            int resultado = ExecuteNonQueryDB(Modificar);
            return resultado;
        }
        public int eliminar(int pk)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_producto", pk));
            int resultado = ExecuteNonQueryDB(Eliminar);
            return resultado;
        }

        public IEnumerable<Producto> seleccionarProducto(int pk)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_producto", pk));
            var resultProducto = ExecuteReaderSelect(Seleccionar);
            var listaProducto = new List<Producto>();
            foreach (DataRow item in resultProducto.Rows)
            {
                listaProducto.Add(new Producto
                {
                    pk_producto = (int)item["pk_producto"],
                    prodDescripcion = item["prodDescripcion"].ToString(),
                    prodCodigo = item["prodCodigo"].ToString(),
                    prodPrecioUnitario = (double)item["prodPrecioUnitario"],
                    prodFoto = item["prodFoto"].ToString(),
                    prodStkMin = (double)item["prodStkMin"],
                    prodStkMax = (double)item["prodStkMax"],
                    fk_categoria = (int)item["fk_categoria"],
                    fk_presentacion = (int)item["fk_presentacion"],
                    fk_unidadMedida = (int)item["fk_unidadMedida"],
                    fk_marca = (int)item["fk_marca"],
                    prodEstado = (int)item["prodEstado"],
                    prodPerecedero = (int)item["prodPerecedero"]
                });
            }

            return listaProducto;
        }

        public void modificarPrecioVenta(int pk,double prodPrecioVenta)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("prodPrecioUnitario", prodPrecioVenta));
            parameters.Add(new SqlParameter("pk_producto", pk));
            ExecuteNonQueryDB(ModificarPrecioVenta);
        }
    }
}
