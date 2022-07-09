using Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmDetalleAlmacenProducto : Form
    {
        private AlmacenModel almacenModel = new AlmacenModel();
        public frmDetalleAlmacenProducto()
        {
            InitializeComponent();
        }

        public void DatosProducto(int fk_producto)
        {
            IEnumerable<AlmacenModel> listaProducto = almacenModel.detalleAlmacenProducto(3);
            foreach(var item in listaProducto)
            {
                lbDescripcion.Text = item.prodDescripcion;
            }
        }
        private void frmDetalleAlmacen_Load(object sender, EventArgs e)
        {
            IEnumerable<AlmacenModel> listaProducto = almacenModel.detalleAlmacenProducto(3);
            foreach (var item in listaProducto)
            {
                pbFoto.Image = Image.FromFile(@"recursos/Productos/" + item.prodFoto);
                lbCodigo.Text = item.prodCodigo;
                lbDescripcion.Text = item.prodDescripcion;
                lbCategoria.Text = item.cateNombre;
                lbPresentacion.Text = item.preseNombre;
                lbMarca.Text = item.marcNombre;
                lbUnidadMedida.Text = item.unmeNombre;
                lbCantidad.Text += item.prodCantidad + "\n";
                lbFechaVencimiento.Text += item.prodFechaVencimiento + "\n";
            }
        }
    }
}
