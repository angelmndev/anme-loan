using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using Presentacion.MyLibrary;
using Telerik.WinControls.UI;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoPersonal : Form
    {
        private PersonalModel personalModel = new PersonalModel();
        private CargoModel cargoModel = new CargoModel();
        private TurnoModel turnoModel = new TurnoModel();
        private DataView dvCargo = new DataView();
        private DataView dvTurno = new DataView();
        private ValidacionDatos validDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoPersonal()
        {
            InitializeComponent();
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

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio() && validDatos.ComprobarFormatoEmail(txtEmail.Text,txtEmail) && validDatos.validarTexboxRange(txtDni,8) && validDatos.validarTexboxRange(txtTelefono, 9))
            {            
                personalModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                personalModel.PersNombre = txtNombre.Text;
                personalModel.PersApellido = txtApellido.Text;
                personalModel.PersDireccion = txtDireccion.Text;
                personalModel.PersDni = (txtDni.Text != "") ? Convert.ToDouble(txtDni.Text) : 0;
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
               
                RadTextBox[] text = {txtNombre, txtApellido,txtDireccion,txtEmail,txtDni,txtTelefono };
                for(int i = 0;i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validDatos.validarCampoVacioTxt(text[i]);                                   
                    }
                }

                if (txtNombre.Text == "" || txtApellido.Text == "" || txtDireccion.Text == "")
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validDatos.ComprobarFormatoEmail(txtEmail.Text, txtEmail))
                    box.MessageBox("Aviso", "El formato del campo email es incorrecto", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validDatos.validarTexboxRange(txtDni, 8))
                    box.MessageBox("Aviso", "El campo Dni requiere requiere ni mas ni menos que 8 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validDatos.validarTexboxRange(txtTelefono, 9))
                    box.MessageBox("Aviso", "El campo Telefono debe tener no menos ni mas de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));

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

        private void listarCargo()
        {

            dvCargo  = cargoModel.listarCargo();
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

        private void frmNuevoPersonal_Load(object sender, EventArgs e)
        {
            listarCargo();
            listarTurno();
            cbSexo.SelectedIndex = 0;
            chkEstado.Checked = true;
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
            validDatos.validarCampoVacioTxt(txtNombre);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validDatos.validarCampoVacioTxt(txtApellido);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validDatos.validarCampoVacioTxt(txtDireccion);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {        
            validDatos.validarCampoVacioTxt(txtEmail);
            validDatos.ComprobarFormatoEmail(txtEmail.Text,txtEmail);
            
        }
      
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            validDatos.validarCampoVacioTxt(txtDni);
            validDatos.validarTexboxRange(txtDni, 8);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validDatos.validarCampoVacioTxt(txtTelefono);
            validDatos.validarTexboxRange(txtTelefono, 9);
          
        }

        private void cbCargo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }
    }
}
