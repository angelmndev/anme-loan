using AccesoData.Contratos;
using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public class CompraDetalleRepositorio : MasterRepositorio, ICompraDetalleRepositorio
    {
        private string Insertar;
        public CompraDetalleRepositorio()
        {
            Insertar = "insertarCompraDetalle";
        }
        public int insertar(CompraDetalle compraDetalle)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_compra", compraDetalle.fk_compra));
            parameters.Add(new SqlParameter("fk_producto", compraDetalle.fk_producto));
            parameters.Add(new SqlParameter("codeCantidad", compraDetalle.codeCantidad));
            parameters.Add(new SqlParameter("codePrecioCompra", compraDetalle.codePrecioCompra));
            parameters.Add(new SqlParameter("codeFechaVencimiento", compraDetalle.codeFechaVencimiento));
            int result = ExecuteNonQueryDB(Insertar);

            return result;
        }
    }
}
