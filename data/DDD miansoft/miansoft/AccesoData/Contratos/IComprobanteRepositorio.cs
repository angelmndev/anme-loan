using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    interface IComprobanteRepositorio:IRepositorioGenerico<Comprobante>
    {
        void actualizarEstado(int pk, int estado, string tabla);

        IEnumerable<Comprobante> seleccionarComrobante(int pk_comprobante);
    }
}
