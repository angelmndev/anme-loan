using AccesoData.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class MainModel
    {
        public double prodCantidad { get; set; }
        public double prodStockMin { get; set; }
        public string prodDescripcion { get; set; }
        public string prodFechaVencimiento { get; set; }

        private MainRepositorio mainRepositorio;

        public MainModel()
        {
            mainRepositorio = new MainRepositorio();
        }

        public DataView AlertaFechaVencimiento(int notifi)
        {
            DataView dv = mainRepositorio.AlertaFechaVencimiento(notifi);
            return dv;
        }

        public DataView AlertaStock(int notifi)
        {
            DataView dv = mainRepositorio.AlertaFechaVencimiento(notifi);
            return dv;
        }
        public int stockMin(int notifi)
        {
            int contador = mainRepositorio.stockMin(notifi);
            return contador;
        }
        public int fechaVencimiento(int notifi)
        {
            int contador = mainRepositorio.fechaVencimiento(notifi);
            return contador;
        }
    }
}
