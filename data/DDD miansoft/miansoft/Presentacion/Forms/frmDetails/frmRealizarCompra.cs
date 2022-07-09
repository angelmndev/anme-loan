using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Forms.subMenu;
using Presentacion.Helps;
using Presentacion.MyLibrary;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmRealizarCompra : Form
    {
        private ProductoModel productoModel = new ProductoModel();
        private UnidadMedidaModel unidadMedidaModel = new UnidadMedidaModel();
        private PresentacionModel presentacionModel = new PresentacionModel();
        private CategoriaModel categoriaModel = new CategoriaModel();
        private MarcaModel marcaModel = new MarcaModel();
        private DirectionImage directionImage = new DirectionImage();
        private int pkProducto { get; set; }
        public frmRealizarCompra()
        {
            InitializeComponent();
        }
        private IEnumerable<ProductoModel> listaProducto;
        private IEnumerable<PresentacionModel> listaPresentacion;
        private IEnumerable<UnidadMedidaModel> listaUnidadMedidaModels;
        public void datosProducto(int pk)
        {
            listaProducto= productoModel.seleccionarProducto(pk);
            foreach (var item in listaProducto)
            {
                string preseNombre = string.Empty;
                string unmeNombre = string.Empty;
             
                pkProducto = item.pk_producto;
                lbDescripcion.Text = item.prodDescripcion;
                listaPresentacion = presentacionModel.seleccionarPresentacion(item.fk_presentacion);
                foreach(var itemPrese in listaPresentacion)
                {
                    preseNombre = itemPrese.preseNombre;
                }
                listaUnidadMedidaModels = unidadMedidaModel.seleccionarUnidadMedida(item.fk_unidadMedida);
                foreach(var itemUnme in listaUnidadMedidaModels)
                {
                    unmeNombre = itemUnme.unmeNombre;
                }

                lbDetalles.Text = "Presentacion: " + preseNombre + "\n" + "Unidad Medida: " + unmeNombre;
                pbFoto.Image = Image.FromFile(@"recursos/Productos/" + item.prodFoto);
                txtPrecioVenta.Text = item.prodPrecioUnitario.ToString();
                if (item.prodPerecedero == 1)
                    dtFechaVencimiento.Enabled = true;
                else if(item.prodPerecedero == 0)
                    dtFechaVencimiento.Enabled = false;
            }        

        }
        private void btAgregar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            string fechaFencimiento =(dtFechaVencimiento.Enabled)?dtFechaVencimiento.Text:"";
            List<object> listaCode = new List<object>();
            foreach (var item in listaProducto)
            {
                string cateNombre = string.Empty;
                string preseNombre = string.Empty;
                string marcNombre = string.Empty;
                string unmeNombre = string.Empty;
                IEnumerable<CategoriaModel> listaCategoria = categoriaModel.seleccionarCategoria(item.fk_categoria);
                IEnumerable<MarcaModel> listaMarca = marcaModel.seleccionaMarca(item.fk_marca);
                foreach (var itemCate in listaCategoria)
                {
                    cateNombre = itemCate.CateNombre;
                }
                foreach (var itemPrese in listaPresentacion)
                {
                    preseNombre = itemPrese.preseNombre;
                }
                foreach (var itemUnme in listaUnidadMedidaModels)
                {
                    unmeNombre = itemUnme.unmeNombre;
                }
                foreach (var itemMarc in listaMarca)
                {
                    marcNombre = itemMarc.MarcNombre;
                }
                listaCode.Add(pkProducto);
                listaCode.Add(cantidad);
                listaCode.Add(item.prodDescripcion);
                listaCode.Add(cateNombre);
                listaCode.Add(preseNombre);
                listaCode.Add(marcNombre);
                listaCode.Add(unmeNombre);
                listaCode.Add(fechaFencimiento);
                listaCode.Add(precio);
                listaCode.Add(cantidad*precio);
            }
     
            frmCompras compras = Owner as frmCompras;
            compras.DatosCompraDetalle(listaCode);
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int posX = 0;
        int posY = 0;
        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmRealizarCompra_Load(object sender, EventArgs e)
        {
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            mnValidation val = new mnValidation();
            val.soloNumeroDecimal(sender, e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            mnValidation val = new mnValidation();
            val.soloNumeroDecimal(sender, e);
        }

        private void txtPrecioVenta_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            double prodPrecioUnitario = Convert.ToDouble(txtPrecioVenta.Text);
            productoModel.modificarPrecioVenta(pkProducto, prodPrecioUnitario);
        }

        private void txtPrecioVenta_Enter(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            box.MessageBox("Aviso", "Estas seguro que quiere cambiar el precio de venta.?", directionImage.nameFileImage(DirectionImage.fileImage.question));
            DialogResult result = box.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPrecioVenta.ReadOnly = false;
            }
            else
            {
                txtPrecioVenta.ReadOnly = true;
            }
        }
    }
}
