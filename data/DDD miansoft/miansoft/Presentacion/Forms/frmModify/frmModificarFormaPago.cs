using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarFormaPago : Form
    {
        private FormaPagoModel formaPagoModel = new FormaPagoModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private int pkFormaPago { get; set; }
        public frmModificarFormaPago()
        {
            InitializeComponent();
        }

        public void DatosFormaPago(List<object> listaFopa)
        {
            pkFormaPago = Convert.ToInt32(listaFopa[0]);
            txtFormaDePago.Text = listaFopa[1].ToString();
            chkEstado.Checked = ((int)listaFopa[2] == 1) ? true : false;
        }

        private bool ValidarCampoVacio()
        {
            bool estado = !string.IsNullOrEmpty(txtFormaDePago.Text);
            return estado;
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            DirectionImage directionImage = new DirectionImage();
            frmMessageBox box = new frmMessageBox();
            if (ValidarCampoVacio())
            {
                formaPagoModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                formaPagoModel.pk_formaPago = pkFormaPago;
                formaPagoModel.fopaNombre = txtFormaDePago.Text;
                formaPagoModel.fopaEstado = (chkEstado.Checked) ? 1 : 0;
                string mensaje = formaPagoModel.GuardarCambios();
                if (mensaje == "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    box.MessageBox("Informacion", mensaje, directionImage.nameFileImage(DirectionImage.fileImage.information));
                    box.ShowDialog();
                }
            }
            else
            {
                validacionDatos.validarCampoVacioTxt(txtFormaDePago);

                box.MessageBox("Aviso", "El campo forma de pago es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.information));
                box.ShowDialog();
            }
        }

        private void txtFormaDePago_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtFormaDePago);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int posX = 0;
        private int posY = 0;
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
    }
}
