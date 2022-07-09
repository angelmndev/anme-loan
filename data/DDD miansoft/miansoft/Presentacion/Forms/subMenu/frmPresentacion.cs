using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
using Presentacion.MyLibrary;
using Dominio.Models;
using Presentacion.Forms.Main;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.frmModify;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmPresentacion : Form
    {
        private PresentacionModel presentacionModel = new PresentacionModel();
        private DataView dvPresentacion = new DataView();
        private DirectionImage directionImage = new DirectionImage();
        private int pkPresentacion { get; set; }
        private string nomPrese { get; set; }

        style estilo = new style();

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmPresentacion()
        {
            InitializeComponent();
            dgPresentacion.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgPresentacion.OptionsView.EnableAppearanceEvenRow = true;
            listar();
            addCheckbox();
        }

        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridPresentacion.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgPresentacion.Columns["preseEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;

        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if(pkPresentacion > 0)
            {
                int estado = Convert.ToInt32(dgPresentacion.GetRowCellValue(dgPresentacion.FocusedRowHandle, "preseEstado"));
                int NEstado = (estado == 1) ? 0 : 1;
                presentacionModel.ActualizarEstado(pkPresentacion, NEstado, "presentacion");
            }
        }

        private void EstiloDG()
        {
            dgPresentacion.Columns["pk_presentacion"].Visible = false;
            dgPresentacion.Columns["preseCodigo"].Caption = "CODIGO";
            dgPresentacion.Columns["preseNombre"].Caption = "PRESENTACION";
            dgPresentacion.Columns["preseEstado"].Caption = "ESTADO";
            dgPresentacion.Columns["preseEstado"].Width = 20;
        }

        public void llenarNombrePresentacion()
        {
            List<PresentacionModel> lista = presentacionModel.GetAll();

            cbPresentacion.Items.Clear();
            cbPresentacion.Items.Add("Selecciona");
            foreach (var items in lista)
                cbPresentacion.Items.Add(items.preseNombre);
            cbPresentacion.SelectedIndex = 0;
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            llenarNombrePresentacion();

            cbEstado.SelectedIndex = 0;      
            EstiloDG();
            totalRegistro();
        }
        private void totalRegistro()
        {
     
        }
        //CRUD
        private void listar()
        {
            dvPresentacion = presentacionModel.listarPresentacion();
            gridPresentacion.DataSource = dvPresentacion;
        }

        private void nuevo()
        {
            frmNuevoPresentacion newCate = new frmNuevoPresentacion();
            DialogResult result = newCate.ShowDialog();
            if (result == DialogResult.OK)
            {
                listar();
                llenarNombrePresentacion();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
                totalRegistro();
            }

        }

        private void Modificar()
        {
            if (pkPresentacion > 0)
            {
                List<object> listaPresentacion = new List<object>();
                for(int i = 0; i < dgPresentacion.Columns.Count; i++)
                {
                    listaPresentacion.Add(dgPresentacion.GetRowCellValue(dgPresentacion.FocusedRowHandle, dgPresentacion.Columns[i]));
                }

                frmModificarPresentacion prese = new frmModificarPresentacion();
                prese.datoPresentacion(listaPresentacion);
                DialogResult resultado = prese.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listar();
                    llenarNombrePresentacion();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }
        private void EliminarUsuario()
        {

            if (pkPresentacion > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomPrese, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listar();
                    totalRegistro();
                    llenarNombrePresentacion();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }

        //END CRUD ↑
        private void BtNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void BtModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
        }

        private void DgPresentacion_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {         
            estilo.rowStyle(sender, e);
        }


        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void DgPresentacion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                pkPresentacion = Convert.ToInt32(dgPresentacion.GetRowCellValue(dgPresentacion.FocusedRowHandle, "pk_presentacion").ToString());
                nomPrese = dgPresentacion.GetRowCellValue(dgPresentacion.FocusedRowHandle, "preseNombre").ToString();
            }
            else
            {
                pkPresentacion = 0;
            }
        }

        private void DgPresentacion_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "preseEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            cbPresentacion.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            txtCodigo.Clear();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            dvPresentacion.RowFilter = ("preseCodigo LIKE '" + txtCodigo.Text + "%'");
        }

        private void cbPresentacion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbPresentacion.Text != "Selecciona" )
            {
                dvPresentacion.RowFilter = ("preseNombre LIKE '" + cbPresentacion.Text + "%'");
            }
            else
            {
                listar();
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbEstado.Text != "Selecciona" )
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvPresentacion.RowFilter = ("Convert(preseEstado, 'System.String')  LIKE '" + estado + "%'");
            }
            else
            {
                listar();
            }
        }
    }
}
