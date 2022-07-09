using DevExpress.Utils;
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
using Dominio.Models;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.frmModify;
using System.Collections.Generic;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmCliente : Form
    {
        private ClienteModel clienteModel = new ClienteModel();
        private DataView dvCliente = new DataView();
        private DirectionImage directionImage = new DirectionImage();
        private int pkCliente { get; set; }
        private string nomCliente { get; set; }

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmCliente()
        {
            InitializeComponent();
            dgCliente.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgCliente.OptionsView.EnableAppearanceEvenRow = true;
            dgCliente.OptionsSelection.EnableAppearanceFocusedRow = false;

            listar();
            addCheckbox();
        }
        private void addCheckbox()
        {
            RepositoryItemCheckEdit chkEstado = gridCliente.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstado.PictureChecked = activo;
            chkEstado.PictureUnchecked = inactivo;
            chkEstado.ValueChecked = 1;
            chkEstado.ValueUnchecked = 0;
            chkEstado.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgCliente.Columns["clieEstado"].ColumnEdit = chkEstado;
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if(pkCliente > 0)
            {
                int estado = Convert.ToInt32(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieEstado"));
                int NEstado = (estado == 1) ? 0 : 1;
               
            }
        }

        private void estiloDG()
        {
            dgCliente.Columns["pk_cliente"].Visible = false;
            dgCliente.Columns["clieNombre"].Caption = "CLIENTE";
            dgCliente.Columns["clieDireccion"].Caption = "DIRECCION";
            dgCliente.Columns["clieRucDni"].Caption = "RUC/DNI";
            dgCliente.Columns["clieEmail"].Caption = "EMAIL";
            dgCliente.Columns["clieDeuda"].Caption = "DEUDA";
            dgCliente.Columns["clieDeuda"].DisplayFormat.FormatType = FormatType.Numeric;
            dgCliente.Columns["clieDeuda"].DisplayFormat.FormatString = "c2";
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            estiloDG();
            totalRegistro();
            style st = new style();
            st.DockStyle(rDock, documentWindow4);
            cbEstado.SelectedIndex = 0;
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgCliente.DataRowCount.ToString();
        }

        //CRUD
        private void listar()
        {
            dvCliente = clienteModel.listarCliente();
            gridCliente.DataSource = dvCliente;
        }
        private void nuevo()
        {
            frmNuevoCliente newClie = new frmNuevoCliente();
            DialogResult result = newClie.ShowDialog();
            if (result == DialogResult.OK)
            {
                listar();
                totalRegistro();
                this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
            }

        }

        private void ModificarCliente()
        {
            if (pkCliente > 0)
            {
                List<object> listaCliente = new List<object>();
                for(int i = 0; i < dgCliente.Columns.Count; i++)
                {
                    listaCliente.Add(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, dgCliente.Columns[i]));
                }

                frmModificarCliente clie = new frmModificarCliente();
                clie.DatoCliente(listaCliente);
                DialogResult resultado = clie.ShowDialog();
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
        private void eliminarCliente()
        {

            if (pkCliente > 0)
            {
                frmMessageBox mb = new frmMessageBox();
                mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nomCliente, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = mb.ShowDialog();
                if (result == DialogResult.OK)
                {

                    clienteModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                    clienteModel.pk_cliente = pkCliente;
                    clienteModel.GuardarCambios();
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

        private void dgCliente_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                pkCliente = Convert.ToInt32(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "pk_cliente").ToString());
                nomCliente = dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieNombre").ToString();
            }
            else
            {
                pkCliente = 0;
            }
        }

        private void dgCliente_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender, e);
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "clieDeuda")
                {
                    int cantidad = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "clieDeuda"));
                    if (cantidad <= 10)
                        e.Appearance.BackColor = Color.FromArgb( 46, 204, 113);
                    else if (cantidad <= 50 && cantidad > 10)
                        e.Appearance.BackColor = Color.FromArgb(243, 156, 18);
                    else if (cantidad > 50)
                        e.Appearance.BackColor = Color.FromArgb(255, 25, 64);
                }

            }
        }

        private void dgCliente_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "clieEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminarCliente();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            cbEstado.SelectedIndex = 0;
            txtDni.Clear();
            txtNombre.Clear();
            listar();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {      
            dvCliente.RowFilter = (" Convert(clieRucDni, 'System.String') LIKE '" + txtDni.Text + "%'");
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvCliente.RowFilter = ("clieNombre LIKE '" + txtNombre.Text + "%'");
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvCliente.RowFilter = ("Convert(clieEstado, 'System.String') LIKE '" + estado + "%'");
            }
            
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtDni.Clear();
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtDni.Clear();
        }
    }
}
