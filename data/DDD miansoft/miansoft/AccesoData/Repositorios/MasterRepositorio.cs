using Soporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Repositorios
{
    public abstract class MasterRepositorio:Repositorio
    {
        protected List<SqlParameter> parameters;
     
        protected int ExecuteNonQueryDB(string sentenciaSql)
        {
            //con => es una variable de tipo sqlconecction
            using (var con = conectarDB())
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                    int result = cmd.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }

        //Recorre la tabla de la base de datos
        protected DataTable ExecuteReaderDB(string sentenciaSql)
        {
            using(var con = conectarDB())
            {
                con.Open();

                using (var cmd = new SqlCommand())
                {
                  
                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    using (var table = new DataTable())
                    {                       
                        table.Load(reader);
                        table.TableName = "Entidad";
                        reader.Dispose();

                        return table;
                    }
                }
            }      
        }

        //Ejecuta una sentencia con variable
        protected DataTable ExecuteReaderSelect(string sentenciaSql)
        {
            using (var con = conectarDB())
            {
                con.Open();

                using (var cmd = new SqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    using (var table = new DataTable())
                    {
                        table.Load(reader);
                        table.TableName = "Entidad";
                        reader.Dispose();

                        return table;
                    }
                }
            }
        }

        //data adapter
        protected DataTable DataAdapterDB(string sentenciaSql)
        {
            using(var con = conectarDB())
            {
                con.Open();
                using (var cmd =new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.TableName = "Entidad";
                    da.Fill(dt);

                    cmd.Dispose();
                    return dt;
                }
            }
        }


        //Ejecuta una sentencia con una variable
        protected DataTable DataAdapterDBSentens(string sentenciaSql)
        {
            using (var con = conectarDB())
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.TableName = "Entidad";
                    da.Fill(dt);

                    cmd.Dispose();
                    return dt;
                }
            }
        }

        //Descontar Stock
        public void DescontarStock(int pk_almacen, double prodCantidad,string sentenciaSql)
        {
            using(var con = conectarDB())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sentenciaSql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pk_almacen", pk_almacen);
                cmd.Parameters.AddWithValue("prodCantidad", prodCantidad);
                cmd.ExecuteNonQuery();
            }
        }

        //Descontar stock producto
        public void ListarProductoDescontar(int fk_producto,double cantidad,string sentenciaSql,string sqlsentence)
        {
            using(var con = conectarDB())
            {
                con.Open();
                using(var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fk_producto", fk_producto);
                    double cantidad_total = cantidad;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {                    
                        while (reader.Read())
                        {
                            int pk_almacen = Convert.ToInt32(reader["pk_almacen"].ToString());
                            double cantidad_almacen = Convert.ToInt32(reader["prodCantidad"].ToString());
                            if (cantidad_almacen >= cantidad_total)
                            {
                                DescontarStock(pk_almacen, cantidad_total, sqlsentence);
                                cantidad_total = 0;
                            }
                            else
                            {
                                DescontarStock(pk_almacen, cantidad_almacen, sqlsentence);
                                cantidad_total = cantidad_total - cantidad_almacen;
                            }

                        }
                    }
                }
            }
        }

        //Login 
        public bool UserLogin(string user,string password,string sentenciaSql)
        {
            using(var con = conectarDB())
            {
                con.Open();
                using(var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usuaUsuario", user);
                    cmd.Parameters.AddWithValue("usuaPassword", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.pk_usuario = Convert.ToInt32(reader["pk_usuario"]);
                            UserCache.usuaCodigo = reader["usuaCodigo"].ToString();
                            UserCache.usuaNombre = reader["usuaNombre"].ToString();
                            UserCache.usuaApellido = reader["usuaApellido"].ToString();
                            UserCache.usuaUsuario = reader["usuaUsuario"].ToString();
                            UserCache.usuaPassword = reader["usuaPassword"].ToString();
                            UserCache.usuaPrivilegios = reader["usuaPrivilegios"].ToString();
                            UserCache.usuaEstado = Convert.ToInt32(reader["usuaEstado"]);
                            UserCache.usuaTipoCuenta = reader["usuaTipoCuenta"].ToString();
                            UserCache.usuaTipoDocumento = reader["usuaTipoDocumento"].ToString();
                            UserCache.usuaNDocumento = Convert.ToDouble(reader["usuaNDocumento"]);
                            UserCache.usuaSexo = reader["usuaSexo"].ToString();
                            UserCache.usuaCorreo = reader["usuaCorreo"].ToString();
                            UserCache.usuaFoto = reader["usuaFoto"].ToString();
                            UserCache.usuaTelefono = Convert.ToDouble(reader["usuaTelefono"]);

                        }
                        return true;
                    }
                    else return false;
                    
                }
            }
        }

        //Generar reporte
        public DataTable reporteVentas(DateTime fechaInicio,DateTime fechaFinal,string sentenciaSql) 
        {
            using(var con = conectarDB())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sentenciaSql,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("fechaFinal", fechaFinal);

                var reader = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(reader);

                return table;
            }
        }


        //Contar si hay datos
        public int cantRows(string sentenciaSql)
        {
            int contador = 0;
            using(var con = conectarDB())
            {
                con.Open();

                using (var cmd = new SqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = sentenciaSql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contador++;
                        }
                    }
                }
            }
            return contador;
        }
    }
}
