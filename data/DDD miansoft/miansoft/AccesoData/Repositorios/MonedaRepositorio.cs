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
    public class MonedaRepositorio : MasterRepositorio, IMonedaRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
  
        public MonedaRepositorio()
        {
            Listar = "listarMoneda";
            Insertar = "insertarMoneda";
            Modificar = "actualizarMoneda";
            Eliminar = "eliminarMoneda";
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
            parameters.Add(new SqlParameter("pk_moneda", pk));
            int result = ExecuteNonQueryDB(Eliminar);

            return result;
        }

        public int insertar(Moneda entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("moneIso", entidades.moneIso));
            parameters.Add(new SqlParameter("moneSimbolo", entidades.moneSimbolo));
            parameters.Add(new SqlParameter("moneLenguaje", entidades.moneLenguaje));
            parameters.Add(new SqlParameter("moneNombre", entidades.moneNombre));
            parameters.Add(new SqlParameter("moneEstado", entidades.moneEstado));
            int result = ExecuteNonQueryDB(Insertar);
            return result;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Moneda entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_moneda", entidades.pk_moneda));
            parameters.Add(new SqlParameter("moneIso", entidades.moneIso));
            parameters.Add(new SqlParameter("moneSimbolo", entidades.moneSimbolo));
            parameters.Add(new SqlParameter("moneLenguaje", entidades.moneLenguaje));
            parameters.Add(new SqlParameter("moneNombre", entidades.moneNombre));
            parameters.Add(new SqlParameter("moneEstado", entidades.moneEstado));
            int result = ExecuteNonQueryDB(Modificar);
            return result;
        }
    }
}
