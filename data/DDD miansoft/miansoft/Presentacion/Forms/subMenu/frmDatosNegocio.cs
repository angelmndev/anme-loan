using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Dominio.Models;
using Presentacion.Forms.frmModify;
using Presentacion.Forms.frmNew;
using Presentacion.MyLibrary;
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
    public partial class frmDatosNegocio : Form
    {
        private NegocioModel negocioModel = new NegocioModel();
        private SedeModel sedeModel = new SedeModel();
        private UsuarioModel usuarioModel = new UsuarioModel();
        private int pkNegocio { get; set; }
        private int pkSede { get; set; }
        private string sedeDireccion { get; set; }
        public frmDatosNegocio()
        {
            InitializeComponent();
        }

        private void listar()
        {
            foreach(NegocioModel item in negocioModel.GetAll())
            {
                pkNegocio = item.pk_negocio;
                txtNombreComercial.Text = item.negoNombreComercial;
                txtNombreFiscal.Text = item.negoNombreFiscal;
                txtNif.Text = item.negoNif;
                txtPais.Text = item.negoPais;
                txtProvincia.Text = item.negoProvincia;
                txtCodigoPostal.Text = item.negoCodigoPostal;
                txtEmail.Text = item.negoEmail;
                txtWeb.Text = item.negoWeb;
            }
        }
        private void btNuevo_Click(object sender, EventArgs e)
        {
            if(btNuevo.ButtonText == "NUEVO")
            {
                frmNuevoNegocio nuevoNegocio = new frmNuevoNegocio();
                DialogResult result = nuevoNegocio.ShowDialog();
                if (result == DialogResult.OK)
                {
                    comprobarDatosExistente();
                    listar();
                }
            }
            else
            {
                List<object> listaNegocio = new List<object>();
                listaNegocio.Add(pkNegocio);
                listaNegocio.Add(txtNombreComercial.Text);
                listaNegocio.Add(txtNombreFiscal.Text);
                listaNegocio.Add(txtEmail.Text);
                listaNegocio.Add(txtWeb.Text);
                listaNegocio.Add(txtPais.Text);
                listaNegocio.Add(txtProvincia.Text);
                listaNegocio.Add(txtNif.Text);
                listaNegocio.Add(txtCodigoPostal.Text);

                frmModificarNegocio modificarNegocio = new frmModificarNegocio();
                modificarNegocio.DatosNegocio(listaNegocio);
                DialogResult resul = modificarNegocio.ShowDialog();
                if(resul == DialogResult.OK)
                {
                    comprobarDatosExistente();
                    listar();
                }
            }     

        }

        private void listarSede()
        {
            gridSede.DataSource = sedeModel.listarSede();
            GridColumn sede = dgSede.Columns["sedeProvincia"];
            sede.GroupIndex = 0;
        }

        private void estiloDG()
        {
            dgSede.Columns["pk_sede"].Visible = false;
            dgSede.Columns["sedeProvincia"].Caption = "SEDE";
            dgSede.Columns["sedeDistrito"].Caption = "SEDE DISTRITO";
            dgSede.Columns["sedeDireccion"].Visible = false;
            dgSede.Columns["sedeTelefono"].Visible = false;
            dgSede.Columns["sedeCodigoPostal"].Visible = false;
            dgSede.Columns["sedeEstado"].Visible = false;
        }

        //Se comprueba si hay datos en la db para poder agregar o modificar
        private void comprobarDatosExistente()
        {
            if (negocioModel.negocioExistente())
            {
                btNuevo.BackgroundColor = Color.FromArgb(255, 198, 19);
                btNuevo.HoverBackgroundColor = Color.FromArgb(255, 198, 19);
                btNuevo.ClickBackColor = Color.FromArgb(255, 198, 19);
                btNuevo.ButtonText = "MODIFICAR";
            }
            else
            {
                btNuevo.BackgroundColor = Color.FromArgb(16, 222, 57);
                btNuevo.HoverBackgroundColor = Color.FromArgb(16, 222, 57);
                btNuevo.ClickBackColor = Color.FromArgb(16, 222, 57);
                btNuevo.ButtonText = "NUEVO";
            }
        }
        private void frmDatosNegocio_Load(object sender, EventArgs e)
        {

            comprobarDatosExistente();
            style st = new style();
            st.DockStyle(rDock, documentWindow4);
            listar();
            listarSede();
            estiloDG();
        }

        private void dgSede_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(e.FocusedRowHandle >= 0)
            {
                pkSede = Convert.ToInt32(dgSede.GetRowCellValue(dgSede.FocusedRowHandle, "pk_sede"));
                sedeDireccion = dgSede.GetRowCellValue(dgSede.FocusedRowHandle, "sedeDireccion").ToString();
            }
        }

        private void dgSede_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if(pkSede > 0)
                {
                    var sedeData = sedeModel.seleccionaSede(pkSede);
                    foreach (var item in sedeData)
                    {
                        lbProvincia.Text = item.sedeProvincia;
                        lbDistrito.Text = item.sedeDistrito;
                        lbDireccion.Text = item.sedeDireccion;
                        lbTelefono.Text = item.sedeTelefono.ToString();
                        lbCodigoPostal.Text = item.sedeCodigoPostal;
                    }

                    var usuaData = usuarioModel.seleccionarUsuarioXSede(pkSede, sedeDireccion, "Administrador");
                    foreach(var item in usuaData)
                    {
                        lbUsuaNombre.Text = item.usuaNombre;
                        lbUsuaApellido.Text = item.usuaApellido;
                        lbUsuaNDocumento.Text = item.usuaNDocumento.ToString();
                        lbUsuaSexo.Text = item.usuaSexo;
                        lbUsuaCorreo.Text = item.usuaCorreo;
                        lbUsuaTelefono.Text = item.usuaTelefono.ToString();
                        pbFoto.Image = Image.FromFile(@"recursos/Usuario/"+item.usuaFoto);
                    }
                }               
            }
        }

        private void dgSede_ShowingEditor(object sender, CancelEventArgs e)
        {
            if ((sender as GridView).FocusedRowHandle >= 0)
                e.Cancel = true;
        }
    }
}
