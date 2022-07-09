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
using Telerik.WinControls.UI;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarMoneda : Form
    {
        private MonedaModel monedaModel = new MonedaModel();
        private DirectionImage directionImage = new DirectionImage();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private int pkMoneda { get; set; }
        public frmModificarMoneda()
        {
            InitializeComponent();
        }

        public void DatosMoneda(List<object> listaMoneda)
        {
            pkMoneda = (int)listaMoneda[0];
            txtCodigo.Text = listaMoneda[1].ToString();
            txtSimbolo.Text = listaMoneda[2].ToString();
            txtLenguaje.Text = listaMoneda[3].ToString();
            txtNombre.Text = listaMoneda[4].ToString();
            chkEstado.Checked = ((int)listaMoneda[5] == 1) ? true : false;
        }
        private void btActualizar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (ValidacionCampoVacio())
            {
                monedaModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                monedaModel.pk_moneda = pkMoneda;
                monedaModel.moneIso = txtCodigo.Text;
                monedaModel.moneSimbolo = txtSimbolo.Text;
                monedaModel.moneLenguaje = txtLenguaje.Text;
                monedaModel.moneNombre = txtNombre.Text;
                monedaModel.moneEstado = (chkEstado.Checked) ? 1 : 0;
                string mensaje = monedaModel.GuardarCambios();
                if (mensaje == "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    box.MessageBox("Aviso", mensaje, directionImage.nameFileImage(DirectionImage.fileImage.information));
                    box.ShowDialog();
                }
            }
            else
            {
                RadTextBox[] text = { txtCodigo, txtSimbolo, txtLenguaje, txtNombre };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!ValidacionCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                box.ShowDialog();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidacionCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtSimbolo.Text) &&
                !string.IsNullOrEmpty(txtLenguaje.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text);
            return vr;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCodigo);
        }

        private void txtSimbolo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtSimbolo);
        }

        private void txtLenguaje_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtLenguaje);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private int posX = 0;
        private int posY = 0;
        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
