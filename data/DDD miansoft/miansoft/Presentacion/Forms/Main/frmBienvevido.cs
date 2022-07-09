using Soporte.Cache;
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
    public partial class frmBienvevido : Form
    {
        public frmBienvevido()
        {
            InitializeComponent();
        }

        private int contador = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;          
            contador += 1;
            if(contador == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.05;
            if(this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
                this.Close();
            }
        }

        private void frmBienvevido_Load(object sender, EventArgs e)
        {
            lbUsuario.Text = "Usuario: " + UserCache.usuaNombre + " " + UserCache.usuaApellido;
            lbPrivilegios.Text = "Privilegios: " + UserCache.usuaTipoCuenta;
            wbLoading.StartWaiting();
            this.Opacity = 0;
            timer1.Start();
        }
    }
}
