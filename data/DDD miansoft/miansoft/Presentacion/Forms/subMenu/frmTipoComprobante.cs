using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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
using Presentacion.Forms.Main;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.frmModify;
using Dominio.Models;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmTipoComprobante : Form
    {
        private ComprobanteModel comprobanteModel = new ComprobanteModel();
        private DataView dvComprovante = new DataView();
        private DirectionImage directionImage = new DirectionImage();
        private style estilo = new style();

        private int pkComprobante { get; set; }
        private string nameComp { get; set; }
        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmTipoComprobante()
        {
            InitializeComponent();
           
            listarComprobante();

            addCheckbox();
        }

        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridComprobante.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgComprobante.Columns["comEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
          if(pkComprobante > 0)
            {
                int estado = Convert.ToInt32(dgComprobante.GetRowCellValue(dgComprobante.FocusedRowHandle, "comEstado"));
                int NEstado = (estado == 1) ? 0 : 1;
                comprobanteModel.ActualizarEstado(pkComprobante, NEstado, "comprobante");
            }
        }

        private void estiloDG()
        {
            dgComprobante.Columns["pk_comprobante"].Visible = false;
            dgComprobante.Columns["comCodigo"].Caption = "CODIGO";
            dgComprobante.Columns["comNombre"].Caption = "COMPROBANTE";
            dgComprobante.Columns["comSerie"].Caption = "SERIE";
            dgComprobante.Columns["comCorrelativo"].Caption = "CORRELATIVO";           

        }
        private void frmTipoComprobante_Load(object sender, EventArgs e)
        {
           
            estiloDG();
            totalRegistro();
           
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgComprobante.DataRowCount.ToString();
        }

        //CRUD
        private void listarComprobante()
        {
            dvComprovante = comprobanteModel.listarComprobante();
            gridComprobante.DataSource = dvComprovante;
        }

        private void nuevo()
        {
            frmNuevoComprobante newComp = new frmNuevoComprobante();
            DialogResult result = newComp.ShowDialog();
            if (result == DialogResult.OK)
            {
                listarComprobante();
                totalRegistro();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }

        }

        private void ModificarComprobante()
        {
            if (pkComprobante > 0)
            {
                List<object> listaComprobante = new List<object>();

                for(int i = 0; i < dgComprobante.Columns.Count; i++)
                {
                    listaComprobante.Add(dgComprobante.GetRowCellValue(dgComprobante.FocusedRowHandle, dgComprobante.Columns[i]));
                }
                frmModificarComprobante comp = new frmModificarComprobante();
                comp.DatoCliente(listaComprobante);
                DialogResult resultado = comp.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listarComprobante();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }
        private void eliminarComprobante()
        {

            if (pkComprobante > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nameComp, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listarComprobante();
                    totalRegistro();
                }
            }
            else
            {
                this.Alert("Selecciona un registro", frmNotificaciones.estado.Warning);
            }
        }

        //END CRUD ↑

        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void dgComprobante_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                pkComprobante = Convert.ToInt32(dgComprobante.GetRowCellValue(dgComprobante.FocusedRowHandle, "pk_comprobante").ToString());
                nameComp = dgComprobante.GetRowCellValue(dgComprobante.FocusedRowHandle, "comNombre").ToString();
            }
            else
            {
                pkComprobante = 0;
            }
        }

        private void dgComprobante_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            estilo.rowStyle(sender, e);        
        }

        private void dgComprobante_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "comEstado")
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarComprobante();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminarComprobante();
        }


        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            dvComprovante.RowFilter = "comCodigo LIKE'" + txtCodigo.Text + "%'";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvComprovante.RowFilter = "comNombre LIKE'" + txtNombre.Text + "%'";
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvComprovante.RowFilter = ("Convert(comEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else
            {
                listarComprobante();
            }
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }
    }
}
