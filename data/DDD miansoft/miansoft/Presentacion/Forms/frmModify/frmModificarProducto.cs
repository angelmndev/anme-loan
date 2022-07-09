using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Presentacion.Helps;
using Dominio.Models;
using Presentacion.Forms.Main;
using Telerik.WinControls.UI;

namespace Presentacion.Forms.frmModify
{
    public partial class frmModificarProducto : Form
    {
        private ProductoModel productoModel = new ProductoModel();
        private MarcaModel marcaModel = new MarcaModel();
        private CategoriaModel categoriaModel = new CategoriaModel();
        private UnidadMedidaModel unidadMedidaModel = new UnidadMedidaModel();
        private PresentacionModel presentacionModel = new PresentacionModel();
        private ValidacionDatos validacionDatos = new ValidacionDatos();
        private DirectionImage directionImage = new DirectionImage();
        private DataView dvMarca = new DataView();
        private DataView dvCategoria = new DataView();
        private  DataView dvPresentacion = new DataView();
        private DataView dvUnme = new DataView();
        
        private int pkProd { get; set; }
        public frmModificarProducto()
        {
            InitializeComponent();
            listarCategoria();
            listarMarca();
            listarPresentacion();
            listarUnme();
        }

        public void modificarProducto(int pkProducto)
        {
           
            var productoData = productoModel.seleccionarProducto(pkProducto);
            foreach(var item in productoData)
            {
                pkProd = item.pk_producto;
                txtDescripcion.Text = item.prodDescripcion;
                txtCodigo.Text = item.prodCodigo;
                txtCosto.Text = item.prodPrecioUnitario.ToString();
                pbFoto.Image = Image.FromFile(@"recursos/Productos/" + item.prodFoto);
                txtStokMin.Text = item.prodStkMin.ToString();
                txtStockMax.Text = item.prodStkMax.ToString();
                cbCategoria.SelectedValue = item.fk_categoria;
                cbPresentacion.SelectedValue = item.fk_presentacion;
                cbUnidadMedida.SelectedValue = item.fk_unidadMedida;
                cbMarca.SelectedValue = item.fk_marca;
                chkEstado.Checked = (item.prodEstado == 1) ? true : false;
                chkPerecedero.Checked = (item.prodPerecedero == 1) ? true : false;
            }      
        }

        //LISTAR MARCA
        private void listarMarca()
        {
            dvMarca = marcaModel.listar();
            cbMarca.DisplayMember = "marcNombre";
            cbMarca.ValueMember = "pk_marca";
            cbMarca.DataSource = dvMarca;

        }

        //LISTAR CATEGORIA
        private void listarCategoria()
        {
            dvCategoria = categoriaModel.listarCategoria();
            cbCategoria.DisplayMember = "cateNombre";
            cbCategoria.ValueMember = "pk_categoria";
            cbCategoria.DataSource = dvCategoria;
        }

        //LISTAR PRESENTACION
        private void listarPresentacion()
        {
            dvPresentacion = presentacionModel.listarPresentacion();
            cbPresentacion.DisplayMember = "preseNombre";
            cbPresentacion.ValueMember = "pk_presentacion";
            cbPresentacion.DataSource = dvPresentacion;
        }

