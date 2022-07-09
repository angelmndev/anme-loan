using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using Presentacion.MyLibrary;
using Presentacion.Forms.Main;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.frmModify;
using Dominio.Models;
using System.Collections.Generic;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmCategoria : Form
    {
        private CategoriaModel categoriaModel = new CategoriaModel();
        private DataView dvCategoria = new DataView();
        private DirectionImage directionImage = new DirectionImage();
        private int pkCategoria { get; set; }
        private string nomCate { get; set; }

        private style estilo = new style();
        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmCategoria()
        {
            InitializeComponent();
            dgCategoria.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgCategoria.OptionsView.EnableAppearanceEvenRow = true;
            listarCategoria();
            addCheckbox();
        }

        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridCategoria.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgCategoria.Columns["cateEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;

        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if(pkCategoria > 0)
            {
                int estado = Convert.ToInt32(dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "cateEstado"));
                int NEstado = (estado == 1) ? 0 : 1;
                categoriaModel.actualizarEstado(pkCategoria, NEstado, "categoria");
            }
        }

        private void EstiloDG()
        {
            dgCategoria.Columns["pk_categoria"].Visible = false;
            dgCategoria.Columns["cateCodigo"].Caption = "CODIGO";
            dgCategoria.Columns["cateNombre"].Caption = "CATEGORIA";
            dgCategoria.Columns["cateEstado"].Caption = "ESTADO";
        }

        private void listarCategoria()
        {
            dvCategoria = categoriaModel.listarCategoria();
            gridCategoria.DataSource = dvCategoria;
        }
        
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            EstiloDG();
            totalRegistro();
            cbEstado.SelectedIndex = 0;
            estilo.DockStyle(rDock, documentWindow4);
        }

        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: "+dgCategoria.DataRowCount.ToString();
        }

        private void dgCategoria_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender,e);
        }

        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoCategoria newCate = new frmNuevoCategoria();
            DialogResult result = newCate.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarCategoria();
                totalRegistro();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }
        }

        //MODIFICAR PRODUCTO
        private void Modificar()
        {
            if (pkCategoria > 0)
            {
                List<object> listaCate = new List<object>();
                listaCate.Add(dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "pk_categoria"));
                listaCate.Add(dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "cateCodigo"));
                listaCate.Add(dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "cateNombre"));
                listaCate.Add(dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "cateEstado"));

                frmModificarCategoria modi = new frmModificarCategoria();
                modi.DatoCategoria(listaCate);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarCategoria();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }
        private void btModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        //ELIMINAR
        private void EliminarUsuario()
        {

            if (pkCategoria > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomCate, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

       
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarCategoria();
                    totalRegistro(); 
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
        }

        private void dgCategoria_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkCategoria = Convert.ToInt32(dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "pk_categoria").ToString());
                nomCate = dgCategoria.GetRowCellValue(dgCategoria.FocusedRowHandle, "cateNombre").ToString();
            }
            else
            {
                pkCategoria = 0;
            }
        }

        private void DgCategoria_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "cateEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

            dvCategoria.RowFilter = ("cateCodigo LIKE '" + txtCodigo.Text + "%' and cateNombre LIKE '" + txtNombre.Text + "%'");
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvCategoria.RowFilter = ("cateCodigo LIKE '" + txtCodigo.Text + "%' and cateNombre LIKE '" + txtNombre.Text + "%'");          
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvCategoria.RowFilter = ("Convert(cateEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else
            {
                listarCategoria();
            }
        }
    }
}
