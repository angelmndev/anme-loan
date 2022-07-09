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
    public class NegocioRepositorio : MasterRepositorio, INegocioRepositorio
    {
        private string Insertar;
        private string Modificar;
        private string Listar;

        public NegocioRepositorio()
        {
            Insertar = "insertarNegocio";
            Modificar = "actualizarNegocio";
            Listar = "listarNegocio";
        }

        public IEnumerable<Negocio> GetAll()
        {
            var resultNegocio = ExecuteReaderDB(Listar);
            var listaNegocio = new List<Negocio>();
            foreach (DataRow item in resultNegocio.Rows)
            {
                listaNegocio.Add(new Negocio
                {
                    pk_negocio = (int)item["pk_negocio"],
                    negoNombreComercial = item["negoNombreComercial"].ToString(),
                    negoNombreFiscal = item["negoNombreFiscal"].ToString(),
                    negoNif = item["negoNif"].ToString(),
                    negoEmail = item["negoEmail"].ToString(),
                    negoWeb = item["negoWeb"].ToString(),
                    negoPais = item["negoPais"].ToString(),
                    negoProvincia = item["negoProvincia"].ToString(),
                    negoCodigoPostal = item["negoCodigoPostal"].ToString(),

                });
            }
            return listaNegocio;
        }

        public void insertar(Negocio negocio)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("negoNombreComercial", negocio.negoNombreComercial));
            parameters.Add(new SqlParameter("negoNombreFiscal", negocio.negoNombreFiscal));
            parameters.Add(new SqlParameter("negoNif", negocio.negoNif));
            parameters.Add(new SqlParameter("negoEmail", negocio.negoEmail));
            parameters.Add(new SqlParameter("negoWeb", negocio.negoWeb));
            parameters.Add(new SqlParameter("negoPais", negocio.negoPais));
            parameters.Add(new SqlParameter("negoProvincia", negocio.negoProvincia));
            parameters.Add(new SqlParameter("negoCodigoPostal", negocio.negoCodigoPostal));
            ExecuteNonQueryDB(Insertar);

        }

        public void modificar(Negocio negocio)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("pk_negocio", negocio.pk_negocio));
            parameters.Add(new SqlParameter("negoNombreComercial", negocio.negoNombreComercial));
            parameters.Add(new SqlParameter("negoNombreFiscal", negocio.negoNombreFiscal));
            parameters.Add(new SqlParameter("negoNif", negocio.negoNif));
            parameters.Add(new SqlParameter("negoEmail", negocio.negoEmail));
            parameters.Add(new SqlParameter("negoWeb", negocio.negoWeb));
            parameters.Add(new SqlParameter("negoPais", negocio.negoPais));
            parameters.Add(new SqlParameter("negoProvincia", negocio.negoProvincia));
            parameters.Add(new SqlParameter("negoCodigoPostal", negocio.negoCodigoPostal));
            ExecuteNonQueryDB(Modificar);
        }

        public bool negocioExistente()
        {
            bool estado = false;
            var result = ExecuteReaderDB(Listar);
            foreach(DataRow item in result.Rows)
            {
                if (item.Table != null)
                    estado = true;
                else
                    estado = false;
            }
            return estado;
        }
    }
}
