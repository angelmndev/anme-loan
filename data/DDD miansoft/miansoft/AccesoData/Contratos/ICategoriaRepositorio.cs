using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface ICategoriaRepositorio: IRepositorioGenerico<Categoria>
    {
        void actualizarEstado(int pk, int estado, string tabla);
        IEnumerable<Categoria> GetAll();
        IEnumerable<Categoria> seleccionarCategoria(int pk_categoria);
    }
}
