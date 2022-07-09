using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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
using Presentacion.Forms.frmNew;
using Presentacion.Forms.subMenu;
using Presentacion.Forms.Main;
using Dominio.Models;
using Presentacion.Helps;

namespace Presentacion.Forms.frmDetails
{
    public partial class frmSeleccionarCliente : Form
    {
        private ClienteModel clienteModel = new ClienteModel();
        private DataView dvCliente = new DataView();
        private DirectionImage directionImage = new DirectionImage();

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));

        private int pk_cliente { get; set; }
        private string clieNombre { get; set; }
        public frmSeleccionarCliente()
        {
            InitializeComponent();
            dgCliente.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgCliente.OptionsView.EnableAppearanceEvenRow = true;
            listarCliente();
            createColumnButton();
            addToolBox();
        }
        private void addToolBox()
        {
            RepositoryItemCheckEdit checkEdit = gridCliente.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            checkEdit.PictureChecked = activo;
            checkEdit.PictureUnchecked = inactivo;
            checkEdit.ValueChecked = 1;
            checkEdit.ValueUnchecked = 0;
            checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgCliente.Columns["clieEstado"].ColumnEdit = checkEdit;
            checkEdit.CheckedChanged += checkEdit_CheckedChanged;
        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (pk_cliente > 0)
            {
                frmMessageBox box = new frmMessageBox();
                int estado = Convert.ToInt32(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieEstado"));
                string msg = (estado == 1) ? "Desactivar" : "Activar";
                box.MessageBox("Aviso..!!", "Estas seguro que quieres " + msg + " el estado de " + clieNombre, directionImage.nameFileImage(DirectionImage.fileImage.question));
                DialogResult result = box.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int NEstado = (estado == 1) ? 0 : 1;
                    clienteModel.ActualizarEstado(pk_cliente, NEstado, "cliente");
                    listarCliente();
                }
                else
                {
                    dgCliente.UpdateCurrentRow();
                }
            }
        }

        private void createColumnButton()
        {

            GridColumn gridColumn = dgCliente.Columns.AddVisible("SELECCIONAR", string.Empty);
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            buttonEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
            buttonEdit.Buttons[0].Image = Image.FromFile(@"recursos/img/seleccionar.png");
            buttonEdit.Buttons[0].Appearance.BackColor = Color.White;
            buttonEdit.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearanceDisabled.BorderColor = Color.White;
            buttonEdit.Buttons[0].AppearancePressed.BorderColor = Color.White;
            buttonEdit.Buttons[0].Appearance.BorderColor = Color.White;
            buttonEdit.BorderStyle = BorderStyles.UltraFlat;
            buttonEdit.ButtonClick += buttonEdit_ButtonClick;
            gridCliente.RepositoryItems.Add(buttonEdit);
            gridColumn.ColumnEdit = buttonEdit;
            gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }

        private void buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            frmVentas ventas = Owner as frmVentas;
            int pk_producto = Convert.ToInt32(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "pk_cliente"));
            double dni = Convert.ToDouble(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieRucDni"));
            string cliente = dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieNombre").ToString();
            string direccion = dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieDireccion").ToString();
            double deuda = Convert.ToDouble(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieDeuda"));
            int estado = Convert.ToInt32(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieEstado"));

            ventas.datosCliente(pk_producto,dni, cliente, direccion, deuda,estado);
            this.Close();
        }

        private void listarCliente()
        {
            dvCliente = clienteModel.listarCliente();
            gridCliente.DataSource = dvCliente;
        }

        private void estiloDG()
        {
            dgCliente.Columns["pk_cliente"].Visible = false;
            dgCliente.Columns["clieNombre"].Caption = "CLIENTE";
            dgCliente.Columns["clieDireccion"].Caption = "DIRECCION";
            dgCliente.Columns["clieRucDni"].Caption = "RUC/DNI";
            dgCliente.Columns["clieEmail"].Caption = "EMAIL";
            dgCliente.Columns["clieDeuda"].Caption = "DEUDA";
            dgCliente.Columns["clieEstado"].Caption = "ESTADO";
            dgCliente.Columns["clieDeuda"].DisplayFormat.FormatType = FormatType.Numeric;
            dgCliente.Columns["clieDeuda"].DisplayFormat.FormatString = "c2";
        }

        private void frmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            style st = new style();
            st.DockStyle(radDock1, documentWindow1);
            estiloDG();
            st.gridNavegador(gridCliente);
         
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoCliente newClie = new frmNuevoCliente();
            DialogResult result = newClie.ShowDialog();
            if(result == DialogResult.OK)
            {
                listarCliente();
            }
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            dvCliente.RowFilter = "clieNombre LIKE '%" + txtBuscarNombre.Text + "%'";
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            dvCliente.RowFilter = "Convert(clieRucDni, 'System.String') LIKE '%" + txtDni.Text + "%'";
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int posX = 0;
        int posY = 0;
        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtBuscarNombre_Enter(object sender, EventArgs e)
        {
            txtDni.Clear();
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
        }

        private void dgCliente_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style st = new style();
            st.rowStyle(sender, e);
            if (e.Column.FieldName == "SELECCIONAR")
                e.Appearance.BackColor = Color.White;
        }

        private void dgCliente_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "SELECCIONAR")
                e.Cancel = false;
            else if (view.FocusedColumn.FieldName == "clieEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgCliente_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                pk_cliente = Convert.ToInt32(dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "pk_cliente").ToString());
                clieNombre = dgCliente.GetRowCellValue(dgCliente.FocusedRowHandle, "clieNombre").ToString();
            }
            else
            {
                pk_cliente = 0;
            }
        }
    }
}
