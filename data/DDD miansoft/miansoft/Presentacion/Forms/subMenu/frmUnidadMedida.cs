using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
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
using Presentacion.Forms.frmModify;
using Presentacion.Forms.frmNew;
using Dominio.Models;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmUnidadMedida : Form
    {
        private DataView dvUnme = new DataView();
        private UnidadMedidaModel unidadMedidaModel = new UnidadMedidaModel();
        private DirectionImage directionImage = new DirectionImage();
        private int pkUnme { get; set; }
        private string nomUnme { get; set; }

        private style estilo = new style();

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmUnidadMedida()
        {
            InitializeComponent();
            dgUnidadMedida.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgUnidadMedida.OptionsView.EnableAppearanceEvenRow = true;
            listar();
            addCheckbox();
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridUnidadMedida.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgUnidadMedida.Columns["unmeEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += checkEdit_CheckedChanged;

        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (pkUnme > 0)
            {
                int estado = Convert.ToInt32(dgUnidadMedida.GetRowCellValue(dgUnidadMedida.FocusedRowHandle, "unmeEstado").ToString());
                int NEstado = (estado == 1) ? 0 : 1;
                unidadMedidaModel.ActualizarEstado(pkUnme, NEstado, "unidadMedida");
            }
        }

        private void EstiloDG()
        {
            dgUnidadMedida.Columns["pk_unidadMedida"].Visible = false;
            dgUnidadMedida.Columns["unmeNombre"].Caption = "UNIDAD MEDIDA";
            dgUnidadMedida.Columns["unmeEstado"].Caption = "ESTADO";
            dgUnidadMedida.Columns["unmeEstado"].Width = 20;
        }

        private void frmUnidadMedida_Load(object sender, EventArgs e)
        {
            estilo.DockStyle(rDock, documentWindow4);
            EstiloDG();
            cbEstado.SelectedIndex = 0;
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgUnidadMedida.DataRowCount.ToString();
        }

        //CRUD
        private void listar()
        {
            dvUnme = unidadMedidaModel.listarUnme();
            gridUnidadMedida.DataSource = dvUnme;
        }

        private void nuevo()
        {
            frmNuevoUnidadMedida newUnme = new frmNuevoUnidadMedida();
            DialogResult result = newUnme.ShowDialog();
            if (result == DialogResult.OK)
            {
                listar();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
                totalRegistro();
            }

        }

        private void Modificar()
        {
            if (pkUnme > 0)
            {
                List<object> listaUnme = new List<object>();
                for(int i = 0; i < dgUnidadMedida.Columns.Count; i++)
                {
                    listaUnme.Add(dgUnidadMedida.GetRowCellValue(dgUnidadMedida.FocusedRowHandle, dgUnidadMedida.Columns[i]));
                }

                frmModificarUnidadMedida unme = new frmModificarUnidadMedida();
                unme.datosUnme(listaUnme);
                DialogResult resultado = unme.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    listar();
                    this.Alert("Se actualizo correctamente", frmNotificaciones.estado.Success);
                }
            }
            else
            {
                this.Alert("Error selecciona un registro", frmNotificaciones.estado.Error);

            }
        }
        private void Eliminar()
        {

            if (pkUnme > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomUnme, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

            
                    this.Alert("Se elimino correctamente", frmNotificaciones.estado.Success);
                    listar();
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

        private void btNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dgUnidadMedida_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkUnme = Convert.ToInt32(dgUnidadMedida.GetRowCellValue(dgUnidadMedida.FocusedRowHandle, "pk_unidadMedida").ToString());
                nomUnme = dgUnidadMedida.GetRowCellValue(dgUnidadMedida.FocusedRowHandle, "unmeNombre").ToString();

                //Point p = this.Location;
                //p.Offset(this.Width / 2, this.Height / 2);
                //radialMenu1.ShowPopup(p);
            }
            else
            {
                pkUnme = 0;
            }
        }

        private void dgUnidadMedida_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            estilo.rowStyle(sender, e);
        }

        private void dgUnidadMedida_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "unmeEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvUnme.RowFilter = "unmeNombre LIKE '%" + txtNombre.Text + "%'";
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvUnme.RowFilter = ("Convert(unmeEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else
            {
                listar();
            }
        }
      

        private void txtNombre_Enter(object sender, EventArgs e)
        {
       
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            txtNombre.Clear();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {

            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }
    }
}
