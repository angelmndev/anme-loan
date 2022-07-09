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
    public class MarcaRepositorio : MasterRepositorio, IMarcaRepositorio
    {
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string Listar;
        private string ActualizarEstado;
        private string SeleccionarMarca;
        public MarcaRepositorio()
        {
            Insertar = "insertarMarca";
            Modificar = "actualizarMarca";
            Eliminar = "eliminarMarca";
            Listar = "listarMarca";
            ActualizarEstado = "actualizarEstado";
            SeleccionarMarca = "modificarMarca";
        }

        public int eliminar(int pk)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_marca", pk));
            int resultado = ExecuteNonQueryDB(Eliminar);
            return resultado;
        }

        public int insertar(Marca entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("marcCodigo", entidades.marcCodigo));
            parameters.Add(new SqlParameter("marcNombre", entidades.marcNombre));
            parameters.Add(new SqlParameter("marcEstado", entidades.marcEstado));
            int resultado = ExecuteNonQueryDB(Insertar);

            return resultado;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);

            return dv;
        }

        public int modificar(Marca entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_marca", entidades.pk_marca));
            parameters.Add(new SqlParameter("marcCodigo", entidades.marcCodigo));
            parameters.Add(new SqlParameter("marcNombre", entidades.marcNombre));
            parameters.Add(new SqlParameter("marcEstado", entidades.marcEstado));
            int resultado = ExecuteNonQueryDB(Modificar);
            return resultado;
        }

        public void actualizarEstado(int pk, int estado, string tabla)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk", pk));
            parameters.Add(new SqlParameter("Estado", estado));
            parameters.Add(new SqlParameter("nameTable", tabla));
            ExecuteNonQueryDB(ActualizarEstado);
        }

        public IEnumerable<Marca> GetAll()
        {
            var resultMarca = ExecuteReaderDB(Listar);
            var listaMarca = new List<Marca>();
            foreach (DataRow item in resultMarca.Rows)
            {
                listaMarca.Add(new Marca
                {
                    pk_marca = Convert.ToInt32(item["pk_marca"]),
                    marcNombre = item["marcNombre"].ToString()
                });
            }

            return listaMarca;
        }

        public IEnumerable<Marca> seleccionarMarca(int pk_marca)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_marca", pk_marca));
            var resultMarca = ExecuteReaderSelect(SeleccionarMarca);
            var listaMarca = new List<Marca>();
            foreach(DataRow item in resultMarca.Rows)
            {
                listaMarca.Add(new Marca
                {
                    pk_marca = Convert.ToInt32(item["pk_marca"]),
                    marcCodigo = item["marcCodigo"].ToString(),
                    marcNombre = item["marcNombre"].ToString()
                });
            }
            return listaMarca;
        }
    }
}
