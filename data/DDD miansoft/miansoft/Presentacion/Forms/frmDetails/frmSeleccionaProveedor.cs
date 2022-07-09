using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.MyLibrary;
using Presentacion.Forms.subMenu;
using Presentacion.Forms.Main;
using Presentacion.Forms.frmNew;
using Dominio.Models;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmSeleccionaProveedor : Form
    {
        private ProveedorModel proveedorModel = new ProveedorModel();
        private style estilo = new style();

        private int pkProv { get; set; }
        private DataView dvProveedor = new DataView();
        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmSeleccionaProveedor()
        {
            InitializeComponent();
            dgProveedor.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgProveedor.OptionsView.EnableAppearanceEvenRow = true;
            listarProveedor();
            createColumnButton();
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
            if (pkProv > 0)
            {
                int estado = Convert.ToInt32(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "provEstado").ToString());
                int NEstado = (estado == 1) ? 0 : 1;
                proveedorModel.ActualizarEstado(pkProv, NEstado, "proveedor");
            }
        }

        private void createColumnButton()
        {
            
            GridColumn gridColumn = dgProveedor.Columns.AddVisible("SELECCIONAR", string.Empty);
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            buttonEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
            buttonEdit.Buttons[0].Image = Image.FromFile(@"recursos/img/seleccionar.png");
            buttonEdit.Buttons[0].Appearance.BackColor = Color.White;
            buttonEdit.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearanceDisabled.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearancePressed.BorderColor = Color.White;
            buttonEdit.Buttons[0].Appearance.BorderColor = Color.White;
            buttonEdit.BorderStyle = BorderStyles.UltraFlat;
            buttonEdit.ButtonClick += buttonEdit_ButtonClick;
            gridProveedor.RepositoryItems.Add(buttonEdit);
            gridColumn.ColumnEdit = buttonEdit;
            gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }

        private void buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmCompras compras = Owner as frmCompras;
            int pk_producto = Convert.ToInt32(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "pk_proveedor"));
            double ruc = Convert.ToDouble(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "provRuc").ToString());
            string proveedor = dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "provNombre").ToString();
            string direccion = dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "provDireccion").ToString();

            compras.datosProveedor(pk_producto,ruc, proveedor, direccion);
            this.Close();
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
            dgProveedor.Columns["SELECCIONAR"].Width = 50;
        }
        private void listarProveedor()
        {
            dvProveedor = proveedorModel.listar();
            gridProveedor.DataSource = dvProveedor;
        }
        private void FrmSeleccionaProveedor_Load(object sender, EventArgs e)
        {
            style estilo = new style();
            estilo.DockStyle(rDock, documentWindow4);        
            estiloDG();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void nuevo()
        {
            frmNuevoProveedor newProv = new frmNuevoProveedor();
            DialogResult result = newProv.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarProveedor();
          
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }

        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void DgProveedor_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            estilo.rowStyle(sender, e);

            if (e.Column.FieldName == "SELECCIONAR")
                e.Appearance.BackColor = Color.White;
        }

        private void DgProveedor_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "SELECCIONAR")
                e.Cancel = false;
            else if (view.FocusedColumn.FieldName == "provEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        int posX = 0;
        int posY = 0;
        private void PnHeader_MouseMove(object sender, MouseEventArgs e)
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

        private void TxtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            dvProveedor.RowFilter = "provNombre LIKE '%" + txtBuscarNombre.Text + "%'";
        }

        private void TxtBuscarRuc_TextChanged(object sender, EventArgs e)
        {
            dvProveedor.RowFilter = ("Convert(provRuc, 'System.String') LIKE '" + txtBuscarRuc.Text + "%'");
        }

        private void dgProveedor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkProv = Convert.ToInt32(dgProveedor.GetRowCellValue(dgProveedor.FocusedRowHandle, "pk_proveedor").ToString());

                //Point p = this.Location;
                //p.Offset(this.Width / 2, this.Height / 2);
                //radialMenu1.ShowPopup(p);
            }
            else
            {
                pkProv = 0;
            }
        }
    }
}
