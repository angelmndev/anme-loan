using AccesoData.Contratos;
using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public class PresentacionRepositorio : MasterRepositorio, IPresentacionRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionarPresentacion;

        public PresentacionRepositorio()
        {
            Listar = "listarPresentacion";
            Insertar = "insertarPresentacion";
            Modificar = "actualizarPresentacion";
            Eliminar = "eliminarPresentacion";
            ActualizarEstado = "actualizarEstado";
            SeleccionarPresentacion = "modificarPresentacion";
        }
        public void actualizarEstado(int pk, int estado, string tabla)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk", pk));
            parameters.Add(new SqlParameter("Estado",estado));
            parameters.Add(new SqlParameter("nameTable", tabla));
            ExecuteNonQueryDB(ActualizarEstado);
        }

        public int eliminar(int pk)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_presentacion", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);

            return rspta;
        }

        public IEnumerable<Presentacion> GettAll()
        {
            var tableResult = ExecuteReaderDB(Listar);
            var listaPresentacion = new List<Presentacion>();
            foreach(DataRow item in tableResult.Rows)
            {
                listaPresentacion.Add(new Presentacion
                {
                    pk_presentacion = (int)item["pk_presentacion"],
                    preseCodigo = item["preseCodigo"].ToString(),
                    preseNombre = item["preseNombre"].ToString(),
                    preseEstado =(int)item["preseEstado"]
                });
            }

            return listaPresentacion;
        }

        public int insertar(Presentacion entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("preseCodigo", entidades.preseCodigo));
            parameters.Add(new SqlParameter("preseNombre", entidades.preseNombre));
            parameters.Add(new SqlParameter("preseEstado", entidades.preseEstado));

            int rspta = ExecuteNonQueryDB(Insertar);
            return rspta;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);

            return dv;
        }

        public int modificar(Presentacion entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_presentacion", entidades.pk_presentacion));
            parameters.Add(new SqlParameter("preseCodigo", entidades.preseCodigo));
            parameters.Add(new SqlParameter("preseNombre", entidades.preseNombre));
            parameters.Add(new SqlParameter("preseEstado", entidades.preseEstado));

            int rspta = ExecuteNonQueryDB(Modificar);
            return rspta;
        }

        public IEnumerable<Presentacion> seleccionarPresentacion(int pk_presentacion)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_presentacion", pk_presentacion));
            var resultPresentacion = ExecuteReaderSelect(SeleccionarPresentacion);
            var listaPresentacion = new List<Presentacion>();
            foreach(DataRow item in resultPresentacion.Rows)
            {
                listaPresentacion.Add(new Presentacion
                {
                    pk_presentacion = Convert.ToInt32(item["pk_presentacion"]),
                    preseCodigo = item["preseCodigo"].ToString(),
                    preseNombre = item["preseNombre"].ToString()
                });
            }
            return listaPresentacion;
        }
    }
}
