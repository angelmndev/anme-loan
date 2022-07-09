using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Entidades
{
    public class Producto
    {
        public int pk_producto { get; set; }
        public string prodDescripcion { get; set; }
        public string prodCodigo { get; set; }
        public double prodPrecioUnitario { get; set; }
        public string prodFoto { get; set; }
        public double prodStkMin { get; set; }
        public double prodStkMax { get; set; }
        public int fk_categoria { get; set; }
        public int fk_presentacion { get; set; }
        public int fk_unidadMedida { get; set; }
        public int fk_marca { get; set; }
        public int prodEstado { get; set; }
        public int prodPerecedero { get; set; }

    }
}
