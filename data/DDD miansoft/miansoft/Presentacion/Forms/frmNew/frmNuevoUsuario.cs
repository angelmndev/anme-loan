using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoUsuario : Form
    {
        private UsuarioModel usuarioModel = new UsuarioModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        private SedeModel sedeModel = new SedeModel();
        public frmNuevoUsuario()
        {
            InitializeComponent();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insertarUsuario()
        {
            
            if (validarCampoVacio() && txtConfirmarPassword.Text == txtPassword.Text && validacionDatos.ComprobarFormatoEmail(txtCorreo.Text,txtCorreo) 
                && validacionDatos.validarTexboxRange(txtNDocumento,8) && validacionDatos.validarTexboxRange(txtTelefono,9))
            {
                string almacen = (chkAlmacen.Checked) ? "1" : "0";
                string cotizacion = (chkCotizacion.Checked) ? "1" : "0";
                string compras = (chkCompras.Checked) ? "1" : "0";
                string caja = (chkCaja.Checked) ? "1" : "0";
                string ventas = (chkVentas.Checked) ? "1" : "0";
                string apartado = (chkApartado.Checked) ? "1" : "0";
                string ventasCredito = (chkVentaCredito.Checked) ? "1" : "0";
                string inventario = (chkInventario.Checked) ? "1" : "0";
                string comprobante = (chkComprobante.Checked) ? "1" : "0";
                string usuario = (chkUsuario.Checked) ? "1" : "0";
                string parametros = (chkParametros.Checked) ? "1" : "0";
                string configuracion = (chkConfiguracion.Checked) ? "1" : "0";

                usuarioModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;

                usuarioModel.usuaCodigo = txtCodigo.Text;
                usuarioModel.usuaNombre = txtNombre.Text;
                usuarioModel.usuaApellido = txtApellido.Text;
                usuarioModel.usuaUsuario = txtUsuario.Text;
                usuarioModel.usuaPassword = txtPassword.Text;
                usuarioModel.usuaPrivilegios = almacen + "," + cotizacion + "," + compras + "," + caja + "," + ventas + "," + apartado + "," + ventasCredito + "," + inventario + "," + comprobante + "," + usuario + "," + parametros + "," + configuracion;
                usuarioModel.usuaTipoCuenta = cbTipoCuenta.Text;
                usuarioModel.usuaTipoDocumento = cbTipoDocumento.Text;
                usuarioModel.usuaNDocumento = Convert.ToDouble(txtNDocumento.Text);
                usuarioModel.usuaSexo = cbSexo.Text;
                usuarioModel.usuaCorreo = txtCorreo.Text;
                usuarioModel.usuaFoto = (namePhoto=="")? "imgDoont.png":namePhoto;
                usuarioModel.usuaTelefono = Convert.ToInt32(txtTelefono.Text);
                usuarioModel.fk_sede = Convert.ToInt32(cbSede.SelectedValue);
                usuarioModel.usuaEstado = (chkEstado.Checked) ? 1 : 0;
                if(namePhoto!="")
                    pbFoto.Image.Save(@"recursos/Usuario/" + namePhoto);
                string mensaje = usuarioModel.GuardarCambios();
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
                frmMessageBox box = new frmMessageBox();
                RadTextBox[] text = { txtCodigo,txtNombre, txtApellido, txtUsuario, txtPassword,txtConfirmarPassword, txtTelefono,txtNDocumento,txtCorreo,txtTelefono};
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!validarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if(!validacionDatos.ComprobarFormatoEmail(txtCorreo.Text,txtCorreo))
                    box.MessageBox("Aviso", "Coloca un correo valido", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if(txtConfirmarPassword.Text != txtPassword.Text)
                    box.MessageBox("Aviso", "La contraseña no coincide", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if(!validacionDatos.validarTexboxRange(txtTelefono,9))
                    box.MessageBox("Aviso", "El campo telefono debe tener 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if(!validacionDatos.validarTexboxRange(txtNDocumento,8))
                    box.MessageBox("Aviso", "El campo telefono debe tener 8 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));

                box.ShowDialog();
            }
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            insertarUsuario();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        string namePhoto = "";
        private void PbFoto_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog seleccionar = new OpenFileDialog();
            seleccionar.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            DialogResult resultado = seleccionar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(seleccionar.FileName);
                FileInfo info = new FileInfo(seleccionar.FileName);
                namePhoto = info.Name;
            }
        }

        private void listarSede()
        {
            cbSede.DisplayMember = "sedeDireccion";
            cbSede.ValueMember = "pk_sede";
            cbSede.DataSource = sedeModel.listarSede();
        }

        private void sedeProVDistrito()
        {
            int pkSede = Convert.ToInt32(cbSede.SelectedValue);
            var sedeData = sedeModel.seleccionaSede(pkSede);
            foreach(var item in sedeData)
            {
                lbProvincia.Text = item.sedeProvincia + ":" + item.sedeDistrito;
            }
        }
        private void FrmNuevoUsuario_Load(object sender, EventArgs e)
        {
            listarSede();
            sedeProVDistrito();
            cbSexo.SelectedIndex = 0;
            cbTipoCuenta.SelectedIndex = 0;
            cbTipoDocumento.SelectedIndex = 0;
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private bool validarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) &&
                !string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text) &&
                !string.IsNullOrEmpty(txtConfirmarPassword.Text) &&
                !string.IsNullOrEmpty(txtNDocumento.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text) &&
                cbSede.Text != "Selecciona" &&
                cbTipoCuenta.Text != "Selecciona" &&
                cbSexo.Text != "Selecciona" &&
                cbTipoDocumento.Text != "Selecciona";
           return vr;
        }
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo,9);
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtApellido);
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtUsuario);
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtPassword);
        }

        private void TxtConfirmarPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtConfirmarPassword.Text != txtPassword.Text)
            {
                validacionDatos.BorderColor(false, txtConfirmarPassword);
            }
            else
            {
                validacionDatos.BorderColor(true, txtConfirmarPassword);
            }
        }

        private void TxtNDocumento_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtNDocumento, 8);
        }

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtTelefono, 9);
        }

        private void TxtCorreo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo);
        }

        private void TxtNDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void cbSede_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            sedeProVDistrito();
        }
    }
}