        //LISTAR UNIDAD MEDIDA
        private void listarUnme()
        {
            dvUnme = unidadMedidaModel.listarUnme();
            cbUnidadMedida.DisplayMember = "unmeNombre";
            cbUnidadMedida.ValueMember = "pk_unidadMedida";
            cbUnidadMedida.DataSource = dvUnme;
        }
        private void FrmModificarProducto_Load(object sender, EventArgs e)
        {
           
            cbMoneda.SelectedIndex = 0;
            rbCodigoAntiguo.IsChecked = true;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        string namePhoto = "";
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (validarCampoVacio()&&validacionDatos.validarTexboxRange(txtCodigo,9))
            {
             

                IEnumerable<ProductoModel> listaProd = productoModel.seleccionarProducto(pkProd);
                string nameFotoDB = string.Empty;
                foreach(var item in listaProd)
                {
                    nameFotoDB = item.prodFoto;
                }

                productoModel.estado = Dominio.ObjetoValor.EstadoEntidad.modificar;
                string fileNameDB = @"recursos/Productos/" + nameFotoDB;
                string fileNameCarpeta = @"recursos\\Productos\\" + namePhoto;
                //string path = @"recursos/Productos/";
                // string resultNameDB = Path.GetFileName(fileNameDB);
                //string resultNameCarpeta = Path.GetFileName(fileNameCarpeta);
                //result = Path.GetFileName(path);

                productoModel.pk_producto = pkProd;
                productoModel.prodDescripcion = txtDescripcion.Text;
                productoModel.prodCodigo = txtCodigo.Text;
                productoModel.prodPrecioUnitario = Convert.ToDouble(txtCosto.Text);
                productoModel.prodFoto = (namePhoto != "") ? namePhoto : nameFotoDB;
                productoModel.prodStkMin = Convert.ToDouble(txtStokMin.Text);
                productoModel.prodStkMax = Convert.ToDouble(txtStockMax.Text);
                productoModel.prodEstado = (chkEstado.Checked) ? 1 : 0;
                productoModel.fk_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                productoModel.fk_presentacion = Convert.ToInt32(cbPresentacion.SelectedValue);
                productoModel.fk_unidadMedida = Convert.ToInt32(cbUnidadMedida.SelectedValue);
                productoModel.fk_marca = Convert.ToInt32(cbMarca.SelectedValue);
                productoModel.prodPerecedero = (chkPerecedero.Checked) ? 1 : 0;
                string mensaje = productoModel.guardarCambios();

                if(mensaje == "")
                {
                    if (File.Exists(fileNameCarpeta) == false && namePhoto != "")
                    {
                        pbFoto.Image.Save(@"recursos/Productos/" + namePhoto);
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (File.Exists(fileNameCarpeta))
                    {
                        frmMessageBox fmb = new frmMessageBox();
                        fmb.MessageBox("Informacion", "La foto ya existe por favor \n selecciona otro. Gracias", directionImage.nameFileImage(DirectionImage.fileImage.information));
                        fmb.ShowDialog();
                    }
                    else if (namePhoto == "")
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    box.MessageBox("Error al guardar", mensaje, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                }



            }
            else
            {
             
                RadTextBox[] text = { txtCodigo, txtDescripcion, txtStokMin, txtStockMax, txtCosto };
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Text == "")
                    {
                        validacionDatos.validarCampoVacioTxt(text[i]);
                    }
                }

                if (!validarCampoVacio())
                    box.MessageBox("Aviso", "Todos los campos es importante", directionImage.nameFileImage(DirectionImage.fileImage.information));
                else if (!validacionDatos.validarTexboxRange(txtCodigo, 9))
                    box.MessageBox("Aviso", "El campo codigo debe tener no menos de 9 caracteres", directionImage.nameFileImage(DirectionImage.fileImage.information));

                box.ShowDialog();
            }
        }

        
        private void PbFoto_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog seleccionar = new OpenFileDialog();
            seleccionar.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            DialogResult resultado = seleccionar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(seleccionar.FileName);
                FileInfo info = new FileInfo(seleccionar.FileName);
                namePhoto = info.Name;
            }
        }

        private void ChkEstado_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }


        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {
            validarCampoVacio();
        }

        MyLibrary.mnValidation validation = new MyLibrary.mnValidation();
        private void TxtCosto_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            e.Cancel = !validation.IsNumber(e.NewValue);
        }

        private bool validarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtDescripcion.Text) &&
                !string.IsNullOrEmpty(txtStokMin.Text) &&
                !string.IsNullOrEmpty(txtStockMax.Text) &&
                !string.IsNullOrEmpty(txtCosto.Text);
            return vr;
        }
        private void TxtStockMax_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtStockMax);
        }

        private void TxtStokMin_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtStokMin);
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo, 9);
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDescripcion);
        }
    }
}
