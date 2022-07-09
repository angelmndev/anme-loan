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
    public class VentaRepositorio : MasterRepositorio, IVentaRepositorio
    {
        private string Insertar;
        private string UltimoPk;
        public VentaRepositorio()
        {
            Insertar = "insertarVenta";
            UltimoPk = "ultimoPkVenta";
        }

        public int insertar(Ventas ventas)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_cliente", ventas.fk_cliente));
            parameters.Add(new SqlParameter("fk_personal", ventas.fk_personal));
            parameters.Add(new SqlParameter("ventDocuCodigo", ventas.ventDocuCodigo));
            parameters.Add(new SqlParameter("ventDocuNombre", ventas.ventDocuNombre));
            parameters.Add(new SqlParameter("ventDocNumero", ventas.ventDocNumero));
            parameters.Add(new SqlParameter("ventDocuSerie", ventas.ventDocuSerie));
            parameters.Add(new SqlParameter("ventFechaVenta", ventas.ventFechaVenta));
            parameters.Add(new SqlParameter("fk_formaPago", ventas.fk_formaPago));
            int result = ExecuteNonQueryDB(Insertar);
            return result;
        }

        public int ultimoPkVenta()
        {
            var resultVenta = ExecuteReaderDB(UltimoPk);
            int pkVenta = 0;
            foreach(DataRow item in resultVenta.Rows)
            {
                pkVenta = Convert.ToInt32(item["pk_venta"]);
            }

            return pkVenta;
        }
    }
}
