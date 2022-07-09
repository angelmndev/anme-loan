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

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoUnidadMedida : Form
    {
        private UnidadMedidaModel unidadMedidaModel = new UnidadMedidaModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoUnidadMedida()
        {
            InitializeComponent();
            chkEstado.Checked = true;
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text);
            return vr;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            
            if (ValidarCampoVacio())
            {
                unidadMedidaModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                unidadMedidaModel.unmeNombre = txtNombre.Text;
                unidadMedidaModel.unmeEstado = (chkEstado.Checked) ? 1 : 0;

                string mensaje = unidadMedidaModel.GuardarCambios();
                if(mensaje == "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    frmMessageBox box = new frmMessageBox();
                    box.MessageBox("Error al guardar", mensaje, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                }
              
            }
            else
            {
                validacionDatos.validarCampoVacioTxt(txtNombre);
                frmMessageBox box = new frmMessageBox();
                if(!ValidarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                
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
    }
}
