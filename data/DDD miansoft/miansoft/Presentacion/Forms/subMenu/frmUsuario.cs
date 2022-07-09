using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using Telerik.WinControls.UI.Docking;
using System.Web.UI;
using DevExpress.Skins;
using DevExpress.XtraEditors.Repository;
using Presentacion.MyLibrary;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.frmModify;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmUsuario : Form
    {
        private UsuarioModel usuarioModel = new UsuarioModel();
        private DataView dvClie = new DataView();
        private DirectionImage directionImage = new DirectionImage();

        private int pkUsuario { get; set; }
        private string nomUsuario { get; set; }

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmUsuario()
        {
            InitializeComponent();
            cmEliminar.Click += cmEliminar_Click;
            cmModificar.Click += cmModificar_Click;
            cmDetalle.Click += cmDetalle_Click;

            dgUsuario.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgUsuario.OptionsView.EnableAppearanceEvenRow = true;
            dgUsuario.OptionsSelection.EnableAppearanceFocusedRow = false;

            listarUsuario();
            addCheckbox();
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridUsuario.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgUsuario.Columns["usuaEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
           if(pkUsuario > 0)
            {
                int estado = Convert.ToInt32(dgUsuario.GetRowCellValue(dgUsuario.FocusedRowHandle, "usuaEstado"));
                int NEstado = (estado == 1) ? 0 : 1;
                usuarioModel.ActualizarEstado(pkUsuario, NEstado, "usuario");
            }
        }

        private void listarUsuario()
        {
            dvClie = usuarioModel.listarUsuario();
            gridUsuario.DataSource = dvClie;
        }
       
        private void estiloDG()
        {

            dgUsuario.Columns["pk_usuario"].Visible = false;
            dgUsuario.Columns["usuaCodigo"].Caption = "ID";
            dgUsuario.Columns["usuaNombre"].Visible = false;
            dgUsuario.Columns["usuaApellido"].Visible = false;
            dgUsuario.Columns["usuaUsuario"].Caption = "USUARIO";
            dgUsuario.Columns["usuaPassword"].Visible = false;
            dgUsuario.Columns["usuaPrivilegios"].Visible = false;
            dgUsuario.Columns["usuaEstado"].Caption = "ESTADO";
            dgUsuario.Columns["usuaTipoCuenta"].Caption = "PRIVILEGIOS";
            dgUsuario.Columns["usuaTipoDocumento"].Caption = "TIPO DOCUMENTO";
            dgUsuario.Columns["usuaNDocumento"].Caption = "N° DOCUMENTO";
            dgUsuario.Columns["usuaSexo"].Caption = "SEXO";
            dgUsuario.Columns["usuaCorreo"].Visible = false;
            dgUsuario.Columns["usuaFoto"].Visible = false;
            dgUsuario.Columns["usuaTelefono"].Caption = "TELEFONO";
            dgUsuario.Columns["fk_sede"].Visible = false;
            dgUsuario.Columns["usuaEstado"].Caption = "ESTADO";
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            estiloDG();
            cbCuenta.SelectedIndex = 0;
            cbSexo.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgUsuario.DataRowCount.ToString();
        }
        private void DgUsuario_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //cambiar de color de fila seleccionado
            GridView view = sender as GridView;
            if (view.FocusedRowHandle == e.RowHandle && !view.FocusedColumn.Equals(e.Column))
                e.Appearance.BackColor = Color.FromArgb(133, 146, 158);

            //cambiar el color de la fila filter
            if (e.RowHandle == GridControl.AutoFilterRowHandle)
                e.Appearance.BackColor = Color.White;
            e.Appearance.ForeColor = Color.Black;
        }

        //::ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);

        }
        private void BtNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoUsuario newUser = new frmNuevoUsuario();
            DialogResult result = newUser.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarUsuario();
                totalRegistro();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }
        }

        //MODIFICAR PRODUCTO
        private void modificar()
        {
            if (pkUsuario > 0)
            {
                List<object> listaUsuario = new List<object>();
                for(int i =0; i < dgUsuario.Columns.Count; i++)
                {
                    listaUsuario.Add(dgUsuario.GetRowCellValue(dgUsuario.FocusedRowHandle, dgUsuario.Columns[i]));
                }

                frmModificarUsuario modi = new frmModificarUsuario();
                modi.datosUsuario(listaUsuario);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarUsuario();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }
        private void BtModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        //ELIMINAR
        private void eliminarUsuario()
        {

            if (pkUsuario > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomUsuario, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    usuarioModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    usuarioModel.pk_usuario = pkUsuario;
                    usuarioModel.GuardarCambios();
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarUsuario();
                    totalRegistro();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }
        private void BtEliminar_Click(object sender, EventArgs e)
        {
            eliminarUsuario();
        }

        //CAPTURAR PK Y NOMBRE DEL USUARIO
        private void DgUsuario_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                pkUsuario = Convert.ToInt32(dgUsuario.GetRowCellValue(dgUsuario.FocusedRowHandle, "pk_usuario").ToString());
                nomUsuario = dgUsuario.GetRowCellValue(dgUsuario.FocusedRowHandle, "usuaNombre").ToString();
            }
            else
            {
                pkUsuario = 0;
            }
        }

        private void dgUsuario_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "usuaEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
        }

        
        private void dgUsuario_RowClick(object sender, RowClickEventArgs e)
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                radContextMenu1.Show(gridUsuario, args.Location);
                 
            }
        }

        private void cmEliminar_Click(object sender,EventArgs e)
        {
            eliminarUsuario();
        }
        private void cmModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }
        private void cmDetalle_Click(object sender, EventArgs e)
        {
            //viewDetail.frmDetailUser detailUser = new viewDetail.frmDetailUser();
            //detailUser.datosUsuario(pkUsuario);
            //detailUser.ShowDialog();
        }

        private void DgUsuario_RowStyle(object sender, RowStyleEventArgs e)
        {

            
        }

        private void cbRestablecer()
        {
            cbCuenta.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            cbSexo.SelectedIndex = 0;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //mnValidation validation = new mnValidation();
            //validation.soloNumeros(e);
        }

        private void limpiarCampos()
        {
            txtId.Clear();
            txtDni.Clear();
        }
        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            limpiarCampos();
            if (cbEstado.Text != "Selecciona" || cbSexo.Text != "Selecciona" || cbCuenta.Text != "Selecciona")
            {             
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvClie.RowFilter = ("usuaSexo LIKE '" + cbSexo.Text + "%' and usuaTipoCuenta LIKE'%" + cbCuenta.Text + "%' and Convert(usuaEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else if(txtId.Text == "" || txtDni.Text == "")
            {
                listarUsuario();
            }     
        }

        private void cbCuenta_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            limpiarCampos();

            if (cbEstado.Text != "Selecciona" || cbSexo.Text != "Selecciona" || cbCuenta.Text != "Selecciona")
            {            
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvClie.RowFilter = ("usuaSexo LIKE '" + cbSexo.Text + "%' and usuaTipoCuenta LIKE'%" + cbCuenta.Text + "%' and Convert(usuaEstado, 'System.String') LIKE '" + estado + "%'");

            }
            else if (txtId.Text == "" || txtDni.Text == "")
                listarUsuario();
        }

        private void cbSexo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            limpiarCampos();

            if (cbEstado.Text != "Selecciona" || cbSexo.Text != "Selecciona" || cbCuenta.Text != "Selecciona")
            {            
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvClie.RowFilter = ("usuaSexo LIKE '" + cbSexo.Text + "%' and usuaTipoCuenta LIKE'%" + cbCuenta.Text + "%' and Convert(usuaEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else if (txtId.Text == "" || txtDni.Text == "")
                listarUsuario();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            cbRestablecer();
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            cbRestablecer();
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            cbRestablecer();
            txtId.Clear();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            cbRestablecer();
            limpiarCampos();
            listarUsuario();
        }


        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            dvClie.RowFilter = ("Convert(usuaNDocumento, 'System.String') LIKE '" + txtDni.Text + "%'");
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            dvClie.RowFilter = ("usuaCodigo LIKE '" + txtId.Text + "%'");
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            cbRestablecer();
            txtDni.Clear();
        }
    }
}
