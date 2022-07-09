using DevExpress.XtraEditors.Repository;
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
    public partial class frmMoneda : Form
    {
        private DataView dvMoneda = new DataView();
        private MonedaModel monedaModel = new MonedaModel();
        private DirectionImage directionImage = new DirectionImage();
        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        private int pkMoneda { get; set; }
        private string moneNombre { get; set; }
        public frmMoneda()
        {
            InitializeComponent();
            listarMoneda();
            addCheckbox();
            dgMoneda.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgMoneda.OptionsView.EnableAppearanceEvenRow = true;
            dgMoneda.OptionsSelection.EnableAppearanceFocusedRow = false;
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridMoneda.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgMoneda.Columns["moneEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (pkMoneda != 0)
            {
                int std = Convert.ToInt32(dgMoneda.GetRowCellValue(dgMoneda.FocusedRowHandle, "moneEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
                monedaModel.ActualizarEstado(pkMoneda, estado, "moneda");
            }

        }

        private void listarMoneda()
        {
            dvMoneda = monedaModel.listarMoneda();
            gridMoneda.DataSource = dvMoneda;
        }

        private void EstiloDG()
        {
            dgMoneda.Columns["pk_moneda"].Visible = false;
            dgMoneda.Columns["moneIso"].Caption = "ISO";
            dgMoneda.Columns["moneSimbolo"].Caption = "SIMBOLO";
            dgMoneda.Columns["moneLenguaje"].Caption = "LENGUAJE";
            dgMoneda.Columns["moneNombre"].Caption = "MONEDA";
            dgMoneda.Columns["moneEstado"].Caption = "ESTADO";
        }

        private void frmMoneda_Load(object sender, EventArgs e)
        {
            EstiloDG();
            cbEstado.SelectedIndex = 0;
        }

        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);

        }
        private void btNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoMoneda moneda = new frmNuevoMoneda();
            AddOwnedForm(moneda);
            DialogResult result = moneda.ShowDialog();
            if(result == DialogResult.OK)
            {
                listarMoneda();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {

            if (pkMoneda > 0)
            {
                List<object> listaMoneda = new List<object>();
                for(int i = 0;i < dgMoneda.Columns.Count; i++)
                {
                    listaMoneda.Add(dgMoneda.GetRowCellValue(dgMoneda.FocusedRowHandle, dgMoneda.Columns[i]));
                }

                frmModificarMoneda modi = new frmModificarMoneda();
                modi.DatosMoneda(listaMoneda);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarMoneda();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }

        private void dgMoneda_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "moneEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgMoneda_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkMoneda = Convert.ToInt32(dgMoneda.GetRowCellValue(dgMoneda.FocusedRowHandle, "pk_moneda").ToString());
                moneNombre = dgMoneda.GetRowCellValue(dgMoneda.FocusedRowHandle, "moneNombre").ToString();

            }
            else
            {
                pkMoneda = 0;
            }
        }

        private void dgMoneda_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            style st = new style();
            st.rowStyle(sender, e);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (pkMoneda != 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + moneNombre, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    monedaModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    monedaModel.pk_moneda = pkMoneda;
                    monedaModel.GuardarCambios();
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarMoneda();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvMoneda.RowFilter = ("Convert(moneEstado, 'System.String')  LIKE '" + estado + "%'");
            }
            else
            {
                listarMoneda();
            }
          
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
            dvMoneda.RowFilter = "moneIso LIKE '%" + txtCodigo.Text + "%'";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            cbEstado.SelectedIndex = 0;
            dvMoneda.RowFilter = "moneNombre LIKE '%" + txtNombre.Text + "%'";
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }
    }
}
