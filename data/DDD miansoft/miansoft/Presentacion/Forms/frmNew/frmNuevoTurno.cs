using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Windows.Forms;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoTurno : Form 
    {
        private TurnoModel turnoModel = new TurnoModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoTurno()
        {
            InitializeComponent();
            chkEstado.Checked = true;
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtTurno.Text);
            return vr;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(tpHoraEntrada.Value);
            DateTime dt2 = Convert.ToDateTime(tpHoraSalida.Value);
            string HEntrada = dt.ToString("hh:mm tt");
            string HSalida = dt2.ToString("hh:mm tt");

            turnoModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
            turnoModel.TurnNombre = txtTurno.Text;
            turnoModel.TurnHentrada = HEntrada;
            turnoModel.TurnHsalida = HSalida;
            turnoModel.TurnEstado = (chkEstado.Checked) ? 1 : 0;
            if (validacionDatos.validarCampoVacioTxt(txtTurno))
            {
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtTurno_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtTurno);
        }
    }
}
