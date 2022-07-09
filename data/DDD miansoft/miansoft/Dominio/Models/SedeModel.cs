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
    public class SedeModel
    {
        public int pk_sede { get; set; }
        public string sedeProvincia { get; set; }
        public string sedeDistrito { get; set; }
        public string sedeDireccion { get; set; }
        public double sedeTelefono { get; set; }
        public string sedeCodigoPostal { get; set; }
        public int sedeEstado { get; set; }

        private SedeRepositorio sedeRepositorio;
        public EstadoEntidad estado { get; set; }
        
        public SedeModel()
        {
            sedeRepositorio = new SedeRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var sedeDataModel = new Sede();
                sedeDataModel.pk_sede = pk_sede;
                sedeDataModel.sedeProvincia = sedeProvincia;
                sedeDataModel.sedeDistrito = sedeDistrito;
                sedeDataModel.sedeDireccion = sedeDireccion;
                sedeDataModel.sedeTelefono = sedeTelefono;
                sedeDataModel.sedeCodigoPostal = sedeCodigoPostal;
                sedeDataModel.sedeEstado = sedeEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        sedeRepositorio.insertar(sedeDataModel);
                        break;
                    case EstadoEntidad.modificar:
                        sedeRepositorio.modificar(sedeDataModel);
                        break;
                    case EstadoEntidad.eliminar:
                        sedeRepositorio.eliminar(pk_sede);
                        break;
                }
            }
            catch(Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if(sqlException!=null&&sqlException.Number == 2627)
                {
                    mensaje = "El sede ya existe";
                }
            }
            return mensaje;
        }

        public DataView listarSede()
        {
            DataView dv = sedeRepositorio.listar();
            return dv;
        }

        public void actualizrEstado(int pk,int estado,string tabla)
        {
            sedeRepositorio.actualizarEstado(pk, estado, tabla);
        }

        public IEnumerable<SedeModel> seleccionaSede(int pk_sede)
        {
            var sedeDataModel = sedeRepositorio.seleccionarSede(pk_sede);
            var listaSede = new List<SedeModel>();
            foreach(var item in sedeDataModel)
            {
                listaSede.Add(new SedeModel
                {
                    pk_sede = item.pk_sede,
                    sedeProvincia = item.sedeProvincia,
                    sedeDistrito = item.sedeDistrito,
                    sedeDireccion = item.sedeDireccion,
                    sedeTelefono = item.sedeTelefono,
                    sedeCodigoPostal = item.sedeCodigoPostal,
                    sedeEstado = item.sedeEstado
                });
            }
            return listaSede;
        }
    }
}
