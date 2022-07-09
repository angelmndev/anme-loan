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
    public class MainRepositorio : MasterRepositorio, IMainRepositorio
    {
        //0=>Obtenemos alerta de fecha de vencimiento
        //1=>Obtenemos alerta de stock minimo
        private string notificacion;

        public MainRepositorio()
        {
            notificacion = "notificaciones";
        }
        public DataView AlertaFechaVencimiento(int notifi)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Dato", notifi));
            DataView dv = new DataView();
            dv.Table = DataAdapterDBSentens(notificacion);
            return dv;
        }

        public DataView AlertaStock(int notifi)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Dato", notifi));
            DataView dv = new DataView();
            dv.Table = DataAdapterDBSentens(notificacion);
            return dv;
        }

        public int fechaVencimiento(int notifi)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Dato", notifi));
            int contador = cantRows(notificacion);
            return contador;
        }

        public string Mensaje()
        {
            throw new NotImplementedException();
        }

        public int stockMin(int notifi)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Dato", notifi));
            int contador = cantRows(notificacion);
            return contador;
        }
    }
}
