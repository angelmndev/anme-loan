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
    public class UsuarioRepositorio : MasterRepositorio, IUsuarioRepositorio
    {
        private string Listar;
        private string ActualizarEstado;
        private string Insertar;
        private string Modificar;
        private string Eliminar;
        private string SeleccionarUsuarioXSede;
        public UsuarioRepositorio()
        {
            Listar = "listarUsuario";
            ActualizarEstado = "actualizarEstado";
            Insertar = "insertarUsuario";
            Modificar = "actualizarUsuario";
            Eliminar = "eiminarUsuario";
            SeleccionarUsuarioXSede = "seleccionarUsuarioXSede";
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
            parameters.Add(new SqlParameter("pk_usuario", pk));
            int rspta = ExecuteNonQueryDB(Eliminar);

            return rspta;
        }

        public int insertar(Usuario entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("usuaCodigo", entidades.usuaCodigo));
            parameters.Add(new SqlParameter("usuaNombre", entidades.usuaNombre));
            parameters.Add(new SqlParameter("usuaApellido", entidades.usuaApellido));
            parameters.Add(new SqlParameter("usuaUsuario", entidades.usuaUsuario));
            parameters.Add(new SqlParameter("usuaPassword", entidades.usuaPassword));
            parameters.Add(new SqlParameter("usuaPrivilegios", entidades.usuaPrivilegios));
            parameters.Add(new SqlParameter("usuaEstado", entidades.usuaEstado));
            parameters.Add(new SqlParameter("usuaTipoCuenta", entidades.usuaTipoCuenta));
            parameters.Add(new SqlParameter("usuaTipoDocumento", entidades.usuaTipoDocumento));
            parameters.Add(new SqlParameter("usuaNDocumento", entidades.usuaNDocumento));
            parameters.Add(new SqlParameter("usuaSexo", entidades.usuaSexo));
            parameters.Add(new SqlParameter("usuaCorreo", entidades.usuaCorreo));
            parameters.Add(new SqlParameter("usuaFoto", entidades.usuaFoto));
            parameters.Add(new SqlParameter("usuaTelefono", entidades.usuaTelefono));
            parameters.Add(new SqlParameter("fk_sede", entidades.fk_sede));

            int rspta = ExecuteNonQueryDB(Insertar);
            return rspta;
        }

        public DataView listar()
        {
            DataView dv = new DataView();
            dv.Table = DataAdapterDB(Listar);
            return dv;
        }

        public int modificar(Usuario entidades)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_usuario", entidades.pk_usuario));
            parameters.Add(new SqlParameter("usuaCodigo", entidades.usuaCodigo));
            parameters.Add(new SqlParameter("usuaNombre", entidades.usuaNombre));
            parameters.Add(new SqlParameter("usuaApellido", entidades.usuaApellido));
            parameters.Add(new SqlParameter("usuaUsuario", entidades.usuaUsuario));
            parameters.Add(new SqlParameter("usuaPassword", entidades.usuaPassword));
            parameters.Add(new SqlParameter("usuaPrivilegios", entidades.usuaPrivilegios));
            parameters.Add(new SqlParameter("usuaEstado", entidades.usuaEstado));
            parameters.Add(new SqlParameter("usuaTipoCuenta", entidades.usuaTipoCuenta));
            parameters.Add(new SqlParameter("usuaTipoDocumento", entidades.usuaTipoDocumento));
            parameters.Add(new SqlParameter("usuaNDocumento", entidades.usuaNDocumento));
            parameters.Add(new SqlParameter("usuaSexo", entidades.usuaSexo));
            parameters.Add(new SqlParameter("usuaCorreo", entidades.usuaCorreo));
            parameters.Add(new SqlParameter("usuaFoto", entidades.usuaFoto));
            parameters.Add(new SqlParameter("usuaTelefono", entidades.usuaTelefono));
            parameters.Add(new SqlParameter("fk_sede", entidades.fk_sede));

            int rspta = ExecuteNonQueryDB(Modificar);
            return rspta;
        }

        public IEnumerable<Usuario> seleccionarUsuarioXSede(int fk_sede, string sedeDireccion, string usuaTipoCuenta)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("fk_sede", fk_sede));
            parameters.Add(new SqlParameter("sedeDireccion", sedeDireccion));
            parameters.Add(new SqlParameter("usuaTipoCuenta", usuaTipoCuenta));
            var resultUsuario = ExecuteReaderSelect(SeleccionarUsuarioXSede);
            var listaUsuario = new List<Usuario>();
            foreach(DataRow item in resultUsuario.Rows)
            {
                listaUsuario.Add(new Usuario
                {
                    pk_usuario = Convert.ToInt32(item["pk_usuario"]),
                    usuaCodigo = item["usuaCodigo"].ToString(),
                    usuaNombre = item["usuaNombre"].ToString(),
                    usuaApellido = item["usuaApellido"].ToString(),
                    usuaUsuario = item["usuaUsuario"].ToString(),
                    usuaPrivilegios = item["usuaPrivilegios"].ToString(),
                    usuaEstado = Convert.ToInt32(item["usuaEstado"]),
                    usuaTipoCuenta = item["usuaTipoCuenta"].ToString(),
                    usuaTipoDocumento = item["usuaTipoDocumento"].ToString(),
                    usuaNDocumento = Convert.ToDouble(item["usuaNDocumento"]),
                    usuaSexo = item["usuaSexo"].ToString(),
                    usuaCorreo = item["usuaCorreo"].ToString(),
                    usuaFoto = item["usuaFoto"].ToString(),
                    usuaTelefono = Convert.ToDouble(item["usuaTelefono"])

                });
            }
            return listaUsuario;
        }
    }
}
