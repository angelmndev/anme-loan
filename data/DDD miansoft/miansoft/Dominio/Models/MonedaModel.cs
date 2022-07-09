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
    public class MonedaModel
    {
        public int pk_moneda { get; set; }
        public string moneIso { get; set; }
        public string moneSimbolo { get; set; }
        public string moneLenguaje { get; set; }
        public string moneNombre { get; set; }
        public int moneEstado { get; set; }

        private MonedaRepositorio monedaRepositorio;
        public EstadoEntidad estado { get; set; }
        public MonedaModel()
        {
            monedaRepositorio = new MonedaRepositorio();
        }

        public string GuardarCambios()
        {
            string result = string.Empty;
            try
            {
                var monedaDataModel = new Moneda();
                monedaDataModel.pk_moneda = pk_moneda;
                monedaDataModel.moneIso = moneIso;
                monedaDataModel.moneSimbolo = moneSimbolo;
                monedaDataModel.moneLenguaje = moneLenguaje;
                monedaDataModel.moneNombre = moneNombre;
                monedaDataModel.moneEstado = moneEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        monedaRepositorio.insertar(monedaDataModel);
                        break;
                    case EstadoEntidad.modificar:
                        monedaRepositorio.modificar(monedaDataModel);
                        break;
                    case EstadoEntidad.eliminar:
                        monedaRepositorio.eliminar(pk_moneda);
                        break;
                }

            }
            catch (Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    result = "La moneda ya existe";
                }
            }

            return result;
        }

        public void ActualizarEstado(int pk,int estado,string tabla)
        {
            monedaRepositorio.actualizarEstado(pk, estado, tabla);
        }

        public DataView listarMoneda()
        {
            DataView dv = monedaRepositorio.listar();
            return dv;
        }
    }
}
