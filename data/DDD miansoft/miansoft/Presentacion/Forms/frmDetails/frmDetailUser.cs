using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmDetailUser : Form
    {
        
        public frmDetailUser()
        {
            InitializeComponent();
        }

        int posX = 0;
        int posY = 0;
        private void frmDetailUser_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
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

        public void datosUsuario(int pk)
        {
            //MUsuario obj = new MUsuario();
            //obj = objUsuario.modificarUsuario(pk);

            //lbUsuario.Text = obj.usuaUsuario;
            //lbNombre.Text = "Nombre: " + obj.usuaNombre + " " + obj.usuaApellido;
            //lbCodigo.Text = "ID: " + obj.usuaCodigo;
            //lbTipoCuenta.Text = "Tipo: " + obj.usuaTipoCuenta;
            //lbCorreo.Text = "E-Mail: " + obj.usuaCorreo;
            //lbDocumento.Text = obj.usuaTipoDocumento + ": " + obj.usuaNDocumento;
            //lbTelefono.Text = "Tel: " + obj.usuaTelefono.ToString();
            //lbSexo.Text = "Sexo: " + obj.usuaSexo;
            //lbEstado.Text = "Estado: " + obj.usuaEstado;
            //pbFoto.Image = Image.FromFile(@"recursos/Usuario/" + obj.usuaFoto);
        }
      

        private void frmDetailUser_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
