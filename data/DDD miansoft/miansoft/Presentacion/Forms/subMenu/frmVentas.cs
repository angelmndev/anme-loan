using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using System.Security.Cryptography;
using System.Globalization;
using Presentacion.MyLibrary;
using Presentacion.Forms.frmDetails;
using Dominio.Models;
using Presentacion.Forms.Main;
using System.Drawing.Printing;
using Dominio.ObjetoValor;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmVentas : Form
    {
        private AlmacenModel almacenModel = new AlmacenModel();
        private ComprobanteModel comprobanteModel = new ComprobanteModel();
        private ClienteModel clienteModel = new ClienteModel();
        private ProductoModel productoModel = new ProductoModel();
        private CategoriaModel categoriaModel = new CategoriaModel();
        private MarcaModel marcaModel = new MarcaModel();
        private PresentacionModel presentacionModel = new PresentacionModel();
        private UnidadMedidaModel unidadMedidaModel = new UnidadMedidaModel();
        private VentaModel ventaModel = new VentaModel();
        private VentaDetalleModel ventaDetalleModel = new VentaDetalleModel();
        private DataTable table;
        private style estilo = new style();
        private DataView dvAlmacen = new DataView();
        private DirectionImage directionImage = new DirectionImage();
        private FormaPagoModel formaPago = new FormaPagoModel();
        private int pk_Cliente { get; set; }
        private int clieEstado { get; set; }
        public frmVentas()
        {
            InitializeComponent();
            dgProducto.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgProducto.OptionsView.EnableAppearanceEvenRow = true;
            dgVentaDetalle.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgVentaDetalle.OptionsView.EnableAppearanceEvenRow = true;
            createColumnButton();
        }
        private void createColumnButton()
        {
            gridVentaDetalle.DataSource = CreateTable();
            GridColumn gridColumn = dgVentaDetalle.Columns.AddVisible("ELIMINAR", string.Empty);
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
            gridVentaDetalle.RepositoryItems.Add(buttonEdit);
            gridColumn.ColumnEdit = buttonEdit;
            gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }
        private DataTable CreateTable()
        {

            table = new DataTable();

            string[] campos = { "pkProducto", "CANTIDAD", "DESCRIPCION", "CATEGORIA", "PRESENTACION", "MARCA", "U.MEDIDA", "DESCUENTO", "PRECIO", "IMPORTE" };
            table.Columns.Add(campos[0], typeof(int));
            table.Columns.Add(campos[1], typeof(double));
            table.Columns.Add(campos[2], typeof(string));
            table.Columns.Add(campos[3], typeof(string));
            table.Columns.Add(campos[4], typeof(string));
            table.Columns.Add(campos[5], typeof(string));
            table.Columns.Add(campos[6], typeof(string));
            table.Columns.Add(campos[7], typeof(double));
            table.Columns.Add(campos[8], typeof(double));
            table.Columns.Add(campos[9], typeof(double));
            return table;
        }

        private void buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            dgVentaDetalle.DeleteRow(dgVentaDetalle.FocusedRowHandle);
        }

        private void listarProducto()
        {
            dvAlmacen = almacenModel.listarAlmacen("venta");
            gridProducto.DataSource = dvAlmacen;
        }

        private void estiloDG()
        {
            dgProducto.Columns["fk_producto"].Visible = false;
            dgProducto.Columns["prodCodigo"].Visible = false;
            dgProducto.Columns["cateNombre"].Visible = false;
            dgProducto.Columns["marcNombre"].Visible = false;
            dgProducto.Columns["prodDescripcion"].Caption = "DESCRIPCION";
            dgProducto.Columns["prodCantidad"].Caption = "STOCK";
            dgProducto.Columns["preseNombre"].Visible = false;
            dgProducto.Columns["unmeNombre"].Visible = false;

            dgProducto.Columns["prodCantidad"].Width = 15;

            dgVentaDetalle.Columns["pkProducto"].Visible = false;
            dgVentaDetalle.Columns["CANTIDAD"].Width = 50;
            dgVentaDetalle.Columns["PRECIO"].Width = 50;

            dgVentaDetalle.Columns["IMPORTE"].Width = 50;
            dgVentaDetalle.Columns["ELIMINAR"].Width = 50;

            dgVentaDetalle.Columns["PRECIO"].DisplayFormat.FormatType = FormatType.Numeric;
            dgVentaDetalle.Columns["PRECIO"].DisplayFormat.FormatString = "c2";
            dgVentaDetalle.Columns["IMPORTE"].DisplayFormat.FormatType = FormatType.Numeric;
            dgVentaDetalle.Columns["IMPORTE"].DisplayFormat.FormatString = "c2";
            dgVentaDetalle.Columns["DESCUENTO"].DisplayFormat.FormatType = FormatType.Numeric;
            dgVentaDetalle.Columns["DESCUENTO"].DisplayFormat.FormatString = "c2";
        }
        private void listarDocumento()
        {
            DataView dv = comprobanteModel.listarComprobante();
            cbDocumento.DisplayMember = "comNombre";
            cbDocumento.ValueMember = "pk_comprobante";
            cbDocumento.DataSource = dv;
        }

        private void listarFormaDePago()
        {
            DataView dv = formaPago.listarFormPago();
            cbFormaPago.DisplayMember = "fopaNombre";
            cbFormaPago.ValueMember = "pk_formaPago";
            cbFormaPago.DataSource = dv;
        }

        private void numeroDocumento()
        {
            int pkCom = Convert.ToInt32(cbDocumento.SelectedValue);
            IEnumerable<ComprobanteModel> listaComprobante = comprobanteModel.seleccionarComprobante(pkCom);
            foreach (var item in listaComprobante)
            {
                txtNumero.Text = "0000" + item.comCorrelativo;
            }

        }

        RepositoryItemSpinEdit edit;
        private void SpindEdit()//hace que una columna sea de tipo spind edith
        {
            edit = new RepositoryItemSpinEdit();
            gridVentaDetalle.RepositoryItems.Add(edit);
            dgVentaDetalle.Columns["CANTIDAD"].ColumnEdit = edit;
            edit.EditValueChanged += edit_EditValueChanged;
        }

        private void edit_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            listarProducto();
            estiloDG();
            CreateTable();
            listarDocumento();
            listarFormaDePago();
            numeroDocumento();
            btEstado.Visible = false;
            lbEstado.Visible = false;
            txtBuscar.Focus();
            SpindEdit();
            dtFechaVenta.Value = DateTime.Now;
        }

        public void DatosVentaDetalle(List<object> listaVede)
        {

            DataRow dr = table.NewRow();
            for (int i = 0; i < listaVede.Count; i++)
            {
                dr[i] = listaVede[i];
            }
            //dr[0] = listaVede[0];
            //dr[1] = listaVede[1];
            //dr[2] = listaVede[2];
            //dr[3] = listaVede[3];
            //dr[4] = listaVede[4];
            //dr[5] = listaVede[5];
            //dr[6] = listaVede[6];
            //dr[7] = listaVede[7];
            //dr[8] = listaVede[8];
            //dr[9] = listaVede[9];
            table.Rows.Add(dr);
            gridVentaDetalle.DataSource = table;
            obtenerSubtotal();
            txtBuscar.SelectAll();
        }

        private void obtenerSubtotal()
        {
            double subtotal = 0;

            for (int i = 0; i < dgVentaDetalle.DataRowCount; i++)
            {
                subtotal += Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, "IMPORTE").ToString());
            }

            double igv, total;
            igv = (cbDocumento.Text == "FACTURA") ? subtotal * 18 / 100 : 0;
            total = subtotal + igv;

            txtSubtotal.Text = subtotal.ToString("C");
            txtIgv.Text = igv.ToString("C");
            txtTotal.Text = total.ToString("C");
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

        private void dgProducto_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                List<object> listaAlmacen = new List<object>();
                for (int i = 0; i < dgProducto.Columns.Count; i++)
                {
                    listaAlmacen.Add(dgProducto.GetRowCellValue(dgProducto.FocusedRowHandle, dgProducto.Columns[i]));
                }

                frmRealizarVenta rv = new frmRealizarVenta();
                AddOwnedForm(rv);
                rv.datosProducto(listaAlmacen);
                rv.ShowDialog();
            }
        }

        private void tsCodigoBarra_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbDocumento_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            numeroDocumento();
            obtenerSubtotal();
        }

        private void obtenerDniCliente()
        {
            double Dni = double.Parse(txtDni.Text);
            IEnumerable<ClienteModel> listaCliente = clienteModel.seleccionarCliente(Dni);
            int PkCliente = 0;
            int ClieEstado = 0;
            string ClieNombre = string.Empty;
            string ClieDireccion = string.Empty;
            double ClieDeuda = 0;
            double ClieDni = 0;
            foreach (var item in listaCliente)
            {
                PkCliente = item.pk_cliente;
                ClieEstado = item.clieEstado;
                ClieNombre = item.clieNombre;
                ClieDireccion = item.clieDireccion;
                ClieDeuda = item.clieDeuda;
                ClieDni = item.clieRucDni;
            }

            if (ClieDni != 0)
            {
                txtCliente.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtDeuda.ReadOnly = true;
                pk_Cliente = PkCliente;
                clieEstado = ClieEstado;
                txtCliente.Text = ClieNombre;
                txtDireccion.Text = ClieDireccion;
                txtDeuda.Text = ClieDeuda.ToString("C");
                btEstado.Visible = true;
                lbEstado.Visible = true;
                if (ClieEstado == 1)
                {
                    btEstado.Image = Image.FromFile(@"recursos/img/check.png");
                }
                else
                {
                    btEstado.Image = Image.FromFile(@"recursos/img/check.png");
                }
            }
            else
            {
                txtCliente.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtDeuda.ReadOnly = false;
                txtCliente.Clear();
                txtDireccion.Clear();
                double deuda = 0;
                txtDeuda.Text = deuda.ToString("C");
                txtCliente.Focus();
            }

        }
        public void datosCliente(int pkCliente, double dni, string nombre, string direccion, double deuda, int estado)
        {
            btEstado.Visible = true;

            pk_Cliente = pkCliente;
            clieEstado = estado;
            txtDni.Text = dni.ToString();
            txtCliente.Text = nombre;
            txtDireccion.Text = direccion;
            txtDeuda.Text = deuda.ToString("C");

            if (estado == 1)
            {
                btEstado.Image = Image.FromFile(@"recursos/img/check.png");
            }
            else
            {
                btEstado.Image = Image.FromFile(@"recursos/img/not.png");
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            frmSeleccionarCliente selectClie = new frmSeleccionarCliente();
            AddOwnedForm(selectClie);
            selectClie.ShowDialog();
        }

        private void txtDni_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            mnValidation val = new mnValidation();
            e.Cancel = !val.IsNumber(e.NewValue);
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            var vr = !string.IsNullOrEmpty(txtDni.Text);

        }

        private void dgVentaDetalle_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "CANTIDAD")
                e.Cancel = false;
            else if (view.FocusedColumn.FieldName == "ELIMINAR")
                e.Cancel = false;
            else if (view.FocusedColumn.FieldName == "DESCUENTO")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgVentaDetalle_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ELIMINAR")
                e.Appearance.BackColor = Color.White;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (tsCodigoBarra.Value == true && txtBuscar.Text != "")//realiza la busqueda cuando es tsCodigoBarra este activo
            {
                dvAlmacen.RowFilter = "prodCodigo LIKE '%" + txtBuscar.Text + "%'";
                string codigo = txtBuscar.Text;

                //:::DATOS DE ALMACEM
                IEnumerable<AlmacenModel> listaAlmacen = almacenModel.seleccionarProductoXCodigo(codigo);
                int pkProd = 0;
                string prodCodigo = string.Empty;
                double prodPrecioVenta = 0;
                foreach (var item in listaAlmacen)
                {
                    pkProd = item.fk_producto;
                    prodCodigo = item.prodCodigo;
                    //prodPrecioVenta = item.prodPrecioVenta;
                }
                //:::DATOS DE PRODUCTO
                string cateNombre = string.Empty;
                string preseNombre = string.Empty;
                string marcNombre = string.Empty;
                string unmeNombre = string.Empty;
                IEnumerable<CategoriaModel> listaCategoria;
                IEnumerable<PresentacionModel> listaPresentacion;
                IEnumerable<MarcaModel> listaMarca;
                IEnumerable<UnidadMedidaModel> listaUnme;
                IEnumerable<ProductoModel> listaProducto = productoModel.seleccionarProducto(pkProd);
                foreach (var item in listaProducto)
                {
                    listaCategoria = categoriaModel.seleccionarCategoria(item.fk_categoria);
                    foreach (var itemCate in listaCategoria)
                        cateNombre = itemCate.CateNombre;
                    listaPresentacion = presentacionModel.seleccionarPresentacion(item.fk_presentacion);
                    foreach (var itemPrese in listaPresentacion)
                        preseNombre = itemPrese.preseNombre;
                    listaMarca = marcaModel.seleccionaMarca(item.fk_marca);
                    foreach (var itemMarca in listaMarca)
                        marcNombre = itemMarca.MarcNombre;
                    listaUnme = unidadMedidaModel.seleccionarUnidadMedida(item.fk_unidadMedida);
                    foreach (var itemUnme in listaUnme)
                        unmeNombre = itemUnme.unmeNombre;
                }
                List<object> listaVede = new List<object>();

                foreach (var item in listaProducto)
                {
                    listaVede.Add(pkProd);
                    listaVede.Add(1);
                    listaVede.Add(item.prodDescripcion);
                    listaVede.Add(cateNombre);
                    listaVede.Add(preseNombre);
                    listaVede.Add(marcNombre);
                    listaVede.Add(unmeNombre);
                    listaVede.Add(0);
                    listaVede.Add(prodPrecioVenta);
                    listaVede.Add(1 * prodPrecioVenta);
                }


                if (txtBuscar.Text == prodCodigo)
                {
                    DatosVentaDetalle(listaVede);
                }
                else if (prodCodigo == null)
                {
                    
                    frmMessageBox box = new frmMessageBox();
                    box.MessageBox("Info...", "el producto aun no esta agregado en el almacen",directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    DialogResult result = box.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txtBuscar.Text = "";
                    }
                    else
                    {
                        txtBuscar.Clear();
                    }
                }
            }
            else
            {
                dvAlmacen.RowFilter = "prodDescripcion LIKE '%" + txtBuscar.Text + "%'";
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void dgVentaDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            int stockProducto = Convert.ToInt32(dgProducto.GetRowCellValue(dgProducto.FocusedRowHandle, dgProducto.Columns["prodCantidad"]));
            //Realiza la operacion de multiplicar para obtener el importe en dgVentaDetalle ↓
            if (e.Column.FieldName == "CANTIDAD" || e.Column.FieldName == "DESCUENTO")
            {
                GridView view = sender as GridView;

                double cantidad = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CANTIDAD"]));
                double precio = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["PRECIO"]));
                double descuento = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DESCUENTO"]));
                double subtotal = (cantidad * precio) - descuento;
                if (cantidad > stockProducto)
                {
                    frmMessageBox box = new frmMessageBox();
                    box.MessageBox("Aviso", "La cantidad ingresado supera el stock por favor ingrese un valor no menos del stock", directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                    dgVentaDetalle.SetRowCellValue(e.RowHandle, "CANTIDAD", stockProducto);
                }
                else
                {
                    dgVentaDetalle.SetRowCellValue(e.RowHandle, "IMPORTE", subtotal);
                }
                obtenerSubtotal();
            }
        }

        private void btEstado_Click(object sender, EventArgs e)
        {
            //CActualizarEstado objAE = new CActualizarEstado();
            //int estado = (clieEstado == 1) ? 0 : 1;
            //objAE.actalizarEstado(pk_Cliente, estado, MActualizarEstado.nameTable.cliente);
            //if (estado == 1)
            //{
            //    btEstado.Image = Image.FromFile(@"img/yes.png");
            //}
            //else
            //{
            //    btEstado.Image = Image.FromFile(@"img/dd.png");
            //}
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                obtenerDniCliente();
            }
        }

        private void txtDeuda_Leave(object sender, EventArgs e)
        {
            if (txtDeuda.Text == "" || txtDeuda.Text == "0")
            {
                double descuento = 0;
                txtDeuda.Text = descuento.ToString("C");
            }
            else
            {
                double descuento = double.Parse(txtDeuda.Text, NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
                txtDeuda.Text = descuento.ToString("C");
            }
        }

        private void txtDeuda_Enter(object sender, EventArgs e)
        {
            txtDeuda.Clear();
        }

        private void insertarVenta()
        {
            //obtener datos de documento
            int pk_comp = Convert.ToInt32(cbDocumento.SelectedValue);
            IEnumerable<ComprobanteModel> listaComprobante = comprobanteModel.seleccionarComprobante(pk_comp);

            foreach (var item in listaComprobante)
            {

                ventaModel.fk_cliente = pk_Cliente;
                ventaModel.fk_personal = Soporte.Cache.UserCache.pk_usuario;
                ventaModel.ventDocuCodigo = item.comCodigo;
                ventaModel.ventDocuNombre = cbDocumento.Text;
                ventaModel.ventDocNumero = Convert.ToInt32(txtNumero.Text);
                ventaModel.ventDocuSerie = item.comSerie;
                ventaModel.ventFechaVenta = dtFechaVenta.Value;
                ventaModel.fk_formaPago = Convert.ToInt32(cbFormaPago.SelectedValue);

                ventaModel.insertar();
            }
        }

        private void insertarVentaDetalle()
        {
            for (int i = 0; i < dgVentaDetalle.DataRowCount; i++)
            {
                ventaDetalleModel.fk_venta = ventaModel.ultimoPkVenta();
                ventaDetalleModel.fk_producto = Convert.ToInt32(dgVentaDetalle.GetRowCellValue(i, "pkProducto"));
                ventaDetalleModel.vedeCantidad = Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, "CANTIDAD"));
                ventaDetalleModel.vedePrecioVenta = Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, "PRECIO"));
                ventaDetalleModel.vedeDscto = Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, "DESCUENTO"));

                int rspta = ventaDetalleModel.insertar();
                MessageBox.Show(rspta.ToString());
            }
        }

        public void descontarStock()
        {
            for (int i = 0; i < dgVentaDetalle.DataRowCount; i++)
            {
                int fk_producto = Convert.ToInt32(dgVentaDetalle.GetRowCellValue(i, "pkProducto"));
                double cantidad = Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, "CANTIDAD"));

                almacenModel.listarProductoDescontar(fk_producto, cantidad);
            }
        }

        private void printTicketera()
        {
            //Creamos una instancia d ela clase CrearTicket
            PrintTicketera ticket = new PrintTicketera();
            //Ya podemos usar todos sus metodos
            ticket.AbreCajon();//Para abrir el cajon de dinero.

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("NOMBRE DE LA EMPRESA");
            ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
            ticket.TextoIzquierda("TELEF: 918688681");
            ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
            ticket.TextoIzquierda("EMAIL: contactanos@miansoft.com");//Es el mio por si me quieren contactar ...
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIÓ: VENDEDOR");
            ticket.TextoIzquierda("CLIENTE: " + txtCliente.Text);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            for (int i = 0; i < dgVentaDetalle.DataRowCount; i++)//dgvLista es el nombre del datagridview
            {
                string producto = dgVentaDetalle.GetRowCellValue(i, dgVentaDetalle.Columns["DESCRIPCION"]).ToString();
                int cantidad = Convert.ToInt32(dgVentaDetalle.GetRowCellValue(i, dgVentaDetalle.Columns["CANTIDAD"]));
                double precio = Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, dgVentaDetalle.Columns["PRECIO"]));
                double importe = Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, dgVentaDetalle.Columns["IMPORTE"]));

                ticket.AgregaArticulo(producto, cantidad, precio, importe);
            }

            double subtotal = 0;

            for (int i = 0; i < dgVentaDetalle.DataRowCount; i++)
            {
                subtotal += Convert.ToDouble(dgVentaDetalle.GetRowCellValue(i, "IMPORTE").ToString());
            }

            //Obteniendo totales
            double igv, total;
            igv = (cbDocumento.Text == "FACTURA") ? subtotal * 18 / 100 : 0;
            total = subtotal + igv;

            txtSubtotal.Text = subtotal.ToString("C");
            txtIgv.Text = igv.ToString("C");
            txtTotal.Text = total.ToString("C");

            //Resumen de la venta. Sólo son ejemplos
            ticket.AgregarTotales("         SUBTOTAL......S/", subtotal);
            ticket.AgregarTotales("         IVA...........S/", igv);//La M indica que es un decimal en C#
            ticket.AgregarTotales("         TOTAL.........S/", total);
            ticket.TextoIzquierda("");
            ticket.AgregarTotales("         EFECTIVO......S/", 200);
            ticket.AgregarTotales("         CAMBIO........S/", 0);

            //Texto final del Ticket.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + dgVentaDetalle.DataRowCount);
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.CortaTicket();
            ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }


        private bool estadoPrint;
        public  void estadoPrintTicketera(bool estado)
        {
            estadoPrint = estado;
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text;
            string formaPago = cbFormaPago.Text;
            double totaPagar = double.Parse(txtTotal.Text,NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
            frmProcesarVenta frmPV = new frmProcesarVenta();
            AddOwnedForm(frmPV);
            frmPV.datosProcesarVenta(totaPagar,cliente,formaPago);
            DialogResult result = frmPV.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (estadoPrint)
                {
                    printTicketera();
                }                          
                insertarVenta();
                insertarVentaDetalle();
                descontarStock();
                restablecerVenta();
                listarProducto();
            }
            else
            {
                
            }
        }

        private void restablecerVenta()
        {
            txtDni.Clear();
            txtCliente.Clear();
            txtDireccion.Clear();
            txtDeuda.Clear();
            btEstado.Visible = false;
            lbEstado.Visible = false;
            gridVentaDetalle.DataSource = null;
            dgVentaDetalle.Columns.Clear();
            createColumnButton();
            obtenerSubtotal();
            estiloDG();
            SpindEdit();
        }
    }
}
