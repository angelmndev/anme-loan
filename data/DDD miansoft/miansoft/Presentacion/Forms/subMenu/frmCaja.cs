using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.subMenu
{
    public partial class frmCaja : Form
    {
        public frmCaja()
        {
            InitializeComponent();
            miCerrarCaja.Click += miCerrarCaja_Click;
            miAbrirCaja.Click += miAbrirCaja_Click;
        }

        private void miCerrarCaja_Click(object sender, EventArgs e)
        {
            btEstado.ButtonText = "CERRADO";
            miCerrarCaja.Enabled = false;
            miAbrirCaja.Enabled = true;
            btEstado.BackgroundColor = Color.FromArgb(255, 19, 62);
            btEstado.ClickBackColor = Color.FromArgb(255, 19, 62);
            btEstado.HoverBackgroundColor = Color.FromArgb(255, 19, 62);
        }

        private void miAbrirCaja_Click(object sender, EventArgs e)
        {
            btEstado.ButtonText = "ABIERTO";
            miCerrarCaja.Enabled = true;
            miAbrirCaja.Enabled = false;
            btEstado.BackgroundColor = Color.FromArgb(16, 222, 57);
            btEstado.ClickBackColor = Color.FromArgb(16, 222, 57);
            btEstado.HoverBackgroundColor = Color.FromArgb(16, 222, 57);
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {

        }
    }
}
