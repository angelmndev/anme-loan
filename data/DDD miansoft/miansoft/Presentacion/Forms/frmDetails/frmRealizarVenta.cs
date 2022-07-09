using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Presentacion.MyLibrary;
using Presentacion.Forms.subMenu;
using Dominio.Models;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmRealizarVenta : Form
    {
        private ProductoModel productoModel = new ProductoModel();
        private int pkProducto { get; set; }
        public frmRealizarVenta()
        {
            InitializeComponent();
        }
        private IEnumerable<ProductoModel> listaProducto;
        private List<object> ListaAlmacen;
        public void datosProducto(List<object> listaAlmacen)
        {
            ListaAlmacen = listaAlmacen;
            listaProducto =  productoModel.seleccionarProducto((int)listaAlmacen[0]);
            foreach(var item in listaProducto)
            {
                double descuento = 0;
                pkProducto = item.pk_producto;
                lbDescripcion.Text = item.prodDescripcion;
                lbDetalles.Text = "Presentacion: " + listaAlmacen[6].ToString() + "\n" + "Ud. medida: " + listaAlmacen[5].ToString();
                lbStock.Text = listaAlmacen[7].ToString();
                txtPrecio.Text = item.prodPrecioUnitario.ToString("C");
                txtDescuento.Text = descuento.ToString("C");

                if (item.prodFoto == "")
                    pbFoto.Image = Image.FromFile(@"recursos/img/imgDoont.png");
                else
                    pbFoto.Image = Image.FromFile(@"recursos/Productos/" + item.prodFoto);
            }
         
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double precio = double.Parse(txtPrecio.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
            double descuento = double.Parse(txtDescuento.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
            double importe = cantidad * precio;
            List<object> listaVede = new List<object>();

            foreach(var item in listaProducto)
            {
                listaVede.Add(pkProducto);
                listaVede.Add(cantidad);
                listaVede.Add(item.prodDescripcion);
                listaVede.Add(ListaAlmacen[3]);
                listaVede.Add(ListaAlmacen[6]);
                listaVede.Add(ListaAlmacen[4]);
                listaVede.Add(ListaAlmacen[5]);
                listaVede.Add(descuento);
                listaVede.Add(precio);
                listaVede.Add(importe);
            }
         
            /* DataRow dr = table.NewRow();
            dr[0] = pkProducto;
            dr[1] = cantidad;
            dr[2] = objProd.prodDescripcion;
            dr[3] = objCat.cateNombre;
            dr[4] = objPres.preseNombre;
            dr[5] = objMrc.marcNombre;
            dr[6] = objUM.unmeNombre;
            dr[7] = descuento;
            dr[8] = precio;
            dr[9] = (precio * cantidad) - descuento;*/

            frmVentas ventas = Owner as frmVentas;
            ventas.DatosVentaDetalle(listaVede);
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int posX = 0;
        int posY = 0;
        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX =e.X ;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtDescuento_Enter(object sender, EventArgs e)
        {
            txtDescuento.Text = "";
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "" || txtDescuento.Text == "0")
            {
                double descuento = 0;
                txtDescuento.Text = descuento.ToString("C");
            }
            else
            {
                double descuento = double.Parse(txtDescuento.Text);
                txtDescuento.Text = descuento.ToString("C");
            }

        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            mnValidation val = new mnValidation();
            val.soloNumeroDecimal(sender, e);
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            mnValidation val = new mnValidation();
            val.soloNumeroDecimal(sender, e);
        }
    }
}
