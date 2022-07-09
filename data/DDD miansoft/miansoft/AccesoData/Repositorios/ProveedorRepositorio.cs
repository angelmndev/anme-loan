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
    public class ProveedorRepositorio : MasterRepositorio, IProveedorRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionaPorRuc;

        public ProveedorRepositorio()
        {
            Listar = "listarProveedor";
            Insertar = "insertarProveedor";
            Modificar = "actualizarProveedor";
            Eliminar = "eliminarProveedor";
            ActualizarEstado = "actualizarEstado";
            SeleccionaPorRuc = "obtenerRucProveedor";
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
            parameters.Add(new SqlParameter("pk_proveedor", pk));
            int result = ExecuteNonQueryDB(Eliminar);
            return result;
        }

        public int insertar(Proveedor entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("provNombre", entidades.provNombre));
            parameters.Add(new SqlParameter("provRuc", entidades.provRuc));
            parameters.Add(new SqlParameter("provDireccion", entidades.provDireccion));
            parameters.Add(new SqlParameter("provEmail", entidades.provEmail));
            parameters.Add(new SqlParameter("provGiro", entidades.provGiro));
            parameters.Add(new SqlParameter("provEstado", entidades.provEstado));
            int result = ExecuteNonQueryDB(Insertar);
            return result;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Proveedor entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_proveedor", entidades.pk_proveedor));
            parameters.Add(new SqlParameter("provNombre", entidades.provNombre));
            parameters.Add(new SqlParameter("provRuc", entidades.provRuc));
            parameters.Add(new SqlParameter("provDireccion", entidades.provDireccion));
            parameters.Add(new SqlParameter("provEmail", entidades.provEmail));
            parameters.Add(new SqlParameter("provGiro", entidades.provGiro));
            parameters.Add(new SqlParameter("provEstado", entidades.provEstado));
            int result = ExecuteNonQueryDB(Modificar);
            return result;

        }

        public IEnumerable<Proveedor> seleccionarProveedor(double ruc)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ruc", ruc));
            var resultProveedor = ExecuteReaderSelect(SeleccionaPorRuc);
            var listaProveedor = new List<Proveedor>();
            foreach(DataRow item in resultProveedor.Rows)
            {
                listaProveedor.Add(new Proveedor
                {
                    pk_proveedor = Convert.ToInt32(item["pk_proveedor"]),
                    provNombre = item["provNombre"].ToString(),
                    provRuc = Convert.ToDouble(item["provRuc"]),
                    provDireccion = item["provDireccion"].ToString(),
                    provEmail = item["provEmail"].ToString(),
                    provGiro = item["provGiro"].ToString(),
                    provEstado = Convert.ToInt32(item["provEstado"])
                });       
            }
            return listaProveedor;
        }
    }
}
