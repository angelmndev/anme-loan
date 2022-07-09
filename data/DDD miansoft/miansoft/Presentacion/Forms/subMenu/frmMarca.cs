using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using Presentacion.MyLibrary;
using Dominio.Models;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.Main;
using Presentacion.Forms.frmModify;
using System.Collections;
using System.Collections.Generic;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmMarca : Form
    {
        private DataView dvMarca = new DataView();
        private MarcaModel objMarca = new MarcaModel();
        private style st = new style();
        private DirectionImage directionImage = new DirectionImage();
        private int pkMarca { get; set; }
        private string nomMarca { get; set; }



        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmMarca()
        {
            InitializeComponent();
            dgMarca.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgMarca.OptionsView.EnableAppearanceEvenRow = true;

            listarMarca();
            addCheckbox();
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridMarca.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgMarca.Columns["marcEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += checkEdit_CheckedChanged;

        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (pkMarca > 0)
            {
                
                int std = Convert.ToInt32(dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "marcEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
                objMarca.actualizarEstado(pkMarca, estado, "marca");
            }

        }

        private void estiloDG()
        {
            dgMarca.Columns["pk_marca"].Visible = false;
            dgMarca.Columns["marcCodigo"].Caption = "CODIGO";
            dgMarca.Columns["marcNombre"].Caption = "MARCA";
            dgMarca.Columns["marcEstado"].Caption = "ESTADO";
            dgMarca.Columns["marcEstado"].Width = 30;
        }      
        
        private void listarMarca()
        {
            dvMarca = objMarca.listar();
            gridMarca.DataSource = dvMarca;
        }
        private void FrmMarca_Load(object sender, EventArgs e)
        {
            st.DockStyle(rDock, documentWindow4);
            estiloDG();
            totalRegistro();
            cbEstado.SelectedIndex = 0;
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgMarca.DataRowCount.ToString();
        }
        private void DgMarca_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
            st.rowStyle(sender, e);
        }

        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);

        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            frmNuevaMarca marca = new frmNuevaMarca();
            DialogResult result = marca.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarMarca();
                totalRegistro();
                this.Alert("Se guardo correctamente", frmNotificaciones.estado.Success);
            }
        }

        //MODIFICAR PRODUCTO
        private void modificar()
        {
            if (pkMarca > 0)
            {
                List<object> lista = new List<object>();
                lista.Add(dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "pk_marca"));
                lista.Add(dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "marcCodigo"));
                lista.Add(dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "marcNombre"));
                lista.Add(dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "marcEstado"));
                frmModificarMarca modi = new frmModificarMarca();
                modi.datosMarca(lista);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarMarca();
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
        private void eliminarUsuario()
        {

            if (pkMarca > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomMarca, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    objMarca.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    objMarca.Pk_marca = pkMarca;
                    string rpta = objMarca.GuardarCambios();
                    this.Alert(rpta, frmNotificaciones.estado.Success);
                    listarMarca();
                    totalRegistro();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
         
        }
        private void BtEliminar_Click(object sender, EventArgs e)
        {
            eliminarUsuario();
        }

        private void DgMarca_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "marcEstado")
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void DgMarca_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                pkMarca = Convert.ToInt32(dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "pk_marca").ToString());
                nomMarca = dgMarca.GetRowCellValue(dgMarca.FocusedRowHandle, "marcNombre").ToString();
            }
            else
            {
                pkMarca = 0;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            dvMarca.RowFilter = ("marcCodigo LIKE '" + txtCodigo.Text + "%' ");
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvMarca.RowFilter = "marcNombre LIKE '%" + txtNombre.Text + "%'";
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvMarca.RowFilter = ("Convert(marcEstado, 'System.String')  LIKE '%" + estado + "%'");
            }
            else
            {
                listarMarca();
            }
        }
    }
}
