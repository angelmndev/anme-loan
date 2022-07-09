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
    public partial class frmMessageBox : Form
    {
     
        
        public frmMessageBox()
        {
            InitializeComponent();
         
        }

        public void MessageBox(string info,string mensaje, string fileImage)
        {
            lbInformacion.Text = info;
            lbMensaje.Text = mensaje;
            pbEstado.Image = Image.FromFile(fileImage);
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
