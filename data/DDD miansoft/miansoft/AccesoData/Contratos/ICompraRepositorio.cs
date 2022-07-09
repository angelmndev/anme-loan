using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface ICompraRepositorio
    {
        int insertar(Compra compra);

        DataView listarProductoCompra();
    }
}
