using AccesoData.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData.Contratos
{
    public interface IMainRepositorio
    {
        int stockMin(int notifi);
        int fechaVencimiento(int notifi);
        DataView AlertaStock(int notifi);
        DataView AlertaFechaVencimiento(int notifi);
        string Mensaje();
    }
}
