using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IUsuarioRepositorio:IRepositorioGenerico<Usuario>
    {
        void actualizarEstado(int pk, int estado, string tabla);
        IEnumerable<Usuario> seleccionarUsuarioXSede(int fk_sede, string sedeDireccion, string usuaTipoCuenta);
    }
}
