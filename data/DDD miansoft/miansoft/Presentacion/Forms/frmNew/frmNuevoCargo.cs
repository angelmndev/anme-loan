using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Windows.Forms;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoCargo : Form
    {
        private CargoModel cargoModel = new CargoModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoCargo()
        {
            InitializeComponent();
            chkEstado.Checked = true;
        }
  
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void btGuardar_Click(object sender, EventArgs e)
        {
            
            cargoModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
            cargoModel.CargNombre = txtCargo.Text;
            cargoModel.CargEstado = (chkEstado.Checked) ? 1 : 0;
            if (validacionDatos.validarCampoVacioTxt(txtCargo))
            {
                cargoModel.GardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                frmMessageBox box = new frmMessageBox();
                box.MessageBox("Aviso", "El campo cargo es importante", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                box.ShowDialog();
            }
          
                
            
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCargo);
        }
    }
}
