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
    public class TurnoRepositorio : MasterRepositorio, ITurnoRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;

        public TurnoRepositorio()
        {
            Listar = "listarTurno";
            Insertar = "insertarTurno";
            Modificar = "actualizarTurno";
            Eliminar = "eliminarTurno";
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
            parameters.Add(new SqlParameter("pk_turno", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);

            return rspta;
        }

        public int insertar(Turno entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("turnNombre", entidades.turnNombre));
            parameters.Add(new SqlParameter("turnHentrada", entidades.turnHentrada));
            parameters.Add(new SqlParameter("turnHsalida", entidades.turnHsalida));
            parameters.Add(new SqlParameter("turnEstado", entidades.turnEstado));
            int rspta = ExecuteNonQueryDB(Insertar);
            
            return rspta;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Turno entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_turno", entidades.pk_turno));
            parameters.Add(new SqlParameter("turnNombre", entidades.turnNombre));
            parameters.Add(new SqlParameter("turnHentrada", entidades.turnHentrada));
            parameters.Add(new SqlParameter("turnHsalida", entidades.turnHsalida));
            parameters.Add(new SqlParameter("turnEstado", entidades.turnEstado));
            int rspta = ExecuteNonQueryDB(Modificar);

            return rspta;
        }
    }
}
