using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class PersonalModel
    {
        private int pk_personal;
        private string persNombre;
        private string persApellido;
        private string persDireccion;
        private double persDni;
        private string persSexo;
        private DateTime persFechaNac;
        private string persTelefono;
        private string persEmail;
        private int fk_cargo;
        private int fk_turno;
        private int persEstado;

        //Encapsulamiento de atributos
        public int Pk_personal { get => pk_personal; set => pk_personal = value; }
        [Required(ErrorMessage ="campo Nombre es obligatorio")]
        public string PersNombre { get => persNombre; set => persNombre = value; }
        [Required(ErrorMessage = "campo Apellido es obligatorio")]
        public string PersApellido { get => persApellido; set => persApellido = value; }
        [Required(ErrorMessage = "campo Direccion es obligatorio")]
        public string PersDireccion { get => persDireccion; set => persDireccion = value; }
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double PersDni { get => persDni; set => persDni = value; }
        [Required(ErrorMessage = "campo Sexo es obligatorio")]

        public string PersSexo { get => persSexo; set => persSexo = value; }
        public DateTime PersFechaNac { get => persFechaNac; set => persFechaNac = value; }
        [Required(ErrorMessage = "campo Telefono es obligatorio")]
        public string PersTelefono { get => persTelefono; set => persTelefono = value; }
        [Required(ErrorMessage = "campo Email es obligatorio")]
        public string PersEmail { get => persEmail; set => persEmail = value; }
        public int Fk_cargo { get => fk_cargo; set => fk_cargo = value; }
        public int Fk_turno { get => fk_turno; set => fk_turno = value; }
        public int PersEstado { get => persEstado; set => persEstado = value; }

        private PersonalRepositorio personalRepositorio;
        public EstadoEntidad estado { get; set; }

        //Constructor
        public PersonalModel()
        {
            personalRepositorio = new PersonalRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var persoDataModel = new Personal();
                persoDataModel.pk_personal = pk_personal;
                persoDataModel.persNombre = persNombre;
                persoDataModel.persApellido = persApellido;
                persoDataModel.persDireccion = persDireccion;
                persoDataModel.persDni = persDni;
                persoDataModel.persSexo = persSexo;
                persoDataModel.persFechaNac = persFechaNac;
                persoDataModel.persTelefono = persTelefono;
                persoDataModel.persEmail = persEmail;
                persoDataModel.fk_cargo = fk_cargo;
                persoDataModel.fk_turno = fk_turno;
                persoDataModel.persEstado = persEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        personalRepositorio.insertar(persoDataModel);
                        mensaje = "Se guardo correctamente";
                        break;
                    case EstadoEntidad.modificar:
                        personalRepositorio.modificar(persoDataModel);
                        mensaje = "Se actualizo correctamente";
                        break;
                    case EstadoEntidad.eliminar:
                        personalRepositorio.eliminar(pk_personal);
                        mensaje = "Se elimino correctamente";
                        break;
                }
            }
            catch
            {

            }

            return mensaje;
        }

        public DataView listarPersonal()
        {
            DataView dv = personalRepositorio.listar();

            return dv;
        }

        public void ActualizarEstado(int pk, int estado, string tabla)
        {
            personalRepositorio.actualizarEstado(pk, estado, tabla);
        }
    }
}
