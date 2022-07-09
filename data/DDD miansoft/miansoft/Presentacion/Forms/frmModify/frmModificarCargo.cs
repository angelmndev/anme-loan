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

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarCargo : Form
    {
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private CargoModel cargoModel = new CargoModel();
        private DirectionImage directionImage = new DirectionImage();
        private int pkCargo { get; set; }
        public frmModificarCargo()
        {
            InitializeComponent();
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCargo.Text);
            return vr;
        }
        public void datosCargo(List<object> listaCargo)
        {
            pkCargo = Convert.ToInt32(listaCargo[0]);
            txtCargo.Text = listaCargo[1].ToString();
            chkEstado.Checked = ((int)listaCargo[2] == 1) ? true : false;
        }
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio() && validacionDatos.validarCampoVacioTxt(txtCargo))
            {
                cargoModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                cargoModel.Pk_cargo = pkCargo;
                cargoModel.CargNombre = txtCargo.Text;
                cargoModel.CargEstado = (chkEstado.Checked) ? 1 : 0;
                cargoModel.GardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                frmMessageBox box = new frmMessageBox();
                box.MessageBox("Aviso", "El campo cargo es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.question));
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
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCargo);
        }
    }
}
