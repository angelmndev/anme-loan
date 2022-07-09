using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IRepositorioGenerico<Entidades> where Entidades:class
    {
        int insertar(Entidades entidades);
        int modificar(Entidades entidades);
        int eliminar(int pk);

        DataView listar();
    }
}
