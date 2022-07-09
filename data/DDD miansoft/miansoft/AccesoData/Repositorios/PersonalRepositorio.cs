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
    public class PersonalRepositorio : MasterRepositorio, IPersonalRepositorio
    {
        private string Listar;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string ActualizarEstado;

        public PersonalRepositorio()
        {
            Listar = "listarPersonal";
            Insertar = "insertarPersonal";
            Modificar = "actualizarPersonal";
            Eliminar = "eliminarPersonal";
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
            parameters.Add(new SqlParameter("pk_personal", pk));
            
            int rspta = ExecuteNonQueryDB(Eliminar);
            return rspta;
        }

        public int insertar(Personal entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("persNombre", entidades.persNombre));
            parameters.Add(new SqlParameter("persApellido", entidades.persApellido));
            parameters.Add(new SqlParameter("persDireccion", entidades.persDireccion));
            parameters.Add(new SqlParameter("persDni", entidades.persDni));
            parameters.Add(new SqlParameter("persSexo", entidades.persSexo));
            parameters.Add(new SqlParameter("persFechaNac", entidades.persFechaNac));
            parameters.Add(new SqlParameter("persTelefono", entidades.persTelefono));
            parameters.Add(new SqlParameter("persEmail", entidades.persEmail));
            parameters.Add(new SqlParameter("fk_cargo", entidades.fk_cargo));
            parameters.Add(new SqlParameter("fk_turno", entidades.fk_turno));
            parameters.Add(new SqlParameter("persEstado", entidades.persEstado));
            int rspta = ExecuteNonQueryDB(Insertar);

            return rspta;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);

            return dv;
        }

        public int modificar(Personal entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_personal", entidades.pk_personal));
            parameters.Add(new SqlParameter("persNombre", entidades.persNombre));
            parameters.Add(new SqlParameter("persApellido", entidades.persApellido));
            parameters.Add(new SqlParameter("persDireccion", entidades.persDireccion));
            parameters.Add(new SqlParameter("persDni", entidades.persDni));
            parameters.Add(new SqlParameter("persSexo", entidades.persSexo));
            parameters.Add(new SqlParameter("persFechaNac", entidades.persFechaNac));
            parameters.Add(new SqlParameter("persTelefono", entidades.persTelefono));
            parameters.Add(new SqlParameter("persEmail", entidades.persEmail));
            parameters.Add(new SqlParameter("fk_cargo", entidades.fk_cargo));
            parameters.Add(new SqlParameter("fk_turno", entidades.fk_turno));
            parameters.Add(new SqlParameter("persEstado", entidades.persEstado));
            int rspta = ExecuteNonQueryDB(Modificar);

            return rspta;
        }
    }
}
