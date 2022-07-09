using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IProductoRepositorio:IRepositorioGenerico<Producto>
    {
        IEnumerable<Producto> seleccionarProducto(int pk);
        void modificarPrecioVenta(int pk, double prodPrecioUnitario);
    }
}
