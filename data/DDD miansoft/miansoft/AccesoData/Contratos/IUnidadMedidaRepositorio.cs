using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IUnidadMedidaRepositorio:IRepositorioGenerico<UnidadMedida>
    {
        void actualizarEstado(int pk, int estado, string tabla);
        IEnumerable<UnidadMedida> seleccionarUnme(int pk_unidadMedida);
    }
}
