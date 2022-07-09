using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class TurnoModel
    {
        private int pk_turno;
        private string turnNombre;
        private string turnHentrada;
        private string turnHsalida;
        private int turnEstado;

        public int Pk_turno { get => pk_turno; set => pk_turno = value; }
        [Required(ErrorMessage ="campo Nombre es obligatorio")]
        public string TurnNombre { get => turnNombre; set => turnNombre = value; }
        [Required(ErrorMessage = "campo Hora entrada es obligatorio")]
        public string TurnHentrada { get => turnHentrada; set => turnHentrada = value; }
        [Required(ErrorMessage = "campo Hora salida es obligatorio")]
        public string TurnHsalida { get => turnHsalida; set => turnHsalida = value; }

        public int TurnEstado { get => turnEstado; set => turnEstado = value; }


        private TurnoRepositorio turnoRepositorio;
        public EstadoEntidad estado { get; set; }
        public TurnoModel()
        {
            turnoRepositorio = new TurnoRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            { 

                var turnoDataModel = new Turno();
                turnoDataModel.pk_turno = pk_turno;
                turnoDataModel.turnNombre = turnNombre;
                turnoDataModel.turnHentrada = turnHentrada;
                turnoDataModel.turnHsalida = turnHsalida;
                turnoDataModel.turnEstado = turnEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        turnoRepositorio.insertar(turnoDataModel);
                        mensaje = "Se inserto correctamente";
                        break;
                    case EstadoEntidad.modificar:
                        turnoRepositorio.modificar(turnoDataModel);
                        mensaje = "Se actualiazo correctamente";
                        break;
                    case EstadoEntidad.eliminar:
                        turnoRepositorio.eliminar(pk_turno);
                        mensaje = "Se elimino correctamente";
                        break;
                }
            }
            catch
            {

            }

            return mensaje;
        }
        public DataView listarTurno()
        {
            DataView dv = turnoRepositorio.listar();
            return dv;
        }

        public void ActualizarEstado(int pk,int estado,string tabla)
        {
            turnoRepositorio.actualizarEstado(pk, estado, tabla);
        }

    }
}
