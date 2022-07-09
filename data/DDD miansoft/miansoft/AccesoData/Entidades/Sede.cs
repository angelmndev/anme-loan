using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Sede
    {
        public int pk_sede { get; set; }
        public string sedeProvincia { get; set; }
        public string sedeDistrito { get; set; }
        public string sedeDireccion { get; set; }
        public double sedeTelefono { get; set; }
        public string sedeCodigoPostal { get; set; }
        public int sedeEstado { get; set; }

    }
}
