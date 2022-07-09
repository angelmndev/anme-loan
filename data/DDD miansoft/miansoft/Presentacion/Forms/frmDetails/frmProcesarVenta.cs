using Presentacion.Forms.Main;
using Presentacion.Forms.subMenu;
using Presentacion.Helps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmProcesarVenta : Form
    {
        private DirectionImage directionImage = new DirectionImage();
        public frmProcesarVenta()
        {
            InitializeComponent();
        }

        public void datosProcesarVenta(double totalP,string cliente ,string formaPago)
        {
            double montoRecibido = 0;

            lbCliente.Text = "Cliente: "+cliente;
            lbDetalles.Text = "Forma Pago: " + formaPago;
            txtTotalPagar.Text = totalP.ToString("C");
            txtMontoRecibido.Text = montoRecibido.ToString("C");
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            frmVentas Ventas = Owner as frmVentas;
            frmMessageBox box = new frmMessageBox();
            box.MessageBox("Informacion", "Desea imprimir ticket...?", directionImage.nameFileImage(DirectionImage.fileImage.print));
            DialogResult result = box.ShowDialog();
            if(result == DialogResult.OK)
            {
                Ventas.estadoPrintTicketera(true);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
           
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int posX { get; set; }
        private int posY { get; set; }
        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left += (e.X - posX);
                Top += (e.Y - posY);
            }
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if(txtMontoRecibido.Text != "")
            {
                double montoRecibido = double.Parse(txtMontoRecibido.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
                double montoACobrar = double.Parse(txtTotalPagar.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
                txtVuelto.Text = (montoRecibido - montoACobrar).ToString("C");
            }
            
        }

        private void txtMontoRecibido_Enter(object sender, EventArgs e)
        {
            txtMontoRecibido.Clear();
        }

        private void txtMontoRecibido_Leave(object sender, EventArgs e)
        {
            if(txtMontoRecibido.Text == "")
            {
                double montoRecibido = 0;
                txtMontoRecibido.Text = montoRecibido.ToString("C");
            }
            else
            {
                double montoRecibido = double.Parse(txtMontoRecibido.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
                txtMontoRecibido.Text = montoRecibido.ToString("C");
            }
        }
    }
}
