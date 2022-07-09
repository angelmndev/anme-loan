using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IMarcaRepositorio:IRepositorioGenerico<Marca>
    {
       void actualizarEstado(int pk, int estado,string tabla);
       IEnumerable<Marca> GetAll();
       IEnumerable<Marca> seleccionarMarca(int pk_marca);
    }
}
