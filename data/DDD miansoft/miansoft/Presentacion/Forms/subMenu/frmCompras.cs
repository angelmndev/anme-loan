using DevExpress.XtraSplashScreen;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.DirectX.Common.Direct2D;
using Presentacion.MyLibrary;
using Presentacion.Forms.frmDetails;
using Presentacion.Forms.frmNew;
using Dominio.Models;
using Soporte.Cache;
using DevExpress.XtraEditors.Filtering.Templates;
using Presentacion.Forms.Main;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmCompras : Form
    {
        private ComprobanteModel comprobanteModel = new ComprobanteModel();
        private CompraModel compraModel = new CompraModel();
        private CompraDetalleModel compraDetalleModel = new CompraDetalleModel();
        private ProveedorModel proveedorModel = new ProveedorModel();
        private AlmacenModel almacenModel = new AlmacenModel();

        private DirectionImage directionImage = new DirectionImage();
        
        private style estilo = new style();
        private DataTable table;
        private DataView dvProducto = new DataView();


        public frmCompras()
        {
            InitializeComponent();
            dgProducto.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgProducto.OptionsView.EnableAppearanceEvenRow = true;
            dgCompraDetalle.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgCompraDetalle.OptionsView.EnableAppearanceEvenRow = true;
            createColumnButton();
           
        }

        private void createColumnButton()
        {
            gridCompraDetalle.DataSource = CreateTable();
            GridColumn gridColumn = dgCompraDetalle.Columns.AddVisible("ELIMINAR", string.Empty);
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            buttonEdit.Buttons[0].Kind = ButtonPredefines.Glyph;        
            buttonEdit.Buttons[0].Image = Image.FromFile(@"recursos/img/not.png");          
            buttonEdit.Buttons[0].Appearance.BackColor = Color.White;
            buttonEdit.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearanceDisabled.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearancePressed.BorderColor = Color.White;
            buttonEdit.Buttons[0].Appearance.BorderColor = Color.White;
            buttonEdit.BorderStyle = BorderStyles.UltraFlat;
            buttonEdit.ButtonClick += buttonEdit_ButtonClick;
            gridCompraDetalle.RepositoryItems.Add(buttonEdit);
            gridColumn.ColumnEdit = buttonEdit;
            gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }
        private DataTable CreateTable()
        {
            table = new DataTable();

            string[] campos = { "pkProducto", "CANTIDAD", "DESCRIPCION", "CATEGORIA", "PRESENTACION", "MARCA", "U.MEDIDA", "FV", "PRECIO","IMPORTE" };
            table.Columns.Add(campos[0], typeof(int));
            table.Columns.Add(campos[1], typeof(double));
            table.Columns.Add(campos[2], typeof(string));
            table.Columns.Add(campos[3], typeof(string));
            table.Columns.Add(campos[4], typeof(string));
            table.Columns.Add(campos[5], typeof(string));
            table.Columns.Add(campos[6], typeof(string));
            table.Columns.Add(campos[7], typeof(string));
            table.Columns.Add(campos[8], typeof(double));
            table.Columns.Add(campos[9], typeof(double));
            return table;
        }

        public void DatosCompraDetalle(List<object> listaCode)
        {


            DataRow dr = table.NewRow();
            dr[0] = listaCode[0];
            dr[1] = listaCode[1];
            dr[2] = listaCode[2];
            dr[3] = listaCode[3];
            dr[4] = listaCode[4];
            dr[5] = listaCode[5];
            dr[6] = listaCode[6];
            dr[7] = listaCode[7];
            dr[8] = listaCode[8];
            dr[9] = listaCode[9];
            table.Rows.Add(dr);
            gridCompraDetalle.DataSource = table;
            obtenerSubtotal();
        }

        private void obtenerSubtotal()
        {
            double subtotal = 0;

            for (int i = 0; i < dgCompraDetalle.DataRowCount; i++)
            {
               subtotal += Convert.ToDouble(dgCompraDetalle.GetRowCellValue(i, "IMPORTE").ToString());

            }

            double igv, total;
            igv =(cbDocumento.Text =="FACTURA")? subtotal * 18 / 100:0;
            total = subtotal + igv;
            
            txtSubtotal.Text = subtotal.ToString("C");
            txtIgv.Text = igv.ToString("C");
            txtTotal.Text = total.ToString("C");
        }
        private void CbDocumento_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            obtenerSubtotal();
            numeroDocumento();
        }
        private void btAgregarProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto newProd = new frmNuevoProducto();
            DialogResult rst = newProd.ShowDialog();
            if (rst == DialogResult.OK)
                listarProducto();


        }
        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dgCompraDetalle.DeleteRow(dgCompraDetalle.FocusedRowHandle);
        }  
       
        private void tsCodigoBarra_ValueChanged(object sender, EventArgs e)
        {
            if(tsCodigoBarra.Value == true)
            {
                txtBuscar.Clear();
                txtBuscar.Focus();
              
            }
            else
            {
                txtBuscar.Clear();
                txtBuscar.Focus();
            }
          
            
        }
        private void tsCodigoBarra_ValueChanging(object sender, Telerik.WinControls.UI.ValueChangingEventArgs e)
        {
           
        }
        private void listarDocumento()
        {
            DataView dv = comprobanteModel.listarComprobante();
            cbDocumento.DisplayMember = "comNombre";
            cbDocumento.ValueMember = "pk_comprobante";
            cbDocumento.DataSource = dv;
        }

        private void listarProducto()
        {
            dvProducto = compraModel.listarProductoCompra();
            gridProducto.DataSource = dvProducto;
        }
        private void estiloDG()
        {
         
            dgProducto.Columns["pk_producto"].Visible = false;
            dgProducto.Columns["pk_categoria"].Visible = false;
            dgProducto.Columns["pk_presentacion"].Visible = false;
            dgProducto.Columns["pk_unidadMedida"].Visible = false;
            dgProducto.Columns["fk_categoria"].Visible = false;
            dgProducto.Columns["fk_presentacion"].Visible = false;
            dgProducto.Columns["fk_unidadMedida"].Visible = false;
            dgProducto.Columns["fk_marca"].Visible = false;
            dgProducto.Columns["pk_marca"].Visible = false;
            dgProducto.Columns["prodFoto"].Visible = false;
            dgProducto.Columns["prodDescripcion"].Caption = "DESCRIPCION";
            dgProducto.Columns["prodPrecioUnitario"].Visible = false;
            dgProducto.Columns["cateNombre"].Caption = "CATEGORIA";
            dgProducto.Columns["preseNombre"].Caption = "PRESENTACION";
            dgProducto.Columns["unmeNombre"].Caption = "UNIDAD-MEDIDA";
            dgProducto.Columns["prodCodigo"].Visible = false;
            dgProducto.Columns["prodStkMin"].Visible = false;
            dgProducto.Columns["prodStkMax"].Visible = false;
            dgProducto.Columns["prodEstado"].Visible = false;
            dgProducto.Columns["cateEstado"].Visible = false;
            dgProducto.Columns["preseEstado"].Visible = false;
            dgProducto.Columns["marcEstado"].Visible = false;
            dgProducto.Columns["unmeEstado"].Visible = false;
            dgProducto.Columns["marcNombre"].Caption = "MARCA";
            dgProducto.Columns["marcCodigo"].Visible = false;
            dgProducto.Columns["preseCodigo"].Visible = false;
            dgProducto.Columns["cateCodigo"].Visible = false;

            dgCompraDetalle.Columns["pkProducto"].Visible = false;
            dgCompraDetalle.Columns["CANTIDAD"].Width = 50;
            dgCompraDetalle.Columns["PRECIO"].Width = 50;
           
            dgCompraDetalle.Columns["IMPORTE"].Width = 50;
            dgCompraDetalle.Columns["ELIMINAR"].Width = 50;
            dgCompraDetalle.Columns["PRECIO"].DisplayFormat.FormatType = FormatType.Numeric;
            dgCompraDetalle.Columns["PRECIO"].DisplayFormat.FormatString = "c2";
            dgCompraDetalle.Columns["IMPORTE"].DisplayFormat.FormatType = FormatType.Numeric;
            dgCompraDetalle.Columns["IMPORTE"].DisplayFormat.FormatString = "c2";

        }
        private void numeroDocumento()
        {
            int pkCom = Convert.ToInt32(cbDocumento.SelectedValue);
            IEnumerable<ComprobanteModel> listaComprobante = comprobanteModel.seleccionarComprobante(pkCom);
            foreach(var item in listaComprobante)
            {
                txtNumero.Text = "0000" + item.comCorrelativo.ToString();
            }
            
        }

        
        private void FrmCompras_Load(object sender, EventArgs e)
        {
            dtFechaCompra.Value = DateTime.Now;
            listarProducto();
            listarDocumento();
            estiloDG();
            numeroDocumento();
            tsCodigoBarra.Value = false;
            txtBuscar.Text = "Buscar producto";
            txtRuc.Focus();
            SpindEdit();
        }

        public void prueba(string prueba)
        {
            txtSubtotal.Text = prueba;
        }

        private void dgProducto_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
            estilo.rowStyle(sender, e);
        }

        private void dgProducto_ShowingEditor(object sender, CancelEventArgs e)
        {
            if ((sender as GridView).FocusedRowHandle >= 0)
                e.Cancel = true;
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar producto")
                txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                txtBuscar.Text = "Buscar producto";
        }


        private void dgProducto_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {

                int pkProducto = Convert.ToInt32(dgProducto.GetRowCellValue(dgProducto.FocusedRowHandle, "pk_producto").ToString());
                frmRealizarCompra rc = new frmRealizarCompra();
                AddOwnedForm(rc);
                rc.datosProducto(pkProducto);
                rc.ShowDialog();
            }

        }

        private void dgCompraDetalle_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
            if (e.Column.FieldName == "ELIMINAR")
                e.Appearance.BackColor = Color.White;           
        }

        private void dgCompraDetalle_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "CANTIDAD")
                e.Cancel = false;
            else if(view.FocusedColumn.FieldName == "ELIMINAR")
                e.Cancel = false;
            else
                e.Cancel = true;
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tsCodigoBarra.Value == false && txtBuscar.Text != "Buscar producto")
                dvProducto.RowFilter = ("prodDescripcion LIKE '%" + txtBuscar.Text + "%'");

            if (tsCodigoBarra.Value == true && txtBuscar.Text != "Buscar producto")
                dvProducto.RowFilter = ("prodCodigo LIKE '%" + txtBuscar.Text + "%'");        
           
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            frmSeleccionaProveedor prov = new frmSeleccionaProveedor();
            AddOwnedForm(prov);
            prov.ShowDialog();
        }

        public void datosProveedor(int pk_proveedor ,double ruc,string proveedor,string direccion)
        {
            pkProveedor = pk_proveedor;
            txtRuc.Text = ruc.ToString();
            txtProveedor.Text = proveedor;
            txtDireccion.Text = direccion;
        }

        private int pkProveedor;//obtenemos de seleccionar proveedor

        private void TxtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                double ruc = Convert.ToDouble(txtRuc.Text);
                IEnumerable<ProveedorModel> lista = proveedorModel.seleccionarProveedorXRuc(ruc);
                foreach(var item in lista)
                {
                    if(item.provRuc!=0 ||item.provNombre != "")
                    {
                        txtProveedor.Text = item.provNombre;
                        txtDireccion.Text = item.provDireccion;
                    }
                    else
                    {
                        frmSeleccionaProveedor prov = new frmSeleccionaProveedor();
                        AddOwnedForm(prov);
                        prov.ShowDialog();
                    }
                }             

            }
        }

      
        private void insertarDetalleAlmacen()
        {
           
            for (int i = 0; i < dgCompraDetalle.DataRowCount; i++)
            {
                almacenModel.fk_compra = compraModel.ultimoPkCompra();
                almacenModel.fk_producto = Convert.ToInt32(dgCompraDetalle.GetRowCellValue(i, "pkProducto").ToString());
                almacenModel.fk_proveedr = pkProveedor;
                almacenModel.prodFechaVencimiento = dgCompraDetalle.GetRowCellValue(i, "FV").ToString();
                almacenModel.prodCantidad = Convert.ToDouble(dgCompraDetalle.GetRowCellValue(i, "CANTIDAD").ToString());

                almacenModel.insertar();
            }
        }

        private int obtenerPKComprobante()
        {
            int pkComprobante = Convert.ToInt32(cbDocumento.SelectedValue);
            return pkComprobante;
        }

        private void insertarCompra()
        {
            IEnumerable<ComprobanteModel> listaComprobante = comprobanteModel.seleccionarComprobante(obtenerPKComprobante());
            string comCodigo = string.Empty;
            foreach (var item in listaComprobante)
            {
                comCodigo = item.comCodigo;
            }
            compraModel.fk_personal = UserCache.pk_usuario;
            compraModel.fk_proveedor = pkProveedor;
            compraModel.compDocuCodigo = comCodigo;
            compraModel.compDocuNombre = cbDocumento.Text;
            compraModel.compDocuNumero = Convert.ToInt32(txtNumero.Text);
            compraModel.compFechaCompra = dtFechaCompra.Text;
            compraModel.compEstado = 1;
            compraModel.insertar();
        }

        private void insertarCompraDetalle()
        {
            
            for (int i = 0; i < dgCompraDetalle.DataRowCount; i++)
            {
                compraDetalleModel.fk_compra = compraModel.ultimoPkCompra();
                compraDetalleModel.fk_producto = Convert.ToInt32(dgCompraDetalle.GetRowCellValue(i, "pkProducto"));
                compraDetalleModel.codeCantidad = Convert.ToDouble(dgCompraDetalle.GetRowCellValue(i, "CANTIDAD"));
                compraDetalleModel.codePrecioCompra = Convert.ToDouble(dgCompraDetalle.GetRowCellValue(i, "PRECIO"));
                compraDetalleModel.codeFechaVencimiento = dgCompraDetalle.GetRowCellValue(i, "FV").ToString();

                compraDetalleModel.insertar();
            }

            /*  string[] campos = { "pkProducto", "CANTIDAD", "DESCRIPCION", "CATEGORIA", "PRESENTACION", "MARCA", "U.MEDIDA", "FV", "PRECIO", "IMPORTE" };*/
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            box.MessageBox("Aviso", "Desea guardar la compra..?", directionImage.nameFileImage(DirectionImage.fileImage.question));
            DialogResult resul = box.ShowDialog();
            if(resul == DialogResult.OK)
            {
                insertarCompra();
                insertarDetalleAlmacen();
                insertarCompraDetalle();
                restablecerVenta();
            }
           
        }
        private void restablecerVenta()
        {
            txtRuc.Clear();
            txtProveedor.Clear();
            txtDireccion.Clear();
            gridCompraDetalle.DataSource = null;
            dgCompraDetalle.Columns.Clear();
            createColumnButton();
            obtenerSubtotal();
            estiloDG();
            SpindEdit();
        }

        RepositoryItemSpinEdit edit;
        private void SpindEdit()//hace que una columna sea de tipo spind edith
        {
            edit = new RepositoryItemSpinEdit();
            gridCompraDetalle.RepositoryItems.Add(edit);
            dgCompraDetalle.Columns["CANTIDAD"].ColumnEdit = edit;

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            restablecerVenta();
        }

        private void dgCompraDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int stockProducto = Convert.ToInt32(dgProducto.GetRowCellValue(dgProducto.FocusedRowHandle, "prodStkMax"));
            //Realiza la operacion de multiplicar para obtener el importe en dgVentaDetalle ↓
            if (e.Column.FieldName == "CANTIDAD" )
            {
                GridView view = sender as GridView;

                double cantidad = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CANTIDAD"]));
                double precio = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["PRECIO"]));
                double subtotal = (cantidad * precio);

                
                if (cantidad > stockProducto)
                {
                    frmMessageBox box = new frmMessageBox();
                    box.MessageBox("Aviso", "La cantidad ingresado supera el stock requerido por favor ingrese un valor no menos del stock", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                    dgCompraDetalle.SetRowCellValue(e.RowHandle, "CANTIDAD", stockProducto);
                }
                else
                {
                    dgCompraDetalle.SetRowCellValue(e.RowHandle, "IMPORTE", subtotal);
                }
                obtenerSubtotal();
            }
        }
    }
}
