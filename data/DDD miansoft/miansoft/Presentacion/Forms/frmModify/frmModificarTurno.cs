using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarTurno : Form
    {
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private TurnoModel turnoModel = new TurnoModel();
        private DirectionImage directionImage = new DirectionImage();
        private int pkTurno { get; set; }
        public frmModificarTurno()
        {
            InitializeComponent();
        }

        public void datosTurno(List<object> listaTurno)
        {
            pkTurno = (int)listaTurno[0];
            txtTurno.Text = listaTurno[1].ToString();
            tpHoraEntrada.Value = Convert.ToDateTime(listaTurno[2]);
            tpHoraSalida.Value = Convert.ToDateTime(listaTurno[3]);           
            chkEstado.Checked = ((int)listaTurno[4] == 1) ? true : false;
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtTurno.Text);
            return vr;
        }

        private void BtActualizar_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(tpHoraEntrada.Value);
            DateTime dt2 = Convert.ToDateTime(tpHoraSalida.Value);
            string HEntrada = dt.ToString("hh:mm tt");
            string HSalida = dt2.ToString("hh:mm tt");

            if (ValidarCampoVacio() && validacionDatos.validarCampoVacioTxt(txtTurno))
            {
                turnoModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                turnoModel.Pk_turno = pkTurno;
                turnoModel.TurnNombre = txtTurno.Text;
                turnoModel.TurnHentrada = HEntrada;
                turnoModel.TurnHsalida = HSalida;
                turnoModel.TurnEstado = (chkEstado.Checked) ? 1 : 0;

                turnoModel.GuardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                frmMessageBox box = new frmMessageBox();
                box.MessageBox("Aviso", "El campo turno es obligatorio", directionImage.nameFileImage(DirectionImage.fileImage.danger));
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

        private void txtTurno_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtTurno);
        }
    }
}
