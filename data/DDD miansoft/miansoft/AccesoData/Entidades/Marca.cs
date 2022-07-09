using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Marca
    {
        public int pk_marca { get; set; }
        public string marcCodigo { get; set; }
        public string marcNombre { get; set; }
        public int marcEstado { get; set; }

    }
}
