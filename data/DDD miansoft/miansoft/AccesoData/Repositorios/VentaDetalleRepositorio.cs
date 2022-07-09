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
    public class VentaDetalleRepositorio : MasterRepositorio, IVentaDetalle
    {
        private string Insertar;

        public VentaDetalleRepositorio()
        {
            Insertar = "insertarVentaDetalle";
        }
        public int insertar(VentaDetalle entidad)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_venta ", entidad.fk_venta));
            parameters.Add(new SqlParameter("fk_producto ", entidad.fk_producto));
            parameters.Add(new SqlParameter("vedeCantidad ", entidad.vedeCantidad));
            parameters.Add(new SqlParameter("vedePrecioVenta ", entidad.vedePrecioVenta));
            parameters.Add(new SqlParameter("vedeDscto ", entidad.vedeDscto));
            int result = ExecuteNonQueryDB(Insertar);
            return result;
        }
    }
}
