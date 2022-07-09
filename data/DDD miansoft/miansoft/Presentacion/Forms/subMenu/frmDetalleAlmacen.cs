using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Dominio.Models;
using System;
using System.Collections;
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
    public partial class frmDetalleAlmacen : Form
    {
        private CategoriaModel categoriaModel = new CategoriaModel();
        private PresentacionModel presentacionModel = new PresentacionModel();
        private MarcaModel marcaModel = new MarcaModel();
        private AlmacenModel almacenModel = new AlmacenModel();
        private DataView dvDA = new DataView();
        public frmDetalleAlmacen()
        {
            InitializeComponent();
            dgDtAlmacen.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgDtAlmacen.OptionsView.EnableAppearanceEvenRow = true;
           
        }

        private void showCate()
        {
            List<CategoriaModel> lista = categoriaModel.GetAll();

            cbCategoria.Items.Add("Selecciona");
            foreach (var items in lista)
                cbCategoria.Items.Add(items.CateNombre);

        }

        private void showMarca()
        {
            List<MarcaModel> lista = marcaModel.GetAll();
            cbMarca.Items.Add("Selecciona");
            foreach (var items in lista)
                cbMarca.Items.Add(items.MarcNombre);
        }
        private void showPrese()
        {
            List<PresentacionModel> lista = presentacionModel.GetAll();
            cbPresentacion.Items.Add("Selecciona");
            foreach (var items in lista)
                cbPresentacion.Items.Add(items.preseNombre);
        }

        private void estiloDG()
        {
            dgDtAlmacen.Columns["fk_producto"].Visible = false;
            dgDtAlmacen.Columns["prodDescripcion"].Caption = "DESCRIPCION";
            dgDtAlmacen.Columns["prodCantidad"].Caption = "CANTIDAD";
            dgDtAlmacen.Columns["prodCodigo"].Caption = "CODIGO";
            dgDtAlmacen.Columns["cateNombre"].Caption = "CATEGORIA";
            dgDtAlmacen.Columns["marcNombre"].Caption = "MARCA";
            dgDtAlmacen.Columns["preseNombre"].Caption = "PRESENTACION";
            dgDtAlmacen.Columns["unmeNombre"].Caption = "UNIDAD DE MEDIDA";
        }



        private void listarDA()
        {
            string std = cbMostrarPor.Text;
            switch (std)
            {
                case "Vigente":
                    dvDA = almacenModel.listarAlmacen("vigente");
                    gridDtAlmacen.DataSource = dvDA;
                    break;
                case "Pasado":
                    dvDA = almacenModel.listarAlmacen("pasado");
                    gridDtAlmacen.DataSource = dvDA;
                    break;
                case "Todo":
                    dvDA = almacenModel.listarAlmacen("todo");
                    gridDtAlmacen.DataSource = dvDA;
                    break;
            }
        }

        private void frmDetalleAlmacen_Load(object sender, EventArgs e)
        {
            cbMostrarPor.SelectedIndex = 0;
            listarDA();
            showMarca();
            showPrese();
            showCate();
            estiloDG();
            elimnarBotonADD();
            
        }

        private void elimnarBotonADD()
        {
            ControlNavigator navigator = gridDtAlmacen.EmbeddedNavigator;
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

        private void dgDtAlmacen_ShowingEditor(object sender, CancelEventArgs e)
        {
           
        }

        private void dgDtAlmacen_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;  
            if(e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "cantidad")
                {
                    int cantidad = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "cantidad"));
                    if (cantidad <= 10)
                        e.Appearance.BackColor = Color.FromArgb(255, 25, 64);
                    else if(cantidad <= 50 && cantidad > 10)
                        e.Appearance.BackColor = Color.FromArgb(243, 156, 18);
                    else if(cantidad > 50)
                        e.Appearance.BackColor = Color.FromArgb(46, 204, 113);
                }

            }
        }

        private void dgDtAlmacen_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
  
        }

        private void cbCategoria_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbCategoria.Text != "Selecciona")
            {
                dvDA.RowFilter = ("cateNombre LIKE '%" + cbCategoria.Text + "%'");
            }
            else
            {
                listarDA();
            }
        }

        private void cbMarca_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbMarca.Text != "Selecciona")
            {
                dvDA.RowFilter = ("marcNombre LIKE '%" + cbMarca.Text + "%'");
            }
            else
            {
                listarDA();
            }
        }

        private void cbPresentacion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbPresentacion.Text != "Selecciona")
            {
                dvDA.RowFilter = ("preseNombre LIKE '%" + cbPresentacion.Text + "%'");
            }
            else
            {
                listarDA();
            }
        }

        private void cbCategoria_Enter(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            cbMarca.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }

        private void cbMarca_Enter(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }

        private void cbPresentacion_Enter(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            cbMarca.SelectedIndex = 0;
            cbCategoria.SelectedIndex = 0;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            dvDA.RowFilter = ("prodDescripcion LIKE '%" + txtDescripcion.Text + "%'");

        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            cbMarca.SelectedIndex = 0;
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            cbMarca.SelectedIndex = 0;
            cbCategoria.SelectedIndex = 0;
            cbPresentacion.SelectedIndex = 0;
        }

        private void cbMostrarPor_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            listarDA();
        }
    }
}
