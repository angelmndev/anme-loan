using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections;
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
    public partial class frmModificarMarca : Form
    {
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private MarcaModel objMarca = new MarcaModel();
        private DirectionImage directionImage = new DirectionImage();
        private int pkMarca { get; set; }
        public frmModificarMarca()
        {
            InitializeComponent();
        }

        public void datosMarca(List<object> lista)
        {
            List<object> listaMarca = lista;

            pkMarca = Convert.ToInt32(listaMarca[0]);
            txtCodigo.Text = listaMarca[1].ToString();
            txtNombre.Text = listaMarca[2].ToString();
            chkEstado.Checked = ((int)listaMarca[3] == 1) ? true : false;
        }
        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text);
            return vr;
        }
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            if (validarCampoVacio() && validacionDatos.validarTexboxRange(txtCodigo, 9))
            {
                objMarca.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                objMarca.Pk_marca = pkMarca;
                objMarca.MarcCodigo = txtCodigo.Text;
                objMarca.MarcNombre = txtNombre.Text;
                objMarca.MarcEstado = (chkEstado.Checked) ? 1 : 0;

                objMarca.GuardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                frmMessageBox box = new frmMessageBox();
                RadTextBox[] text = { txtNombre, txtCodigo };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }
                if (txtNombre.Text == "" && txtCodigo.Text == "")
                    box.MessageBox("Aviso", "Todo los campos es importante", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarCampoVacioTxt(txtNombre))
                    box.MessageBox("Aviso", "El campo marca es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtCodigo, 9))
                    box.MessageBox("Aviso", "El campo codigo debe tener no menos de 9 ni mas de 15 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                box.ShowDialog();
            }                     

        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
            validacionDatos.validarTexboxRange(txtCodigo, 9);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }
    }
}
