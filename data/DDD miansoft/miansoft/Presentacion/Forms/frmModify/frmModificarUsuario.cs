using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using System;
using System.Collections;
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

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarUsuario : Form
    {
        private UsuarioModel usuarioModel = new UsuarioModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        private SedeModel sedeModel = new SedeModel();
        private int pkUsuario { get; set; }
        public frmModificarUsuario()
        {
            InitializeComponent();
        }

        public void datosUsuario(List<object> listaUsuario)
        {  

            string privilegios = listaUsuario[6].ToString();
            string[] _privilegios = privilegios.Split(',');
            chkAlmacen.Checked = (_privilegios[0] == "1") ? true : false;
            chkCotizacion.Checked = (_privilegios[1] == "1") ? true : false;
            chkCompras.Checked = (_privilegios[2] == "1") ? true : false;
            chkCaja.Checked = (_privilegios[3] == "1") ? true : false;
            chkVentas.Checked = (_privilegios[4] == "1") ? true : false;
            chkApartado.Checked = (_privilegios[5] == "1") ? true : false;
            chkVentaCredito.Checked = (_privilegios[6] == "1") ? true : false;
            chkInventario.Checked = (_privilegios[7] == "1") ? true : false;
            chkComprobante.Checked = (_privilegios[8] == "1") ? true : false;
            chkUsuario.Checked = (_privilegios[9] == "1") ? true : false;
            chkParametros.Checked = (_privilegios[10] == "1") ? true : false;
            chkConfiguracion.Checked = (_privilegios[11] == "1") ? true : false;

            pkUsuario = (int)listaUsuario[0];
            txtCodigo.Text = listaUsuario[1].ToString();
            txtNombre.Text = listaUsuario[2].ToString();
            txtApellido.Text = listaUsuario[3].ToString();
            txtUsuario.Text = listaUsuario[4].ToString();
            txtPassword.Text = listaUsuario[5].ToString();
            txtConfirmarPassword.Text = listaUsuario[5].ToString();
            
            cbTipoCuenta.SelectedValue = listaUsuario[7].ToString();
            cbTipoDocumento.SelectedValue = listaUsuario[8].ToString();
            txtNDocumento.Text = listaUsuario[9].ToString();
            cbSexo.SelectedValue = listaUsuario[10].ToString();
            txtCorreo.Text = listaUsuario[11].ToString();
            pbFoto.Image = Image.FromFile(@"recursos/Usuario/" + listaUsuario[12].ToString());
            txtTelefono.Text = listaUsuario[13].ToString();
            cbSede.SelectedValue = listaUsuario[14].ToString();
            chkEstado.Checked = ((int)listaUsuario[15]==1)?true:false;

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
        private void actualizarUsuario()
        {
            if (validarCampoVacio() && txtConfirmarPassword.Text == txtPassword.Text && validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo)
             && validacionDatos.validarTexboxRange(txtNDocumento, 8) && validacionDatos.validarTexboxRange(txtTelefono, 9))
            {
                string fileNameCarpeta = @"recursos\\Usuario\\" + namePhoto;

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

                usuarioModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                usuarioModel.pk_usuario = pkUsuario;
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
                usuarioModel.usuaFoto = (namePhoto != "") ? namePhoto : "imgDoont.png";
                usuarioModel.usuaTelefono = Convert.ToInt32(txtTelefono.Text);
                usuarioModel.fk_sede = Convert.ToInt32(cbSede.SelectedValue);
                usuarioModel.usuaEstado = (chkEstado.Checked) ? 1 : 0;

                if (File.Exists(fileNameCarpeta) == false && namePhoto != "")
                {
                    pbFoto.Image.Save(@"recursos/Usuario/" + namePhoto);
                }
                else if (File.Exists(fileNameCarpeta))
                {
                    frmMessageBox fmb = new frmMessageBox();
                    fmb.MessageBox("Aviso", "La foto ya existe por favor \n selecciona otro. Gracias", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    fmb.ShowDialog();
                }
                string mensaje = usuarioModel.GuardarCambios();
                if (mensaje == "")
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
                RadTextBox[] text = { txtCodigo, txtNombre, txtApellido, txtUsuario, txtPassword, txtConfirmarPassword, txtTelefono, txtNDocumento, txtCorreo, txtTelefono };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!validarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo))
                    box.MessageBox("Aviso", "Coloca un correo valido", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (txtConfirmarPassword.Text != txtPassword.Text)
                    box.MessageBox("Aviso", "La contraseña no coincide", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtTelefono, 9))
                    box.MessageBox("Aviso", "El campo telefono debe tener 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtNDocumento, 8))
                    box.MessageBox("Aviso", "El campo telefono debe tener 8 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));

                box.ShowDialog();
            }

        }
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            actualizarUsuario();
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
            foreach (var item in sedeData)
            {
                lbProvincia.Text = item.sedeProvincia + ":" + item.sedeDistrito;
            }
        }
        private void FrmModificarUsuario_Load(object sender, EventArgs e)
        {
            listarSede();
            sedeProVDistrito();
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

        MyLibrary.mnValidation validation = new MyLibrary.mnValidation();
        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.soloNumeros(e);
        }

        private void TxtNDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.soloNumeros(e);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo,9);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtApellido);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtUsuario);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtPassword);
        }

        private void txtConfirmarPassword_TextChanged(object sender, EventArgs e)
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

        private void txtNDocumento_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtNDocumento, 8);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtTelefono, 9);
        }

        private void cbSede_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            sedeProVDistrito();
        }
    }
}
