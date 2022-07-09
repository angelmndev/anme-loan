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
    public class ClienteRepositorio : MasterRepositorio, IClienteRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;
        private string SeleccionarClienteDni;

        public ClienteRepositorio() 
        {
            Listar = "listarCliente";
            Insertar = "insertarCliente";
            Modificar = "actualizarCliente";
            Eliminar = "eliminarCliente";
            ActualizarEstado = "actualizarEstado";
            SeleccionarClienteDni = "obtenerDniCliente";
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
            parameters.Add(new SqlParameter("pk_cliente", pk));
            int result = ExecuteNonQueryDB(Eliminar);
            return result;
        }

        public int insertar(Cliente entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("clieNombre", entidades.clieNombre));
            parameters.Add(new SqlParameter("clieRucDni", entidades.clieRucDni));
            parameters.Add(new SqlParameter("clieDireccion", entidades.clieDireccion));
            parameters.Add(new SqlParameter("clieEmail", entidades.clieEmail));
            parameters.Add(new SqlParameter("clieDeuda", entidades.clieDeuda));
            parameters.Add(new SqlParameter("clieEstado", entidades.clieEstado));
            int result = ExecuteNonQueryDB(Insertar);

            return result;
    }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Cliente entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_cliente", entidades.pk_cliente));
            parameters.Add(new SqlParameter("clieNombre", entidades.clieNombre));
            parameters.Add(new SqlParameter("clieRucDni", entidades.clieRucDni));
            parameters.Add(new SqlParameter("clieDireccion", entidades.clieDireccion));
            parameters.Add(new SqlParameter("clieEmail", entidades.clieEmail));
            parameters.Add(new SqlParameter("clieDeuda", entidades.clieDeuda));
            parameters.Add(new SqlParameter("clieEstado", entidades.clieEstado));
            int result = ExecuteNonQueryDB(Modificar);

            return result;
        }

        public IEnumerable<Cliente> seleccionarCliente(double value)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Dni", value));
            var resultCliente = ExecuteReaderSelect(SeleccionarClienteDni);
            var listaCliente = new List<Cliente>();
            foreach(DataRow item in resultCliente.Rows)
            {
                listaCliente.Add(new Cliente
                {
                    pk_cliente =Convert.ToInt32(item["pk_cliente"]),
                    clieNombre = item["clieNombre"].ToString(),
                    clieRucDni = Convert.ToDouble(item["clieRucDni"]),
                    clieDireccion = item["clieDireccion"].ToString(),
                    clieEmail = item["clieEmail"].ToString(),
                    clieDeuda = Convert.ToDouble(item["clieDeuda"]),
                    clieEstado = (int)item["clieEstado"]
                });
            }
            return listaCliente;
        }
    }
}
