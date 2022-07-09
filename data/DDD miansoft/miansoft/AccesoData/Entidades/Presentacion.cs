using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Presentacion
    {
        public int pk_presentacion { get; set; }
        public string preseCodigo { get; set; }
        public string preseNombre { get; set; }
        public int preseEstado { get; set; }
    }
}
