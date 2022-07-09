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
    public class CargoModel
    {
        private int pk_cargo;
        private string cargNombre;
        private int cargEstado;

        //Encapsular atributos
        public int Pk_cargo { get => pk_cargo; set => pk_cargo = value; }
        [Required(ErrorMessage ="campo Nombre es obligatorio")]
        public string CargNombre { get => cargNombre; set => cargNombre = value; }
        public int CargEstado { get => cargEstado; set => cargEstado = value; }

        private CargoRepositorio cargoRepositorio;
        public EstadoEntidad estado { get; set; }

        public CargoModel()
        {
            cargoRepositorio = new CargoRepositorio();
        }

        public string GardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var cargoDataModel = new Cargo();
                cargoDataModel.pk_cargo = pk_cargo;
                cargoDataModel.cargNombre = cargNombre;
                cargoDataModel.cargEstado = cargEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        cargoRepositorio.insertar(cargoDataModel);
                        mensaje = "Se gurado correctamente";
                        break;
                    case EstadoEntidad.modificar:
                        cargoRepositorio.modificar(cargoDataModel);
                        mensaje = "Se actualizo correctamente";
                        break;
                    case EstadoEntidad.eliminar:
                        cargoRepositorio.eliminar(pk_cargo);
                        mensaje = "Se elimino correctamnte";
                        break;
                }
            }
            catch
            {

            }

            return mensaje;
        }

        public DataView listarCargo()
        {
            DataView dv = cargoRepositorio.listar();

            return dv;
        }

        public void ActualizarEstado(int pk,int estado,string tabla)
        {
            cargoRepositorio.actualizarEstado(pk, estado, tabla);
        }

        public List<CargoModel> llenarCombo()
        {
            var resultCargo = cargoRepositorio.llennarCombo();
            List<CargoModel> listaCargo = new List<CargoModel>();
            foreach(Cargo item in resultCargo)
            {
                listaCargo.Add(new CargoModel
                {
                    pk_cargo = item.pk_cargo,
                    cargNombre = item.cargNombre
                });
            }
            return listaCargo;
        } 
    }
}
