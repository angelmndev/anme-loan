using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IFormaPagoRepositorio:IRepositorioGenerico<FormaPago>
    {
        void actualizarEstado(int pk, int estado, string tabla);
    }
}
