using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarCategoria : Form
    {
        private CategoriaModel categoriaModel = new CategoriaModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private int pkCategoria { get; set; }
        public frmModificarCategoria()
        {
            InitializeComponent();
        }

        public void DatoCategoria(List<object>  listaCate)
        {

            pkCategoria = (int)listaCate[0];
            txtCodigo.Text = listaCate[1].ToString();
            txtNombre.Text = listaCate[2].ToString();
            chkEstado.Checked = ((int)listaCate[3] == 1) ? true : false;
        }

        private bool validarCampoVacio()
        {
            bool estado = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text);
            return estado;
        }

        private void BtActualizar_Click(object sender, EventArgs e)
        {
            DirectionImage directionImage = new DirectionImage();

            frmMessageBox box = new frmMessageBox();
            if (validarCampoVacio() && validacionDatos.validarTexboxRange(txtCodigo, 11))
            {
                categoriaModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                categoriaModel.Pk_categoria = pkCategoria;
                categoriaModel.CateCodigo = txtCodigo.Text;
                categoriaModel.CateNombre = txtNombre.Text;
                categoriaModel.CateEstado = (chkEstado.Checked) ? 1 : 0;

                string mensaje = categoriaModel.GuardarCambios();
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
                if (!validarCampoVacio())
                    box.MessageBox("Informacion", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.information));
                if (!validacionDatos.validarTexboxRange(txtCodigo, 11))
                    box.MessageBox("Informacion", "El campo codigo bebe tener no menos de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.information));

                box.ShowDialog();
            }


        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
           
            //this.Close();
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
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo, 11);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }
    }
}
