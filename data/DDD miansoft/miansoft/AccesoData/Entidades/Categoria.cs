using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Categoria
    {
        public int pk_categoria { get; set; }
        public string cateCodigo { get; set; }
        public string cateNombre { get; set; }
        public int cateEstado { get; set; }

    }
}
