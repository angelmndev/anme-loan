using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Turno
    {
        public int pk_turno { get; set; }
        public string turnNombre { get; set; }
        public string turnHentrada { get; set; }
        public string turnHsalida { get; set; }
        public int turnEstado { get; set; }
    }
}
