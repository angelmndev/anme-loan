using BunifuAnimatorNS;
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
using System.Windows.Input;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmInfoUsuario : Form
    {
        public frmInfoUsuario()
        {
            InitializeComponent();
        }

        private void frmInfoUsuario_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(Location);
            Location = new Point(scr.WorkingArea.Right - Width - 80, scr.WorkingArea.Top + 58);

            if (UserCache.usuaFoto != "imgDoont.png" && UserCache.usuaSexo == "Masculino")
                pbFoto.Image = Image.FromFile(@"recuros/Usuario/men.png");
            else if(UserCache.usuaFoto != "imgDoont.png" && UserCache.usuaSexo == "Femenino")
                pbFoto.Image = Image.FromFile(@"recuros/Usuario/woman.png");
            else
            txtUser.Text = UserCache.usuaUsuario;
            txtNomApe.Text = UserCache.usuaNombre + " " + UserCache.usuaApellido;
            txtTipoCuenta.Text = UserCache.usuaTipoCuenta;
            txtTelefono.Text = UserCache.usuaTelefono.ToString();
            txtCorreo.Text = UserCache.usuaCorreo;                          
        }

        private void FrmInfoUsuario_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            

        }

        private void FrmInfoUsuario_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void BtCerrar_Click(object sender, EventArgs e)
        {          
            
            this.Close();
        }

        private void frmInfoUsuario_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
