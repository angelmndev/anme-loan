using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Dominio.Models;
using Presentacion.Forms.frmModify;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.Main;
using Presentacion.Helps;
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
    public partial class frmProveedor : Form
    {
        private ProveedorModel proveedorModel = new ProveedorModel();
        private DataView dvProveedor = new DataView();
        private style estilo = new style();
        private DirectionImage directionImage = new DirectionImage();
        private int pkProv { get; set; }
        private string nomProv { get; set; }
        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));

        public frmProveedor()
        {
            InitializeComponent();
            dgProveedor.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgProveedor.OptionsView.EnableAppearanceEvenRow = true;
            dgProveedor.OptionsSelection.EnableAppearanceFocusedRow = false;
            listarProveedor();
            addCheckbox();
        }

        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridProveedor.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgProveedor.Columns["provEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if(pkProv > 0)
            {
                int estado = Convert.ToInt32(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "provEstado").ToString());
                int NEstado = (estado == 1) ? 0 : 1;
                proveedorModel.ActualizarEstado(pkProv, NEstado, "proveedor");
            }
        }

        private void estiloDG()
        {
            dgProveedor.Columns["pk_proveedor"].Visible = false;
            dgProveedor.Columns["provNombre"].Caption = "PROVEEDOR";
            dgProveedor.Columns["provDireccion"].Caption = "DIRECCION";
            dgProveedor.Columns["provRuc"].Caption = "RUC";
            dgProveedor.Columns["provEmail"].Caption = "EMAIL";
            dgProveedor.Columns["provGiro"].Caption = "GIRO";
            dgProveedor.Columns["provEstado"].Caption = "ESTADO";
            dgProveedor.Columns["provEstado"].Width = 30;
        }
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            style st = new style();
            st.DockStyle(rDock, documentWindow4);
            estiloDG();
            totalRegistro();
            cbEstado.SelectedIndex = 0;
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgProveedor.DataRowCount.ToString();
        }
        //CRUD
        private void listarProveedor()
        {
            dvProveedor = proveedorModel.listar();
            gridProveedor.DataSource = dvProveedor;
        }
        private void nuevo()
        {
            frmNuevoProveedor newProv = new frmNuevoProveedor();
            DialogResult result = newProv.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarProveedor();
                totalRegistro();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }

        }

        private void ModificarProveedor()
        {
            if (pkProv > 0)
            {
                List<object> listaProveedor = new List<object>();
                for(int i = 0;i < dgProveedor.Columns.Count; i++)
                {
                    listaProveedor.Add(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, dgProveedor.Columns[i]));
                }
                frmModificarProveedor prov = new frmModificarProveedor();
                prov.datosProveedor(listaProveedor);
                DialogResult resultado = prov.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarProveedor();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }
        private void eliminarProveedor()
        {

            if (pkProv > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomProv, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {
                    proveedorModel.eliminar(pkProv);              
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarProveedor();
                    totalRegistro();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }

        //END CRUD ↑

        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarProveedor();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminarProveedor();
        }

        private void dgProveedor_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender, e);
        }

        private void dgProveedor_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "provEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgProveedor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkProv = Convert.ToInt32(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "pk_proveedor").ToString());
                nomProv = dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "provNombre").ToString();

                //Point p = this.Location;
                //p.Offset(this.Width / 2, this.Height / 2);
                //radialMenu1.ShowPopup(p);
            }
            else
            {
                pkProv = 0;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            dvProveedor.RowFilter = "Convert(provRuc, 'System.String') LIKE '" + txtRuc.Text + "%'";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvProveedor.RowFilter = "provNombre LIKE '%" + txtNombre.Text + "%'";
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvProveedor.RowFilter = ("Convert(provEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else
            {
                listarProveedor();
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtRuc.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void txtRuc_Enter(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtRuc.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtRuc.Clear();
        }
    }
}
