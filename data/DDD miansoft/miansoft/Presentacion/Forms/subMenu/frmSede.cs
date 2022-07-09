using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Dominio.Models;
using Presentacion.Forms.frmModify;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.Main;
using Presentacion.Helps;
using Presentacion.MyLibrary;
using System;
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
    public partial class frmSede : Form
    {
        private SedeModel sedeModel = new SedeModel();
        private DataView dvSede = new DataView();
        private DirectionImage directionImage = new DirectionImage();
        private int pkSede { get; set; }
        private string sedeProv { get; set; }

        private style estilo = new style();
        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmSede()
        {
            InitializeComponent();
            dgSede.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgSede.OptionsView.EnableAppearanceEvenRow = true;
            listarSede();
            addCheckbox();
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridSede.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgSede.Columns["sedeEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;

        }
        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (pkSede > 0)
            {
                int estado = Convert.ToInt32(dgSede.GetRowCellValue(dgSede.FocusedRowHandle, "sedeEstado"));
                int NEstado = (estado == 1) ? 0 : 1;
                sedeModel.actualizrEstado(pkSede, NEstado, "sede");
            }
        }
        private void EstiloDG()
        {
            dgSede.Columns["pk_sede"].Visible = false;
            dgSede.Columns["sedeProvincia"].Caption = "PROVINCIA";
            dgSede.Columns["sedeDistrito"].Caption = "DISTRITO";
            dgSede.Columns["sedeDireccion"].Caption = "DIRECCION";
            dgSede.Columns["sedeTelefono"].Caption = "TELEFONO";
            dgSede.Columns["sedeCodigoPostal"].Caption = "CODIGO POSTAL";
            dgSede.Columns["sedeEstado"].Caption = "ESTADO";
        }
        private void listarSede()
        {
            dvSede = sedeModel.listarSede();
            gridSede.DataSource = dvSede;

            GridColumn gridColumn = dgSede.Columns["sedeProvincia"];
            gridColumn.GroupIndex = 0;
        }

        private void frmSede_Load(object sender, EventArgs e)
        {
            EstiloDG();
            cbEstado.SelectedIndex = 0;
            estilo.DockStyle(rDock, documentWindow4);
        }
        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void dgSede_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender, e);
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoSede newSede = new frmNuevoSede();
            DialogResult result = newSede.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarSede();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }
        }
        //MODIFICAR PRODUCTO
        private void Modificar()
        {
            if (pkSede > 0)
            {
                List<object> listaSede = new List<object>();
                for(int i = 0;i < dgSede.Columns.Count; i++)
                {
                    listaSede.Add(dgSede.GetRowCellValue(dgSede.FocusedRowHandle, dgSede.Columns[i]));
                }

                frmModificarSede modi = new frmModificarSede();
                modi.DatosSede(listaSede);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarSede();
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
        private void Eliminar()
        {

            if (pkSede > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar la sede de " + sedeProv, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    sedeModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    sedeModel.pk_sede = pkSede;
                    sedeModel.GuardarCambios();
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarSede();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }
        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dgSede_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkSede = Convert.ToInt32(dgSede.GetRowCellValue(dgSede.FocusedRowHandle, "pk_sede").ToString());
                sedeProv = dgSede.GetRowCellValue(dgSede.FocusedRowHandle, "sedeProvincia").ToString();
            }
            else
            {
                pkSede = 0;
            }
        }

        private void dgSede_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "cateEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtProvincia.Clear();
            txtDistrito.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void txtProvincia_TextChanged(object sender, EventArgs e)
        {
            txtDistrito.Clear();
            cbEstado.SelectedIndex = 0;
            dvSede.RowFilter = "sedeProvincia LIKE '%" + txtProvincia.Text + "%'";
        }

        private void txtDistrito_TextChanged(object sender, EventArgs e)
        {
            txtProvincia.Clear();
            cbEstado.SelectedIndex = 0;
            dvSede.RowFilter = "sedeDistrito LIKE '%" + txtDistrito.Text + "%'";
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvSede.RowFilter = ("Convert(sedeEstado, 'System.String')  LIKE '" + estado + "%'");
            }
            else
            {
                listarSede();
            }
        }
    }
}
