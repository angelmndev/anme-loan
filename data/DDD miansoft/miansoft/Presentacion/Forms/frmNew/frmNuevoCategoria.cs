using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Windows.Forms;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoCategoria : Form
    {
        private CategoriaModel categoriaModel = new CategoriaModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        public frmNuevoCategoria()
        {
            InitializeComponent();
            chkEstado.Checked = true;
        }

        private bool validarCampoVacio()
        {
            bool estado = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text);
            return estado;
        }
        private void BtGuardar_Click(object sender, EventArgs e)
        {
            DirectionImage directionImage = new DirectionImage();

            frmMessageBox box = new frmMessageBox();
            if (validarCampoVacio() && validacionDatos.validarTexboxRange(txtCodigo, 11))
            {
                categoriaModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
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
                    box.MessageBox("Informacion", "Todos los campos son importantes",directionImage.nameFileImage(DirectionImage.fileImage.information));
                if (!validacionDatos.validarTexboxRange(txtCodigo, 11))
                    box.MessageBox("Informacion", "El campo codigo bebe tener no menos de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.information));

                box.ShowDialog();
            }



        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// --VALIDAR CAMPO VACIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void FrmNuevoCategoria_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
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
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            long codigo = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            txtCodigo.Text = codigo.ToString();
            validacionDatos.validarTexboxRange(txtCodigo, 11);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }
    }
}
