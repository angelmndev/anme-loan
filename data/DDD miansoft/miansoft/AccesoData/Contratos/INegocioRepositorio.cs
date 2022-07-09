using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface INegocioRepositorio
    {
        void insertar(Negocio negocio);
        void modificar(Negocio negocio);

        bool negocioExistente();
        IEnumerable<Negocio> GetAll();
    }
}
