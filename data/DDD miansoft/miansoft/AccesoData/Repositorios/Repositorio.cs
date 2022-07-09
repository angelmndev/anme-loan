using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public abstract class Repositorio
    {
        private readonly string connectionString;

        public Repositorio()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conMian"].ToString();
        }

        protected SqlConnection conectarDB()
        {
            return new SqlConnection(connectionString);
        } 
    }
}
