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
    public class CargoRepositorio: MasterRepositorio,ICargoRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;

        public CargoRepositorio()
        {
            Listar = "listarCargo";
            Insertar = "insertarCargo";
            Modificar = "actualizarCargo";
            Eliminar = "eliminarCargo";
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
            parameters.Add(new SqlParameter("pk_cargo", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);

            return rspta;
        }

        public int insertar(Cargo entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("cargNombre", entidades.cargNombre));
            parameters.Add(new SqlParameter("cargEstado", entidades.cargEstado));
            int rspta = ExecuteNonQueryDB(Insertar);

            return rspta;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);

            return dv;
        }

        public int modificar(Cargo entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_cargo", entidades.pk_cargo));
            parameters.Add(new SqlParameter("cargNombre", entidades.cargNombre));
            parameters.Add(new SqlParameter("cargEstado", entidades.cargEstado));
            int rspta = ExecuteNonQueryDB(Modificar);

            return rspta;
        }

        public IEnumerable<Cargo> llennarCombo()
        {
            var resultCargo = ExecuteReaderDB(Listar);
            var listaCargo = new List<Cargo>();
            foreach(DataRow item in resultCargo.Rows)
            {
                listaCargo.Add(new Cargo
                {
                    pk_cargo = Convert.ToInt32(item["pk_cargo"]),
                    cargNombre = item["cargNombre"].ToString()
                });
            }

            return listaCargo;
        }
    }
}
