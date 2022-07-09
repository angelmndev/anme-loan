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
    public partial class frmNuevaMarca : Form
    {
        private MarcaModel objMarca = new MarcaModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevaMarca()
        {
            InitializeComponent();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insertar()
        {
            if (validarCampoVacio() && validacionDatos.validarTexboxRange(txtCodigo, 9))
            {
                objMarca.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                objMarca.MarcCodigo = txtCodigo.Text;
                objMarca.MarcNombre = txtNombre.Text;
                objMarca.MarcEstado = (chkEstado.Checked) ? 1 : 0;

                objMarca.GuardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                frmMessageBox box = new frmMessageBox(); 
                RadTextBox[] text = { txtNombre,txtCodigo};
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }
                if(txtNombre.Text == "" &&txtCodigo.Text == "")
                    box.MessageBox("Aviso", "Todo los campos es importante", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarCampoVacioTxt(txtNombre))
                    box.MessageBox("Aviso", "El campo marca es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtCodigo, 9))
                    box.MessageBox("Aviso", "El campo codigo debe tener no menos de 9 ni mas de 15 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                box.ShowDialog();
            }
           
        } 
        private void BtGuardar_Click(object sender, EventArgs e)
        {
            insertar();
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// ---VALIDAR CAMPO VACIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private bool validarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text);
            return vr;
        }
        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo,9);
        }

        private void FrmNuevaMarca_Load(object sender, EventArgs e)
        {
      
            chkEstado.Checked = true;
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
    }
}
