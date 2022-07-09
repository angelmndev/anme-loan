using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class PresentacionModel
    {
        public int pk_presentacion { get; set; }
        public string preseCodigo { get; set; }
        public string preseNombre { get; set; }
        public int preseEstado { get; set; }

        private PresentacionRepositorio presentacionRepositorio;
        public EstadoEntidad estado { get; set; }

        public PresentacionModel()
        {
            presentacionRepositorio = new PresentacionRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var presentacionDataModel = new Presentacion();
                presentacionDataModel.pk_presentacion = pk_presentacion;
                presentacionDataModel.preseCodigo = preseCodigo;
                presentacionDataModel.preseNombre = preseNombre;
                presentacionDataModel.preseEstado = preseEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        presentacionRepositorio.insertar(presentacionDataModel);
                        break;
                    case EstadoEntidad.modificar:
                        presentacionRepositorio.modificar(presentacionDataModel);
                        break;
                    case EstadoEntidad.eliminar:
                        presentacionRepositorio.eliminar(pk_presentacion);
                        break;
                }

            }
            catch(Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if(sqlException != null && sqlException.Number == 2627)
                {
                    mensaje = "Se duplica el codigo de la presentacion";
                }
            }

            return mensaje;
        }

        public DataView listarPresentacion()
        {
            DataView dv = presentacionRepositorio.listar();
            return dv;
        }

        public void ActualizarEstado(int pk ,int estado,string tabla)
        {
            presentacionRepositorio.actualizarEstado(pk, estado, tabla);
        }

        public List<PresentacionModel> GetAll()
        {
            var presentacionDataModel = presentacionRepositorio.GettAll();
            var listaPresentacion = new List<PresentacionModel>();
            foreach(Presentacion item in presentacionDataModel)
            {
                listaPresentacion.Add(new PresentacionModel
                {
                    pk_presentacion = item.pk_presentacion,
                    preseCodigo = item.preseCodigo,
                    preseNombre = item.preseNombre,
                    preseEstado = item.preseEstado
                });
            }
            return listaPresentacion;
        }

        public IEnumerable<PresentacionModel> seleccionarPresentacion(int pk_presentacion)
        {
            var presentacionDataModel = presentacionRepositorio.seleccionarPresentacion(pk_presentacion);
            var listaPresentacon = new List<PresentacionModel>();
            foreach(var item in presentacionDataModel)
            {
                listaPresentacon.Add(new PresentacionModel
                {
                    pk_presentacion = item.pk_presentacion,
                    preseCodigo = item.preseCodigo,
                    preseNombre = item.preseNombre,
                });
            }
            return listaPresentacon;
        }
    }
}
