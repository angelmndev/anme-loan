using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    interface IAlmacenRepositorio
    {
        int insertar(Almacen entidad);
        DataView listar(string estado);

        IEnumerable<Almacen> seleccionarProductoXCodigo(string codigo);
    }
}
