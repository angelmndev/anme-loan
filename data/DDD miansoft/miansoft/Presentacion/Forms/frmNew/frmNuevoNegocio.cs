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
    public partial class frmNuevoNegocio : Form
    {
        private NegocioModel negocioModel = new NegocioModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoNegocio()
        {
            InitializeComponent();
        }

        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtNombreComercial.Text) &&
                !string.IsNullOrEmpty(txtNombreFiscal.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text) &&
                !string.IsNullOrEmpty(txtWeb.Text) &&
                !string.IsNullOrEmpty(txtPais.Text) &&
                !string.IsNullOrEmpty(txtProvincia.Text) &&
                !string.IsNullOrEmpty(txtNif.Text) &&
                !string.IsNullOrEmpty(txtCodigoPostal.Text);
            return vr;
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio() && validacionDatos.ComprobarFormatoEmail(txtEmail.Text,txtEmail))
            {
                negocioModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                negocioModel.negoNombreComercial = txtNombreComercial.Text;
                negocioModel.negoNombreFiscal = txtNombreFiscal.Text;
                negocioModel.negoNif = txtNif.Text;
                negocioModel.negoEmail = txtEmail.Text;
                negocioModel.negoWeb = txtWeb.Text;
                negocioModel.negoPais = txtPais.Text;
                negocioModel.negoProvincia = txtProvincia.Text;
                negocioModel.negoCodigoPostal = txtCodigoPostal.Text;
                negocioModel.GuardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                RadTextBox[] text = { txtNombreComercial, txtNombreFiscal, txtNif, txtEmail, txtEmail, txtWeb, txtPais, txtProvincia, txtCodigoPostal }; 
                for(int i = 0;i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }
                frmMessageBox box = new frmMessageBox();
                if (!ValidarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.information));
                else if (!validacionDatos.ComprobarFormatoEmail(txtEmail.Text, txtEmail))
                    box.MessageBox("Aviso", "El email ingresado es invalido por favor coloca un email valido", directionImage.nameFileImage(DirectionImage.fileImage.information));
                box.ShowDialog();
            }
        }

        private void txtNombreComercial_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombreComercial);
        }

        private void txtNombreFiscal_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombreFiscal);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.ComprobarFormatoEmail(txtEmail.Text,txtEmail);
        }

        private void txtWeb_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtWeb);
        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtPais);
        }

        private void txtProvincia_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtProvincia);
        }

        private void txtNif_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNif);
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCodigoPostal);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
