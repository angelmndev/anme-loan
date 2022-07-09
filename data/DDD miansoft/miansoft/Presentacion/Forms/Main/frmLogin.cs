using Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Main
{
    public partial class frmLogin : Form
    {
        private LoginModel loginModel = new LoginModel();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private int posX = 0;
        private int posY = 0;
        private void moverFormulario(MouseEventArgs e)
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

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            moverFormulario(e);
        }

        private void pbFondo_MouseMove(object sender, MouseEventArgs e)
        {
            moverFormulario(e);
        }

        private bool validarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtUsuario.Text);
            return vr;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btIngresar_Click(object sender, EventArgs e)
        {
            if (validarCampoVacio())
            {

                if (loginModel.userLogin(txtUsuario.Text, txtPassword.Text))
                {
                    frmBienvevido bienvenido = new frmBienvevido();
                    this.Hide();
                    bienvenido.ShowDialog();
                    this.Close();

                    bienvenido.Show();

                }
                else
                {
                    lbErrorMessage.Text = "    Usuario o contraseña es incorreto";
                    lbErrorMessage.Visible = true;
                }
            }
            else
            {
                lbErrorMessage.Text = "    Ingrese su usuario y contraseña";
                lbErrorMessage.Visible = true;
            }
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
