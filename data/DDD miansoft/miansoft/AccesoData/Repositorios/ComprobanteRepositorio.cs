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
    public class ComprobanteRepositorio : MasterRepositorio, IComprobanteRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionarComprobante;

        public ComprobanteRepositorio()
        {
            Listar = "listarComprobante";
            Insertar = "insertarComprobante";
            Modificar = "actualizarComprobante";
            Eliminar = "eliminarComprobante";
            ActualizarEstado = "actualizarEstado";
            SeleccionarComprobante = "modificarComprobante";
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
            parameters.Add(new SqlParameter("pk_comprobante", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);
            return rspta;
        }

        public int insertar(Comprobante entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("comCodigo", entidades.comCodigo));
            parameters.Add(new SqlParameter("comNombre", entidades.comNombre));
            parameters.Add(new SqlParameter("comSerie", entidades.comSerie));
            parameters.Add(new SqlParameter("comCorrelativo", entidades.comCorrelativo));
            parameters.Add(new SqlParameter("comEstado", entidades.comEstado));
            int rspta = ExecuteNonQueryDB(Insertar);
            return rspta;
    }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Comprobante entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_comprobante", entidades.pk_comprobante));
            parameters.Add(new SqlParameter("comCodigo", entidades.comCodigo));
            parameters.Add(new SqlParameter("comNombre", entidades.comNombre));
            parameters.Add(new SqlParameter("comSerie", entidades.comSerie));
            parameters.Add(new SqlParameter("comCorrelativo", entidades.comCorrelativo));
            parameters.Add(new SqlParameter("comEstado", entidades.comEstado));
            int rspta = ExecuteNonQueryDB(Modificar);
            return rspta;
        }

        public IEnumerable<Comprobante> seleccionarComrobante(int pk_comprobante)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_comprobante", pk_comprobante));
            var resultComprobante = ExecuteReaderSelect(SeleccionarComprobante);
            var listaComprobante = new List<Comprobante>();
            foreach(DataRow item in resultComprobante.Rows)
            {
                listaComprobante.Add(new Comprobante
                {
                    pk_comprobante = Convert.ToInt32(item["pk_comprobante"]),
                    comCodigo = item["comCodigo"].ToString(),
                    comNombre =item["comNombre"].ToString(),
                    comSerie = item["comSerie"].ToString(),
                    comCorrelativo = Convert.ToInt32(item["comCorrelativo"]),
                    comEstado = Convert.ToInt32(item["comEstado"])
                });
            }
            return listaComprobante;
        }
    }
}
