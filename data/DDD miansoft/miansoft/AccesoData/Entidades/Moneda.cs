using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Moneda
    {
        public int pk_moneda { get; set; }
        public string moneIso { get; set; }
        public string moneSimbolo { get; set; }
        public string moneLenguaje { get; set; }
        public string moneNombre { get; set; }
        public int moneEstado { get; set; }

    }
}
