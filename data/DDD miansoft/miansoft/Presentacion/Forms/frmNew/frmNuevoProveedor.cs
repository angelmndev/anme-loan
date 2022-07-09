using System;
using System.Windows.Forms;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using Presentacion.MyLibrary;
using Telerik.WinControls.UI;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoProveedor : Form
    {
        private ProveedorModel proveedorModel = new ProveedorModel();
        private DirectionImage directionImage = new DirectionImage();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        public frmNuevoProveedor()
        {
            InitializeComponent();
            chkEstado.Checked = true;
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtRuc.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text) &&
                !string.IsNullOrEmpty(txtGiro.Text);
            return vr;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (ValidarCampoVacio()&&validacionDatos.ComprobarFormatoEmail(txtCorreo.Text,txtCorreo))
            {
                proveedorModel.provNombre = txtNombre.Text;
                proveedorModel.provRuc = Convert.ToDouble(txtRuc.Text);
                proveedorModel.provDireccion = txtDireccion.Text;
                proveedorModel.provEmail = txtCorreo.Text;
                proveedorModel.provGiro = txtGiro.Text;
                proveedorModel.provEstado = (chkEstado.Checked) ? 1 : 0;

                int result = proveedorModel.insertar();
                if(result != 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    box.MessageBox("Informacion", "El proveedor ya existe", directionImage.nameFileImage(DirectionImage.fileImage.information));
                    box.ShowDialog();
                }
            
            }
            else
            {
                RadTextBox[] text = { txtNombre, txtRuc, txtDireccion, txtCorreo, txtGiro };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!ValidarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo))
                    box.MessageBox("Aviso", "El formato del campo email es incorrecto", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtRuc, 11))
                    box.MessageBox("Aviso", "El campo Ruc requiere requiere ni mas ni menos que 11 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));

                box.ShowDialog();
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

        private void txtRuc_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            //mnValidation val = new mnValidation();
            //e.Cancel = !val.IsNumber(e.NewValue);
        }

        int posX = 0;
        int posY = 0;
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtRuc, 11);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDireccion);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo);
        }

        private void txtGiro_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtGiro);
        }
    }
}
