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
    public class CategoriaRepositorio : MasterRepositorio, ICategoriaRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionarPK;
        public CategoriaRepositorio()
        {
            Listar = "listarCategoria";
            Insertar = "insertarCategoria";
            Modificar = "actualizarCategoria";
            Eliminar = "eliminarCategoria";
            ActualizarEstado = "actualizarEstado";
            SeleccionarPK = "modificarCategoria";
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
            parameters.Add(new SqlParameter("pk_categoria", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);
            
            return rspta;
        }

        public IEnumerable<Categoria> GetAll()
        {
            var resultCategoria = ExecuteReaderDB(Listar);
            var listaCateegoria = new List<Categoria>();
            foreach (DataRow item in resultCategoria.Rows)
            {
                listaCateegoria.Add(new Categoria
                {
                    pk_categoria = Convert.ToInt32(item["pk_categoria"]),
                    cateNombre = item["cateNombre"].ToString()
                });
            }

            return listaCateegoria;
        }

        public int insertar(Categoria entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("cateCodigo", entidades.cateCodigo));
            parameters.Add(new SqlParameter("cateNombre", entidades.cateNombre));
            parameters.Add(new SqlParameter("cateEstado", entidades.cateEstado));            
            int rspta = ExecuteNonQueryDB(Insertar);

            return rspta;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);

            return dv;
        }

        public int modificar(Categoria entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_categoria", entidades.pk_categoria));
            parameters.Add(new SqlParameter("cateCodigo", entidades.cateCodigo));
            parameters.Add(new SqlParameter("cateNombre", entidades.cateNombre));
            parameters.Add(new SqlParameter("cateEstado", entidades.cateEstado));
            int rspta = ExecuteNonQueryDB(Modificar);

            return rspta;
        }

        public IEnumerable<Categoria> seleccionarCategoria(int pk_categoria)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_categoria", pk_categoria));
            var resultCatgoria = ExecuteReaderSelect(SeleccionarPK);
            var listaCategoria = new List<Categoria>();
            foreach(DataRow item in resultCatgoria.Rows)
            {
                listaCategoria.Add(new Categoria
                {
                    pk_categoria = Convert.ToInt32(item["pk_categoria"]),
                    cateCodigo = item["cateCodigo"].ToString(),
                    cateNombre = item["cateNombre"].ToString()
                });
            }
            return listaCategoria;
        }
    }
}
