using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using Telerik.WinControls.UI;
using DevExpress.XtraScheduler.Commands;
using Presentacion.MyLibrary;

namespace Presentacion.Forms.frmNew
{
    public partial class frmNuevoProducto : Form
    {
        private MarcaModel marcaModel = new MarcaModel();
        private CategoriaModel categoriaModel = new CategoriaModel();
        private PresentacionModel presentacionModel = new PresentacionModel();
        private UnidadMedidaModel unidadMedidaModel = new UnidadMedidaModel();
        private DirectionImage directionImage = new DirectionImage();
        private ProductoModel productoModel = new ProductoModel();

        private ValidacionDatos validacionDatos = new ValidacionDatos();

        private DataView dvMarca = new DataView();
        private DataView dvCategoria = new DataView();
        private DataView dvPresentacion = new DataView();
        private DataView dvUnme = new DataView();
        public frmNuevoProducto()
        {
            InitializeComponent();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int posX = 0;
        int posY = 0;
        private void moverFormulario(MouseEventArgs e)
        {      
            if(e.Button != MouseButtons.Left)
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
        private void PnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            moverFormulario(e);
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// --VALDAR CAMPO VACIO DE LOS TEXBOX
        /// </summary>
       
        private bool validarCampoVacio()
        {
            var vr = !string.IsNullOrEmpty(txtCodigo.Text) &&
                !string.IsNullOrEmpty(txtDescripcion.Text) &&     
                !string.IsNullOrEmpty(txtStokMin.Text) &&
                !string.IsNullOrEmpty(txtStockMax.Text) &&
                !string.IsNullOrEmpty(txtCosto.Text);
            return vr;
        }
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarTexboxRange(txtCodigo,9);
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtDescripcion);
        }

        private void TxtCategoria_TextChanged(object sender, EventArgs e)
        {
        
            dvCategoria.RowFilter = "cateNombre like '%" + txtCategoria.Text + "%'";
        }

        private void TxtPresentacion_TextChanged(object sender, EventArgs e)
        {
           
            dvPresentacion.RowFilter = "preseNombre like '%" + txtPresentacion.Text + "%'";
        }

        private void TxtUnidadMedida_TextChanged(object sender, EventArgs e)
        {
            
            dvUnme.RowFilter = "unmeNombre like '%" + txtUnidadMedida.Text + "%'";
        }

        private void TxtMarca_TextChanged(object sender, EventArgs e)
        {
                 
            dvMarca.RowFilter = "marcNombre like '%" + txtMarca.Text + "%'";
        }

        private void TxtStokMin_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtStokMin);
        }

        private void TxtStockMax_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtStockMax);
        }

        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {
            validacionDatos.validarCampoVacioTxt(txtCosto);
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
        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            listarMarca();
            listarCategoria();
            listarPresentacion();
            listarUnme();
            pbFoto.Image = Image.FromFile(@"recursos/img/imgDoont.png");
            rbCodigoAntiguo.IsChecked = true;
            chkEstado.Checked = true;
            cbMoneda.SelectedIndex = 0;
        }

        string namePhoto = "";
        private void pbFoto_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog seleccionar = new OpenFileDialog();
            seleccionar.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            DialogResult resultado = seleccionar.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(seleccionar.FileName);
                FileInfo info = new FileInfo(seleccionar.FileName);
                namePhoto = info.Name;
            }
        }

        private void btGuardar_Click_1(object sender, EventArgs e)
        {
            frmMessageBox box = new frmMessageBox();
            if (validarCampoVacio() && validacionDatos.validarTexboxRange(txtCodigo,9))
            {
                productoModel.estado = Dominio.ObjetoValor.EstadoEntidad.insertar;
                productoModel.prodDescripcion = txtDescripcion.Text;
                productoModel.prodCodigo = txtCodigo.Text;
                productoModel.prodPrecioUnitario = Convert.ToDouble(txtCosto.Text);
                productoModel.prodFoto = (namePhoto == "") ? "imgDoont.png" : namePhoto;
                productoModel.prodStkMin = Convert.ToDouble(txtStokMin.Text);
                productoModel.prodStkMax = Convert.ToDouble(txtStockMax.Text);
                productoModel.fk_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                productoModel.fk_presentacion = Convert.ToInt32(cbPresentacion.SelectedValue);
                productoModel.fk_unidadMedida = Convert.ToInt32(cbUnidadMedida.SelectedValue);
                productoModel.fk_marca = Convert.ToInt32(cbMarca.SelectedValue);
                productoModel.prodEstado = (chkEstado.Checked) ? 1 : 0;
                productoModel.prodPerecedero = (chkPerecedero.Checked) ? 1 : 0;
                string mensaje = productoModel.guardarCambios();
                if (mensaje == "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {                 
                    box.MessageBox("Error al guardar", mensaje, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                    box.ShowDialog();
                }
                if (namePhoto != "")
                    pbFoto.Image.Save(@"recursos/Productos/" + namePhoto);

            }
            else
            {
 
                RadTextBox[] text = { txtCodigo, txtDescripcion, txtStokMin, txtStockMax, txtCosto };
                for(int i = 0; i < text.Length; i++)
                {
                    if(text[i].Text == "")
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

        private void ChkEstado_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
           
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private mnValidation valid = new mnValidation();
        private void txtStokMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeroDecimal(sender, e);
        }

        private void txtStockMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeroDecimal(sender, e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.soloNumeroDecimal(sender, e);
        }
    }
}
