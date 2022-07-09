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
    public partial class frmFormaPago : Form
    {
        private FormaPagoModel formaPagoModel = new FormaPagoModel();
        private style st = new style();
        private DirectionImage directionImage = new DirectionImage();
        private DataView dvFopa = new DataView();

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        private int pkFormaPago { get; set; } 
        private string fopaNombre { get; set; }
        public frmFormaPago()
        {
            InitializeComponent();
            listarFormaPago();
            addCheckbox();
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridFormaPago.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgFormaPago.Columns["fopaEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += checkEdit_CheckedChanged;

        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (pkFormaPago > 0)
            {

                int std = Convert.ToInt32(dgFormaPago.GetRowCellValue(dgFormaPago.FocusedRowHandle, "fopaEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
                formaPagoModel.actualizarEstado(pkFormaPago, estado, "formaPago");
            }

        }
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);

        }

        private void estiloDG()
        {
            dgFormaPago.Columns["pk_formaPago"].Visible = false;
            dgFormaPago.Columns["fopaNombre"].Caption = "FORMA DE PAGO";
            dgFormaPago.Columns["fopaEstado"].Caption = "ESTADO";
        }

        private void listarFormaPago()
        {
            dvFopa = formaPagoModel.listarFormPago();
            gridFormaPago.DataSource = dvFopa;
        }
        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            st.DockStyle(rDock, documentWindow4);
            estiloDG();
            cbEstado.SelectedIndex = 0;
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoFormaPago fopa = new frmNuevoFormaPago();
            DialogResult result = fopa.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarFormaPago();
                this.Alert("Se guardo correctamente", frmNotificaciones.estado.Success);
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (pkFormaPago > 0)
            {
                List<object> lista = new List<object>();
                lista.Add(dgFormaPago.GetRowCellValue(dgFormaPago.FocusedRowHandle, "pk_formaPago"));
                lista.Add(dgFormaPago.GetRowCellValue(dgFormaPago.FocusedRowHandle, "fopaNombre"));
                lista.Add(dgFormaPago.GetRowCellValue(dgFormaPago.FocusedRowHandle, "fopaEstado"));
                frmModificarFormaPago modi = new frmModificarFormaPago();
                modi.DatosFormaPago(lista);
                DialogResult resultado = modi.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarFormaPago();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (pkFormaPago > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + fopaNombre, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    formaPagoModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    formaPagoModel.pk_formaPago = pkFormaPago;
                    string rpta = formaPagoModel.GuardarCambios();
                    this.Alert(rpta, frmNotificaciones.estado.Success);
                    listarFormaPago();
                   // totalRegistro();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }

        }

        private void dgFormaPago_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(e.FocusedRowHandle >= 0)
            {
                pkFormaPago = Convert.ToInt32(dgFormaPago.GetRowCellValue(dgFormaPago.FocusedRowHandle, "pk_formaPago"));
                fopaNombre = dgFormaPago.GetRowCellValue(dgFormaPago.FocusedRowHandle, "fopaNombre").ToString();
            }
            else
            {
                pkFormaPago = 0;
            }
        }

        private void dgFormaPago_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "fopaEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgFormaPago_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            st.rowStyle(sender, e);
        }

        private void txtFormaDePago_TextChanged(object sender, EventArgs e)
        {
            cbEstado.SelectedIndex = 0;
            dvFopa.RowFilter = "fopaNombre LIKE'%" + txtFormaDePago.Text + "%'";
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtFormaDePago.Clear();
            if (cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvFopa.RowFilter = ("Convert(fopaEstado, 'System.String')  LIKE '%" + estado + "%'");
            }
            else
            {
                listarFormaPago();
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtFormaDePago.Clear();
            cbEstado.SelectedIndex = 0;
        }
    }
}
