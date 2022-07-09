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
    public partial class frmNuevoSede : Form
    {
        private SedeModel sedeModel = new SedeModel();
        private DirectionImage directionImage = new DirectionImage();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        public frmNuevoSede()
        {
            InitializeComponent();
        }

        private bool ValidarCampoVacio()
        {
            bool estado = !string.IsNullOrEmpty(txtProvincia.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtCodigoPostal.Text);
            return estado;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (ValidarCampoVacio() && validacionDatos.validarTexboxRange(txtTelefono, 9))
            {
                sedeModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                sedeModel.sedeProvincia = txtProvincia.Text;
                sedeModel.sedeDistrito = txtDistrito.Text;
                sedeModel.sedeDireccion = txtDireccion.Text;
                sedeModel.sedeTelefono = Convert.ToDouble(txtTelefono.Text);
                sedeModel.sedeCodigoPostal = txtCodigoPostal.Text;
                sedeModel.sedeEstado = (chkEstado.Checked) ? 1 : 0;
                string mensaje = sedeModel.GuardarCambios();
                if(mensaje == "")
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
                RadTextBox[] text = { txtProvincia, txtDistrito, txtDireccion, txtTelefono };
                for(int i = 0;i < text.Length; i++)
                {
                    if(text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!ValidarCampoVacio())
                {
                    box.MessageBox("Informacion", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.information));
                }
                else if (!validacionDatos.validarTexboxRange(txtTelefono, 9))
                {
                    box.MessageBox("Informacion", "El campo telefono debe tener no mens de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.information));
                }             
                box.ShowDialog();
            }
        }

        private void txtProvincia_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtProvincia);
        }

        private void txtDistrito_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDistrito);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDireccion);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtTelefono,9);
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCodigoPostal);
        }

        private void frmNuevoSede_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
