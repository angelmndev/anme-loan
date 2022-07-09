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
    public class FormaPagoModel
    {
        public int pk_formaPago { get; set; }
        public string fopaNombre { get; set; }
        public int fopaEstado { get; set; }

        private FormaPagoRepositorio formaPagoRepositorio;        
        public EstadoEntidad estado { get; set; }

        public FormaPagoModel()
        {
            formaPagoRepositorio = new FormaPagoRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var fopaDataModel = new FormaPago();
                fopaDataModel.pk_formaPago = pk_formaPago;
                fopaDataModel.fopaNombre = fopaNombre;
                fopaDataModel.fopaEstado = fopaEstado;
                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        formaPagoRepositorio.insertar(fopaDataModel);
                        break;
                    case EstadoEntidad.modificar:
                        formaPagoRepositorio.modificar(fopaDataModel);
                        break;
                    case EstadoEntidad.eliminar:
                        formaPagoRepositorio.eliminar(pk_formaPago);
                        break;
                }

            }
            catch(Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if(sqlException != null && sqlException.Number == 2627)
                {
                    mensaje = "Ya existe el forma de pago";
                }
            }
            return mensaje;
        }

        public DataView listarFormPago()
        {
            DataView dv = formaPagoRepositorio.listar();
            return dv;
        }

        public void actualizarEstado(int pk, int estado, string tabla) => formaPagoRepositorio.actualizarEstado(pk, estado, tabla);

    }
}
