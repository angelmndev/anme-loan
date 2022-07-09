using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Personal
    {
        public int pk_personal { get; set; }
        public string persNombre { get; set; }
        public string persApellido { get; set; }
        public string persDireccion { get; set; }
        public double persDni { get; set; }
        public string persSexo { get; set; }
        public DateTime persFechaNac { get; set; }
        public string persTelefono { get; set; }
        public string persEmail { get; set; }
        public int fk_cargo { get; set; }
        public int fk_turno { get; set; }
        public int persEstado { get; set; }

    }
}
