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

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoComprobante : Form
    {
        private ComprobanteModel comprobanteModel = new ComprobanteModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoComprobante()
        {
            InitializeComponent();
            chkEstado.Checked = true;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (ValidarCampoVacio())
            {
                comprobanteModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;

                comprobanteModel.comCodigo = txtCodigo.Text;
                comprobanteModel.comNombre = txtNombre.Text;
                comprobanteModel.comSerie = txtSerie.Text;
                comprobanteModel.comCorrelativo = Convert.ToInt32(txtCorrelativo.Text);
                comprobanteModel.comEstado = (chkEstado.Checked) ? 1 : 0;

                string mensaje = comprobanteModel.GuardarCambios();
                if(mensaje == "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    box.MessageBox("Aviso", mensaje, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                }         

            }
            else
            {
                RadTextBox[] text = { txtCodigo, txtNombre, txtSerie, txtCorrelativo }; 
                for(int i = 0;i < text.Length; i++)
                {
                    if(text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }
                if(!ValidarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if(!validacionDatos.validarTexboxRange(txtCodigo,9))
                    box.MessageBox("Aviso", "El campo codigo debe tener no menos de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                box.ShowDialog();
            }
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text)&&
                !string.IsNullOrEmpty(txtSerie.Text) &&
                !string.IsNullOrEmpty(txtCorrelativo.Text);
            return vr;
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
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void frmNuevoComprobante_Load(object sender, EventArgs e)
        {
           
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo, 9);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtSerie);
        }

        private void txtCorrelativo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCorrelativo);
        }

        private void txtCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyLibrary.mnValidation valid = new MyLibrary.mnValidation();
            valid.soloNumeros(e);
        }
    }
}
