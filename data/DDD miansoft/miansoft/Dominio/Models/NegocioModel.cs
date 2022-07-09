using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class NegocioModel
    {
        public int pk_negocio { get; set; }
        public string negoNombreComercial { get; set; }
        public string negoNombreFiscal { get; set; }
        public string negoNif { get; set; }
        public string negoEmail { get; set; }
        public string negoWeb { get; set; }
        public string negoPais { get; set; }
        public string negoProvincia { get; set; }
        public string negoCodigoPostal { get; set; }

        private NegocioRepositorio negocioRepositorio;
        public EstadoEntidad estado { get; set; }

        public NegocioModel()
        {
            negocioRepositorio = new NegocioRepositorio();
        }

        public void GuardarCambios()
        {
            var negocioDataModel = new Negocio();
            negocioDataModel.pk_negocio = pk_negocio;
            negocioDataModel.negoNombreComercial = negoNombreComercial;
            negocioDataModel.negoNombreFiscal = negoNombreFiscal;
            negocioDataModel.negoNif = negoNif;
            negocioDataModel.negoEmail = negoEmail;
            negocioDataModel.negoWeb = negoWeb;
            negocioDataModel.negoPais = negoPais;
            negocioDataModel.negoProvincia = negoProvincia;
            negocioDataModel.negoCodigoPostal = negoCodigoPostal;

            switch (estado)
            {
                case EstadoEntidad.insertar:
                    negocioRepositorio.insertar(negocioDataModel);
                    break;
                case EstadoEntidad.modificar:
                    negocioRepositorio.modificar(negocioDataModel);
                    break;
            }
        }

        public IEnumerable<NegocioModel> GetAll()
        {
            var negocioDataModel = negocioRepositorio.GetAll();
            var listaNegocio = new List<NegocioModel>();
            foreach (var item in negocioDataModel)
            {
                listaNegocio.Add(new NegocioModel
                {
                    pk_negocio = item.pk_negocio,
                    negoNombreComercial = item.negoNombreComercial,
                    negoNombreFiscal = item.negoNombreFiscal,
                    negoNif = item.negoNif,
                    negoEmail = item.negoEmail,
                    negoWeb = item.negoWeb,
                    negoPais = item.negoPais,
                    negoProvincia = item.negoProvincia,
                    negoCodigoPostal = item.negoCodigoPostal

                });
            }
            return listaNegocio;
        }

        public bool negocioExistente()
        {
            if (negocioRepositorio.negocioExistente())
                return true;
            else
                return false;
            
        }
    }
}
