using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Negocio
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

    }
}
