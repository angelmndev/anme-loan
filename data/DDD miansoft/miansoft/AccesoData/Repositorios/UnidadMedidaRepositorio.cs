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
    public class UnidadMedidaRepositorio : MasterRepositorio, IUnidadMedidaRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionaUnidadMedida;

        public UnidadMedidaRepositorio()
        {
            Listar = "listarUnidadMedida";
            Insertar = "insertarUnidadMedida";
            Modificar = "actualizarUnidadMedida";
            Eliminar = "eliminarUnidadMedida";
            ActualizarEstado = "actualizarEstado";
            SeleccionaUnidadMedida = "modificarUnidadMedida";
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
            parameters.Add(new SqlParameter("pk_unidaMedida", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);
            return rspta;
        }

        public int insertar(UnidadMedida entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("unmeNombre", entidades.unmeNombre));
            parameters.Add(new SqlParameter("unmeEstado", entidades.unmeEstado));
            int rspta = ExecuteNonQueryDB(Insertar);
            return rspta;
        }   

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(UnidadMedida entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_unidadMedida", entidades.pk_unidadMedida));
            parameters.Add(new SqlParameter("unmeNombre", entidades.unmeNombre));
            parameters.Add(new SqlParameter("unmeEstado", entidades.unmeEstado));
            int rspta = ExecuteNonQueryDB(Modificar);
            return rspta;
        }

        public IEnumerable<UnidadMedida> seleccionarUnme(int pk_unidadMedida)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_unidadMedida", pk_unidadMedida));
            var resultUnme = ExecuteReaderSelect(SeleccionaUnidadMedida);
            var listaUnme = new List<UnidadMedida>();
            foreach(DataRow item in resultUnme.Rows)
            {
                listaUnme.Add(new UnidadMedida
                {
                    pk_unidadMedida = Convert.ToInt32(item["pk_unidadMedida"]),
                    unmeNombre = item["unmeNombre"].ToString()
                });
            }
            return listaUnme;
        }
    }
}
