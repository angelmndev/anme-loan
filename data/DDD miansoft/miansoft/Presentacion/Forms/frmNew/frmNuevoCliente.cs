﻿using System;
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

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoCliente : Form
    {
        private ClienteModel clienteModel = new ClienteModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        public frmNuevoCliente()
        {
            InitializeComponent();
        }
        private bool ValidarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtRucDni.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text) &&
                !string.IsNullOrEmpty(txtDeuda.Text);
            return vr;
        }
        private void insertarCliente()
        {
            frmMessageBox box = new frmMessageBox();
            if (ValidarCampoVacio())
            {
                clienteModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                clienteModel.clieNombre = txtNombre.Text;
                clienteModel.clieRucDni = Convert.ToDouble(txtRucDni.Text);
                clienteModel.clieDireccion = txtDireccion.Text;
                clienteModel.clieEmail = txtCorreo.Text;
                clienteModel.clieDeuda = Convert.ToDouble(txtDeuda.Text);
                clienteModel.clieEstado = (chkEstado.Checked) ? 1 : 0;
                string mensaje = clienteModel.GuardarCambios();
                if(mensaje == "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    box.MessageBox("Aviso", "El cliente se duplica", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                }
                   
            }
            else
            {
                RadTextBox[] text = { txtNombre, txtRucDni, txtDireccion, txtCorreo, txtDeuda };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!ValidarCampoVacio())
                    box.MessageBox("Error...!!", "Todos los campos son importantes", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo))
                    box.MessageBox("Error...!!", "El formato del campo email es incorrecto", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                else if (!validacionDatos.validarTexboxRange(txtRucDni, 8))
                    box.MessageBox("Error...!!", "El campo Dni requiere requiere ni mas ni menos que 8 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.danger));

                box.ShowDialog();
            }

        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            insertarCliente();
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

        mnValidation val = new mnValidation();
        private void txtRucDni_KeyPress(object sender, KeyPressEventArgs e)
        {
           
           val.soloNumeros(e);
        }

        private void txtDeuda_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.IsNumber(".");
        }

        private void txtDeuda_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            e.Cancel = !val.IsNumber(e.NewValue);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtNombre);   
        }

        private void txtRucDni_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtRucDni,8);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDireccion);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.ComprobarFormatoEmail(txtCorreo.Text, txtCorreo);
        }

        private void txtDeuda_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDeuda);
        }

        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
        }
    }
}
