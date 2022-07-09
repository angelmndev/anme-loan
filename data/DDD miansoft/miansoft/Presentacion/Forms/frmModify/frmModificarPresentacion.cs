using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarPresentacion : Form
    {
        private PresentacionModel presentacionModel = new PresentacionModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        private int pkPrese { get; set; }
        public frmModificarPresentacion()
        {
            InitializeComponent();
        }

        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text);
            return vr;
        }

        public void datoPresentacion(List<object> listaPresentacion)
        {
            pkPrese = (int)listaPresentacion[0];
            txtCodigo.Text = listaPresentacion[1].ToString();
            txtNombre.Text = listaPresentacion[2].ToString();
            chkEstado.Checked = ((int)listaPresentacion[3] == 1) ? true : false;
        }
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (ValidarCampoVacio())
            {
                presentacionModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                presentacionModel.pk_presentacion = pkPrese;
                presentacionModel.preseCodigo = txtCodigo.Text;
                presentacionModel.preseNombre = txtNombre.Text;
                presentacionModel.preseEstado = (chkEstado.Checked) ? 1 : 0;
                string mensaje = presentacionModel.GuardarCambios();
                if (mensaje == "")
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
                if (!ValidarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtCodigo, 9))
                    box.MessageBox("Aviso", "El campo codigo debe tener ni menos de 9 ni mas de 15", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                box.ShowDialog();
            }

        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int posX = 0;
        int posY = 0;
        private void PnHeader_MouseMove(object sender, MouseEventArgs e)
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo, 9);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }
    }
}
