using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class UnidadMedidaModel
    {
        public int pk_unidadMedida { get; set; }
        public string unmeNombre { get; set; }
        public int unmeEstado { get; set; }

        private UnidadMedidaRepositorio unmeRepositorio;
        public EstadoEntidad estado { get; set; }

        public UnidadMedidaModel()
        {
            unmeRepositorio = new UnidadMedidaRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var unmeDataModel = new UnidadMedida();
                unmeDataModel.pk_unidadMedida = pk_unidadMedida;
                unmeDataModel.unmeNombre = unmeNombre;
                unmeDataModel.unmeEstado = unmeEstado;
                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        unmeRepositorio.insertar(unmeDataModel);
                        break;
                    case EstadoEntidad.modificar:
                        unmeRepositorio.modificar(unmeDataModel);
                        break;
                    case EstadoEntidad.eliminar:
                        unmeRepositorio.eliminar(pk_unidadMedida);
                        break;
                }
            }
            catch(Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    mensaje = "El nombre de la unidad de medida ya existe en la base de datos";
                }
            }
            return mensaje;
        }

        public DataView listarUnme()
        {
            DataView dv = unmeRepositorio.listar();
            return dv;
        }

        public void ActualizarEstado(int pk, int estado, string tabla) => unmeRepositorio.actualizarEstado(pk, estado, tabla);

        public IEnumerable<UnidadMedidaModel> seleccionarUnidadMedida(int pk_unidadMedida)
        {
            var unmeDataModel = unmeRepositorio.seleccionarUnme(pk_unidadMedida);
            var listaUnme = new List<UnidadMedidaModel>();
            foreach(var item in unmeDataModel)
            {
                listaUnme.Add(new UnidadMedidaModel
                {
                    pk_unidadMedida = item.pk_unidadMedida,
                    unmeNombre = item.unmeNombre
                });
            }
            return listaUnme;
        }
    }
}
