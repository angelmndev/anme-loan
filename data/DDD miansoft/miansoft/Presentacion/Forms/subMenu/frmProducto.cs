using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Collections.Generic;
using Dominio.Models;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using Presentacion.Forms.frmModify;
using Presentacion.MyLibrary;

namespace Presentacion.Forms.subMenu
{
    public partial class frmProducto : Form
    {
        private CategoriaModel categoriaModel = new CategoriaModel();
        private MarcaModel marcaModel = new MarcaModel();
        private PresentacionModel presentacionModel = new PresentacionModel();
        private ProductoModel productoModel = new ProductoModel();
        private DirectionImage directionImage = new DirectionImage();
        private DataView dvProd = new DataView();

        int pkProducto = 0;
        string nomProducto = "";

        Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmProducto()
        {
            InitializeComponent();
            cmEliminar.Click += cmEliminar_Click;
            cmModificar.Click += cmModificar_Click;
            cmDetalle.Click += cmDetalle_Click;
            cmGenerarCodigo.Click += cmGenerarCodigo_Click;

            gridProductos.DataSource = productoModel.listar();
            dgProductos.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgProductos.OptionsView.EnableAppearanceEvenRow = true;
            dgProductos.OptionsSelection.EnableAppearanceFocusedRow = false;

            addToolBox();

        }

        private void listarCombos()
        {
            IEnumerable<CategoriaModel> listaCate = categoriaModel.GetAll();
            cbCategoria.Items.Add("Selecciona");
            foreach (var items in listaCate)
            {
                cbCategoria.Items.Add(items.CateNombre);
            }

            List<PresentacionModel> listaPrese = presentacionModel.GetAll();
            cbPresentacion.Items.Add("Selecciona");
            foreach (var items in listaPrese)
            {
                cbPresentacion.Items.Add(items.preseNombre);
            }
        }

