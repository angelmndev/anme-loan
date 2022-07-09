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
    public class FormaPagoRepositorio : MasterRepositorio, IFormaPagoRepositorio
    {
        private string ListarFormaPago;
        private string InsertarFormaPago;
        private string ModificarFormaPago;
        private string EliminarFormaPago;
        private string ActualizarEstado;

        public FormaPagoRepositorio()
        {
            ListarFormaPago = "listarFormaPago";
            InsertarFormaPago = "insertarFormaPago";
            ModificarFormaPago = "actualizarFormaPago";
            EliminarFormaPago = "eliminarFormaPago";
            ActualizarEstado = "actualizarEstado";
        }

        public void actualizarEstado(int pk, int estado, string tabla)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk", pk));
            parameters.Add(new SqlParameter("Estado", estado));
            parameters.Add(new SqlParameter("nameTable", tabla));
            ExecuteNonQueryDB(ActualizarEstado);
        }

        public int eliminar(int pk)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_formaPago", pk));
            int result = ExecuteNonQueryDB(EliminarFormaPago);
            return result;
        }

        public int insertar(FormaPago entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fopaNombre", entidades.fopaNombre));
            parameters.Add(new SqlParameter("fopaEstado", entidades.fopaEstado));
            int result = ExecuteNonQueryDB(InsertarFormaPago);
            return result;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(ListarFormaPago);

            return dv;
        }

        public int modificar(FormaPago entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_formaPago", entidades.pk_formaPago));
            parameters.Add(new SqlParameter("fopaNombre", entidades.fopaNombre));
            parameters.Add(new SqlParameter("fopaEstado", entidades.fopaEstado));
            int result = ExecuteNonQueryDB(ModificarFormaPago);
            return result;
        }
    }
}
