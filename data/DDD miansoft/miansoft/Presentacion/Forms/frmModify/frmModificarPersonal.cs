using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using Presentacion.MyLibrary;
using Telerik.WinControls.UI;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarPersonal : Form
    {
        private PersonalModel personalModel = new PersonalModel();
        private TurnoModel turnoModel = new TurnoModel();
        private CargoModel cargoModel = new CargoModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();

        DataView dvCargo = new DataView();
        DataView dvTurno = new DataView();

        private int pkPersonal { get; set; }
        public frmModificarPersonal()
        {
            InitializeComponent();
            listarCargo();
            listarTurno();
        }
        private void listarCargo()
        {
            dvCargo =  cargoModel.listarCargo();
            cbCargo.DisplayMember = "cargNombre";
            cbCargo.ValueMember = "pk_cargo";
            cbCargo.DataSource = dvCargo;
        }
        private void listarTurno()
        {
            dvTurno = turnoModel.listarTurno();
            cbTurno.DisplayMember = "turnNombre";
            cbTurno.ValueMember = "pk_turno";
            cbTurno.DataSource = dvTurno;
        }

        public void datosPersonal(List<object> listaPersonal)
        {      
            personalModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
            pkPersonal = (int)listaPersonal[0];
            txtNombre.Text = listaPersonal[1].ToString();
            txtApellido.Text = listaPersonal[2].ToString();
            txtDireccion.Text = listaPersonal[3].ToString();
            txtDni.Text = listaPersonal[4].ToString();
            cbSexo.SelectedValue = (listaPersonal[5].ToString() == "M") ? "Masculino" : "Femenino";
            dtFechaNac.Text = listaPersonal[6].ToString();
            txtTelefono.Text = listaPersonal[7].ToString();
            txtEmail.Text = listaPersonal[8].ToString();
            cbCargo.SelectedValue = listaPersonal[9];
            cbTurno.SelectedValue = listaPersonal[10];
            chkEstado.Checked = ((int)listaPersonal[11] == 1) ? true : false;

            MessageBox.Show(listaPersonal[9].ToString(), listaPersonal[10].ToString());
        }

        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtDni.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text);
            return vr;
        }
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio() && validacionDatos.ComprobarFormatoEmail(txtEmail.Text, txtEmail) && validacionDatos.validarTexboxRange(txtDni, 8) && validacionDatos.validarTexboxRange(txtTelefono, 9))
            {
                personalModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                personalModel.Pk_personal = pkPersonal;
                personalModel.PersNombre = txtNombre.Text;
                personalModel.PersApellido = txtApellido.Text;
                personalModel.PersDireccion = txtDireccion.Text;
                personalModel.PersDni = Convert.ToDouble(txtDni.Text);
                personalModel.PersSexo = cbSexo.Text;
                personalModel.PersFechaNac = dtFechaNac.Value;
                personalModel.PersTelefono = txtTelefono.Text;
                personalModel.PersEmail = txtEmail.Text;
                personalModel.Fk_cargo = Convert.ToInt32(cbCargo.SelectedValue);
                personalModel.Fk_turno = Convert.ToInt32(cbTurno.SelectedValue);
                personalModel.PersEstado = (chkEstado.Checked) ? 1 : 0;

                personalModel.GuardarCambios();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                frmMessageBox box = new frmMessageBox();

                RadTextBox[] text = { txtNombre, txtApellido, txtDireccion, txtEmail, txtDni, txtTelefono };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (txtNombre.Text == "" || txtApellido.Text == "" || txtDireccion.Text == "")
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.ComprobarFormatoEmail(txtEmail.Text, txtEmail))
                    box.MessageBox("Aviso", "El formato del campo email es incorrecto", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtDni, 8))
                    box.MessageBox("Aviso", "El campo Dni requiere requiere ni mas ni menos que 8 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtTelefono, 9))
                    box.MessageBox("Aviso", "El campo Telefono debe tener no menos ni mas de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));

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

        private void FrmModificarPersonal_Load(object sender, EventArgs e)
        {
            
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

        mnValidation val = new mnValidation();
        private void TxtDni_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
           e.Cancel = !val.IsNumber(e.NewValue);    
        }

        private void TxtTelefono_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
           e.Cancel = !val.IsNumber(e.NewValue);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtApellido);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDireccion);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtEmail);
            validacionDatos.ComprobarFormatoEmail(txtEmail.Text, txtEmail);
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDni);
            validacionDatos.validarTexboxRange(txtDni, 8);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtTelefono);
            validacionDatos.validarTexboxRange(txtTelefono, 9);
        }
    }
}
