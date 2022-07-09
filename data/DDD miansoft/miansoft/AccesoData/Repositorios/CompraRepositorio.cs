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
    public class CompraRepositorio : MasterRepositorio, ICompraRepositorio
    {
        private string Insertar;
        private string ListarProductoCompra;
        private string UltimoPK;
        public CompraRepositorio()
        {
            Insertar = "insertarCompra";
            ListarProductoCompra = "listarProductoCompra";
            UltimoPK = "ultimoPkCompra";
        }
        public int insertar(Compra compra)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_proveedor", compra.fk_proveedor));
            parameters.Add(new SqlParameter("fk_personal", compra.fk_personal));
            parameters.Add(new SqlParameter("compDocuCodigo", compra.compDocuCodigo));
            parameters.Add(new SqlParameter("compDocuNombre", compra.compDocuNombre));
            parameters.Add(new SqlParameter("compDocuNumero", compra.compDocuNumero));
            parameters.Add(new SqlParameter("compFechaCompra", compra.compFechaCompra));
            parameters.Add(new SqlParameter("compEstado", compra.compEstado));
            int result = ExecuteNonQueryDB(Insertar);

            return result;
        }

        public DataView listarProductoCompra()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(ListarProductoCompra);
            return dv;
        }

        public int ultimoPkCompra()
        {
            var resultCompra = ExecuteReaderDB(UltimoPK);
            int pkCompra = 0;
            foreach (DataRow item in resultCompra.Rows)
            {
                pkCompra = Convert.ToInt32(item["pk_compra"]);
            }

            return pkCompra;
        }
    }
}