        private void addToolBox()
        {
            RepositoryItemCheckEdit checkEdit = gridProductos.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            checkEdit.PictureChecked = activo;
            checkEdit.PictureUnchecked = inactivo;
            checkEdit.ValueChecked = 1;
            checkEdit.ValueUnchecked = 0;
            checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgProductos.Columns["prodEstado"].ColumnEdit = checkEdit;
            checkEdit.CheckedChanged += checkEdit_CheckedChanged;
        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {

            if (pkProducto != 0)
            {
                int std = Convert.ToInt32(dgProductos.GetRowCellValue(dgProductos.FocusedRowHandle, "prodEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
              
            }

        }

        private void estiloDG()
        {

            dgProductos.Columns["pk_producto"].Visible = false;
            dgProductos.Columns["pk_categoria"].Visible = false;
            dgProductos.Columns["pk_presentacion"].Visible = false;
            dgProductos.Columns["pk_unidadMedida"].Visible = false;
            dgProductos.Columns["fk_categoria"].Visible = false;
            dgProductos.Columns["fk_presentacion"].Visible = false;
            dgProductos.Columns["fk_unidadMedida"].Visible = false;
            dgProductos.Columns["fk_marca"].Visible = false;
            dgProductos.Columns["pk_marca"].Visible = false;
            dgProductos.Columns["prodFoto"].Visible = false;
            dgProductos.Columns["marcEstado"].Visible = false;
            dgProductos.Columns["preseEstado"].Visible = false;
            dgProductos.Columns["unmeEstado"].Visible = false;
            dgProductos.Columns["cateEstado"].Visible = false;
            dgProductos.Columns["prodDescripcion"].Caption = "DESCRIPCION";
            dgProductos.Columns["prodPrecioUnitario"].Caption = "PRECIO-UNITARIO";
            dgProductos.Columns["cateNombre"].Caption = "CATEGORIA";
            dgProductos.Columns["preseNombre"].Caption = "PRESENTACION";
            dgProductos.Columns["unmeNombre"].Caption = "UNIDAD-MEDIDA";
            dgProductos.Columns["prodCodigo"].Caption = "CODIGO";
            dgProductos.Columns["prodStkMin"].Caption = "STOCK MIN";
            dgProductos.Columns["prodStkMax"].Caption = "STOCK MAX";
            dgProductos.Columns["prodEstado"].Caption = "ESTADO";
            dgProductos.Columns["marcNombre"].Caption = "MARCA";
            dgProductos.Columns["marcCodigo"].Visible = false;
            dgProductos.Columns["preseCodigo"].Visible = false;
            dgProductos.Columns["cateCodigo"].Visible = false;

            dgProductos.Columns["prodPrecioUnitario"].DisplayFormat.FormatType = FormatType.Numeric;
            dgProductos.Columns["prodPrecioUnitario"].DisplayFormat.FormatString = "c2";

            dgProductos.Columns["prodEstado"].Width = 60;
        }

        private void listarProducto()
        {
            gridProductos.DataSource = productoModel.listar(); 
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            listarCombos();
            cbEstado.SelectedIndex = 0;

            estiloDG();
            ControlNavigator navigator = gridProductos.EmbeddedNavigator;
            navigator.Buttons.BeginUpdate();
            try
            {
                navigator.Buttons.Append.Visible = false;
                navigator.Buttons.Remove.Visible = false;
            }
            finally
            {
                navigator.Buttons.EndUpdate();
            }
        }


        private void DgProductos_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            style st = new style();
            st.rowStyle(sender, e);
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "prodPrecioUnitario")
                {
                    int cantidad = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "prodPrecioUnitario"));
                    if (cantidad <= 10)
                        e.Appearance.BackColor = Color.FromArgb(255, 25, 64);
                    else if (cantidad <= 50 && cantidad > 10)
                        e.Appearance.BackColor = Color.FromArgb(243, 156, 18);
                    else if (cantidad > 50)
                        e.Appearance.BackColor = Color.FromArgb(46, 204, 113);
                }

            }

        }

        private void btNuevo_Click_1(object sender, EventArgs e)
        {
            frmNuevoProducto newProd = new frmNuevoProducto();
            DialogResult result = newProd.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarProducto();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }

        }

        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);

        }

        private void eliminar()
        {
            if (pkProducto != 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomProducto, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    productoModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    productoModel.pk_producto = pkProducto;
                    productoModel.guardarCambios();
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarProducto();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            
        }

        private void dgProductos_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            
        }

        private void dgProductos_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkProducto = Convert.ToInt32(dgProductos.GetRowCellValue(dgProductos.FocusedRowHandle, "pk_producto").ToString());
                nomProducto = dgProductos.GetRowCellValue(dgProductos.FocusedRowHandle, "prodDescripcion").ToString();

            }
            else
            {
                pkProducto = 0;
            }

        }

        private void modificar()
        {
            if (pkProducto > 0)
            {
                frmModificarProducto modi = new frmModificarProducto();
                modi.modificarProducto(pkProducto);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarProducto();
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

        private void dgProductos_RowClick(object sender, RowClickEventArgs e)
        {
            var args = e as MouseEventArgs;
            if (args.Button == MouseButtons.Right)
            {
                radContextMenu1.Show(gridProductos, args.Location);

            }
        }


        private void cmEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void cmModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }
        private void cmDetalle_Click(object sender, EventArgs e)
        {
            
        }

        private void cmGenerarCodigo_Click(object sender,EventArgs e)
        {
            //frmGenerarCodigo gc = new frmGenerarCodigo();
            //gc.datosProducto(pkProducto);
            //gc.ShowDialog();
        }

        private void dgProductos_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "prodEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

     
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            dvProd.RowFilter = "prodCodigo LIKE '" + txtCodigo.Text + "%'";
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            dvProd.RowFilter = "prodDescripcion LIKE '%" + txtDescripcion.Text + "%'";
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvProd.RowFilter = ("Convert(prodEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else
            {
                listarProducto();
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbCategoria.Text != "Selecciona")
            {
                dvProd.RowFilter = ("cateNombre LIKE '%" + cbCategoria.Text + "%'");
            }
            else
            {
                listarProducto();
            }
        }

        private void cbPresentacion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbPresentacion.Text != "Selecciona")
            {
                dvProd.RowFilter = ("preseNombre LIKE '%" + cbPresentacion.Text + "%'");
            }
            else
            {
                listarProducto();
            }
        }

        private void cbCategoria_Enter(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cbEstado.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }

        private void cbPresentacion_Enter(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cbCategoria.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cbEstado.SelectedIndex = 0;
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }
    }
}
