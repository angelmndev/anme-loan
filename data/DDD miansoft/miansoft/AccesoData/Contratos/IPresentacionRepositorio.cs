using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IPresentacionRepositorio: IRepositorioGenerico<Presentacion>
    {
        IEnumerable<Presentacion> GettAll();
        IEnumerable<Presentacion> seleccionarPresentacion(int pk_presentacion);
        void actualizarEstado(int pk, int estado, string tabla);
    }
}
