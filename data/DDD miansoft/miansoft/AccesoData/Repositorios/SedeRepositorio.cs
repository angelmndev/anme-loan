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
    public class SedeRepositorio : MasterRepositorio, ISedeRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionarSede;

        public SedeRepositorio()
        {
            Listar = "listarSede";
            Insertar = "insertarSede";
            Modificar = "actualizarSede";
            Eliminar = "eliminarSede";
            ActualizarEstado = "actualizarEstado";
            SeleccionarSede = "modificarSede";
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
            parameters.Add(new SqlParameter("pk_sede", pk));
            int result =   ExecuteNonQueryDB(Eliminar);
            return result;
        }

        public int insertar(Sede entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("sedeProvincia", entidades.sedeProvincia));
            parameters.Add(new SqlParameter("sedeDistrito", entidades.sedeDistrito));
            parameters.Add(new SqlParameter("sedeDireccion", entidades.sedeDireccion));
            parameters.Add(new SqlParameter("sedeTelefono", entidades.sedeTelefono));
            parameters.Add(new SqlParameter("sedeCodigoPostal", entidades.sedeCodigoPostal));
            parameters.Add(new SqlParameter("sedeEstado", entidades.sedeEstado));
            int resul = ExecuteNonQueryDB(Insertar);
            return resul;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Sede entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_sede", entidades.pk_sede));
            parameters.Add(new SqlParameter("sedeProvincia", entidades.sedeProvincia));
            parameters.Add(new SqlParameter("sedeDistrito", entidades.sedeDistrito));
            parameters.Add(new SqlParameter("sedeDireccion", entidades.sedeDireccion));
            parameters.Add(new SqlParameter("sedeTelefono", entidades.sedeTelefono));
            parameters.Add(new SqlParameter("sedeCodigoPostal", entidades.sedeCodigoPostal));
            parameters.Add(new SqlParameter("sedeEstado", entidades.sedeEstado));
            int resul = ExecuteNonQueryDB(Modificar);
            return resul;
        }

        public IEnumerable<Sede> seleccionarSede(int pk_sede)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_sede", pk_sede));
            var resultSede = ExecuteReaderSelect(SeleccionarSede);
            var listaSede = new List<Sede>();
            foreach(DataRow item in resultSede.Rows)
            {
                listaSede.Add(new Sede
                {
                    pk_sede = Convert.ToInt32(item["pk_sede"]),
                    sedeProvincia = item["sedeProvincia"].ToString(),
                    sedeDistrito = item["sedeDistrito"].ToString(),
                    sedeDireccion = item["sedeDireccion"].ToString(),
                    sedeTelefono = Convert.ToDouble(item["sedeTelefono"]),
                    sedeCodigoPostal = item["sedeCodigoPostal"].ToString(),
                    sedeEstado = Convert.ToInt32(item["sedeEstado"])
                });
            }

            return listaSede;
        }
    }
}
