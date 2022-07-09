using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Compra
    {
        public int pk_compra { get; set; }
        public int fk_proveedor { get; set; }
        public int fk_personal { get; set; }
        public string compDocuCodigo { get; set; }
        public string compDocuNombre { get; set; }
        public int compDocuNumero { get; set; }
        public string compFechaCompra { get; set; }
        public int compEstado { get; set; }
    }
}
