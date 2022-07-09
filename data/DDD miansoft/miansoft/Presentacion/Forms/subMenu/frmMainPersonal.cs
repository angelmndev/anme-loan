using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using Presentacion.MyLibrary;
using System.Data;
using Dominio.Models;
using Presentacion.Forms.frmNew;
using Presentacion.Forms.Main;
using Presentacion.Forms.frmModify;
using System.Collections.Generic;
using Presentacion.Helps;

namespace Presentacion.Forms.subMenu
{
    public partial class frmMainPersonal : Form
    {
        private TurnoModel turnoModel = new TurnoModel();
        private CargoModel cargoModel = new CargoModel();
        private PersonalModel personalModel = new PersonalModel();
        System.Data.DataView dvPersonal = new System.Data.DataView();
        private DirectionImage directionImage = new DirectionImage();

        private int pkPersonal { get; set; }
        private int pkTurno { get; set; }
        private int pkCargo { get; set; }
        private string namePersonal { get; set; }
        private string nameTurno { get; set; }
        private string nameCargo { get; set; }

        private Image activo = new Bitmap(Image.FromFile(@"recursos/img/check.png"));
        private Image inactivo = new Bitmap(Image.FromFile(@"recursos/img/not.png"));
        public frmMainPersonal()
        {
            InitializeComponent();
            colorRow();

            listarPersonal();
            addCheckboxPers();
            gridCargo.DataSource = cargoModel.listarCargo();
            addCheckboxCarg();
            gridTurno.DataSource = turnoModel.listarTurno();
            addCheckboxTurn();
        }

        private void listarPersonal()
        {
            dvPersonal = personalModel.listarPersonal();
            gridPersonal.DataSource = dvPersonal;
        }

        private void colorRow()
        {
            dgPersonal.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgPersonal.OptionsView.EnableAppearanceEvenRow = true;
            dgTurno.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgTurno.OptionsView.EnableAppearanceEvenRow = true;
            dgCargo.Appearance.EvenRow.BackColor = Color.FromArgb(224, 224, 224);
            dgCargo.OptionsView.EnableAppearanceEvenRow = true;

        }
        private void addCheckboxPers()
        {
            RepositoryItemCheckEdit chkEstadoPers = gridPersonal.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstadoPers.PictureChecked = activo;
            chkEstadoPers.PictureUnchecked = inactivo;
            chkEstadoPers.ValueChecked = 1;
            chkEstadoPers.ValueUnchecked = 0;
            chkEstadoPers.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgPersonal.Columns["persEstado"].ColumnEdit = chkEstadoPers;
            chkEstadoPers.CheckedChanged += chkEstadoPers_CheckedChanged;
        }
        private void chkEstadoPers_CheckedChanged(object sender, EventArgs e)
        {
            if (pkPersonal > 0)
            {
                int std = Convert.ToInt32(dgPersonal.GetRowCellValue(dgPersonal.FocusedRowHandle, "persEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
                personalModel.ActualizarEstado(pkPersonal, estado, "personal");
            }

        }

        private void addCheckboxCarg()
        {
            RepositoryItemCheckEdit chkEstadoCarg = gridPersonal.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstadoCarg.PictureChecked = activo;
            chkEstadoCarg.PictureUnchecked = inactivo;
            chkEstadoCarg.ValueChecked = 1;
            chkEstadoCarg.ValueUnchecked = 0;
            chkEstadoCarg.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgCargo.Columns["cargEstado"].ColumnEdit = chkEstadoCarg;
            chkEstadoCarg.CheckedChanged += chkEstadoCarg_CheckedChanged;
        }

        private void chkEstadoCarg_CheckedChanged(object sender, EventArgs e)
        {
            if (pkCargo > 0)
            {
                int std = Convert.ToInt32(dgCargo.GetRowCellValue(dgCargo.FocusedRowHandle, "cargEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
                cargoModel.ActualizarEstado(pkCargo, estado, "cargo");
            }
        }

        private void addCheckboxTurn()
        {
            RepositoryItemCheckEdit chkEstadoTurn = gridPersonal.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            chkEstadoTurn.PictureChecked = activo;
            chkEstadoTurn.PictureUnchecked = inactivo;
            chkEstadoTurn.ValueChecked = 1;
            chkEstadoTurn.ValueUnchecked = 0;
            chkEstadoTurn.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            dgTurno.Columns["turnEstado"].ColumnEdit = chkEstadoTurn;
            chkEstadoTurn.CheckedChanged += chkEstadoTurn_CheckedChanged;
        }

        private void chkEstadoTurn_CheckedChanged(object sender, EventArgs e)
        {
            if (pkTurno > 0)
            {
                int std = Convert.ToInt32(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, "turnEstado").ToString());
                int estado = (std == 1) ? 0 : 1;
                turnoModel.ActualizarEstado(pkTurno, estado, "turno");
            }
        }


        private enum tabla{personal, turno,cargo}
        private void DockStyle(RadDock nombre)
        {
            foreach (DockWindow item in nombre.DockWindows)
            {
                if (item is DocumentWindow)
                {
                    item.DocumentButtons = DocumentStripButtons.ActiveWindowList;
                }
            }
            documentWindow4.AllowedDockState = AllowedDockState.TabbedDocument;
        }

        private void estiloDG()
        {
            dgCargo.Columns["pk_cargo"].Visible = false;
            dgCargo.Columns["cargNombre"].Caption = "CARGO";
            dgCargo.Columns["cargEstado"].Caption = "ESTADO";
            dgCargo.Columns["cargEstado"].Width = 30;

            dgTurno.Columns["pk_turno"].Visible = false;
            dgTurno.Columns["turnNombre"].Caption = "TURNO";
            dgTurno.Columns["turnHentrada"].Caption = "H. ENTRADA";
            dgTurno.Columns["turnHsalida"].Caption = "H. SALIDA";
            dgTurno.Columns["turnEstado"].Caption = "ESTADO";

            dgPersonal.Columns["pk_personal"].Visible = false;
            dgPersonal.Columns["persNombre"].Caption = "NOMBRE";
            dgPersonal.Columns["persApellido"].Caption = "APELLIDO";
            dgPersonal.Columns["persDireccion"].Caption = "DIRECCION";
            dgPersonal.Columns["persDni"].Caption = "DNI";
            dgPersonal.Columns["persSexo"].Caption = "SEXO";
            dgPersonal.Columns["persFechaNac"].Caption = "FECHA NAC.";
            dgPersonal.Columns["persEmail"].Caption = "CORREO";
            dgPersonal.Columns["persTelefono"].Caption = "TELEFONO";
            dgPersonal.Columns["persEstado"].Caption = "ESTADO";
            dgPersonal.Columns["fk_cargo"].Visible = false;
            dgPersonal.Columns["fk_turno"].Visible = false;

            dgPersonal.Columns["persEstado"].Width = 30;
        }

        //LISTAR
        private void FrmPersonal_Load(object sender, EventArgs e)
        {
            DockStyle(rDock);         
            estiloDG();
            cbTablas.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            totalRegistro();
        }
        private void totalRegistro()
        {
            //lbTotalRegistro.Text = "Total de registro: " + dgPersonal.DataRowCount.ToString();
        }
        private void listar(tabla nombre)
        {
            switch (nombre)
            {
                case tabla.personal:
                    gridPersonal.DataSource = personalModel.listarPersonal();
                    break;
                case tabla.cargo:
                    gridCargo.DataSource = cargoModel.listarCargo();
                    break;
                case tabla.turno:
                    gridTurno.DataSource = turnoModel.listarTurno();
                    break;
            }
        }          

        //NUEVO
        private void nuevo()
        {
            switch (cbTablas.Text)
            {
                case "Personal":
                    frmNuevoPersonal newPers = new frmNuevoPersonal();
                    DialogResult result = newPers.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        listar(tabla.personal);
                        totalRegistro();
                        this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
                    }
                    break;
                case "Turno":
                    frmNuevoTurno newTurno = new frmNuevoTurno();
                    DialogResult resultT = newTurno.ShowDialog();
                    if (resultT == DialogResult.OK)
                    {
                        listar(tabla.turno);
                        this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
                    }
                    break;
                case "Cargo":
                    frmNuevoCargo newCargo = new frmNuevoCargo();
                    DialogResult resultC = newCargo.ShowDialog();
                    if (resultC == DialogResult.OK)
                    {
                        listar(tabla.cargo);
                        this.Alert("Se guardo correctamente ", frmNotificaciones.estado.Success);
                    }
                    break;
            }
        }

        private void eliminar()
        {
            string smsEror = "Selecciona un registro";
            string rspta;
            switch (cbTablas.Text)
            {
                case "Personal":
                    if (pkPersonal > 0)
                    {
                        frmMessageBox mb = new frmMessageBox();
                        mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + namePersonal, directionImage.nameFileImage(DirectionImage.fileImage.danger));
                        DialogResult result = mb.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            personalModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                            personalModel.Pk_personal = pkPersonal;
                            rspta = personalModel.GuardarCambios();
                            this.Alert(rspta, frmNotificaciones.estado.Success);
                            listar(tabla.personal);
                            totalRegistro();
                        }
                    }
                    else
                    {
                        this.Alert(smsEror, frmNotificaciones.estado.Warning);
                    }
                    break;
                case "Turno":
                    if (pkTurno > 0)
                    {
                        frmMessageBox mb = new frmMessageBox();
                        mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nameTurno, directionImage.nameFileImage(DirectionImage.fileImage.question));
                        DialogResult result = mb.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            turnoModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                            turnoModel.Pk_turno = pkTurno;
                            rspta = turnoModel.GuardarCambios();
                            this.Alert(rspta, frmNotificaciones.estado.Success);
                            listar(tabla.turno);
                        }
                    }
                    else
                    {
                        this.Alert(smsEror, frmNotificaciones.estado.Warning);
                    }
                    break;
                case "Cargo":
                    if (pkCargo > 0)
                    {
                        frmMessageBox mb = new frmMessageBox();
                        mb.MessageBox("Informacion importante", "Estas seguro que quieres eliminar " + nameCargo, directionImage.nameFileImage(DirectionImage.fileImage.question));
                        DialogResult result = mb.ShowDialog();
                        if (result == DialogResult.OK)
                        {

                            cargoModel.estado = Dominio.ObjetoValor.EstadoEntidad.eliminar;
                            cargoModel.Pk_cargo = pkCargo;
                            rspta = cargoModel.GardarCambios();
                            this.Alert(rspta, frmNotificaciones.estado.Success);
                            listar(tabla.cargo);
                        }
                    }
                    else
                    {
                        this.Alert(smsEror, frmNotificaciones.estado.Warning);
                    }
                    break;
            }

        }

        private void modificar()
        {
            string smsEror = "Selecciona un registro";
            string success = "Se actualizo correctamente";
            switch (cbTablas.Text)
            {
                case "Personal":
                    if (pkPersonal > 0)
                    {
                        List<object> listaPersonal = new List<object>();
                        for(int i =0; i < dgPersonal.Columns.Count; i++)
                        {
                            listaPersonal.Add(dgPersonal.GetRowCellValue(dgPersonal.FocusedRowHandle, dgPersonal.Columns[i]));
                        }

                        frmModificarPersonal modi = new frmModificarPersonal();
                        modi.datosPersonal(listaPersonal);
                        DialogResult resultado = modi.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            listar(tabla.personal);
                            this.Alert(success, frmNotificaciones.estado.Success);
                        }
                    }
                    else
                    {
                        this.Alert(smsEror,frmNotificaciones.estado.Error);

                    }
                    break;
                case "Turno":
                    if (pkTurno > 0)
                    {
                        List<object> listaTurno = new List<object>();
                        //listaTurno.Add(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, dgTurno.Columns[0]));
                        //listaTurno.Add(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, dgTurno.Columns[1]));
                        //listaTurno.Add(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, dgTurno.Columns[2]));
                        //listaTurno.Add(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, dgTurno.Columns[3]));
                        //listaTurno.Add(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, dgTurno.Columns[4]));
                        for (int i = 0; i < dgTurno.Columns.Count; i++)
                        {
                            listaTurno.Add(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, dgTurno.Columns[i]));
                        }

                        frmModificarTurno modi = new frmModificarTurno();
                        modi.datosTurno(listaTurno);
                        DialogResult resultado = modi.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            listar(tabla.turno);
                            this.Alert(success, frmNotificaciones.estado.Success);
                        }
                    }
                    else
                    {
                        this.Alert(smsEror, frmNotificaciones.estado.Error);

                    }
                    break;
                case "Cargo":
                    if (pkCargo > 0)
                    {
                        List<object> listaCargo = new List<object>();
                        listaCargo.Add(dgCargo.GetRowCellValue(dgCargo.FocusedRowHandle, "pk_cargo"));
                        listaCargo.Add(dgCargo.GetRowCellValue(dgCargo.FocusedRowHandle, "cargNombre"));
                        listaCargo.Add(dgCargo.GetRowCellValue(dgCargo.FocusedRowHandle, "cargEstado"));
                        frmModificarCargo modi = new frmModificarCargo();
                        modi.datosCargo(listaCargo);
                        DialogResult resultado = modi.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            listar(tabla.cargo);
                            this.Alert(success, frmNotificaciones.estado.Success);
                        }
                    }
                    else
                    {
                        this.Alert(smsEror, frmNotificaciones.estado.Error);

                    }
                    break;
            }
        }
        private void btNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void dgCargo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender, e);
        }

        private void dgPersonal_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender, e);
        }

        private void dgTurno_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            style estilo = new style();
            estilo.rowStyle(sender, e);
        }

        //ACTIVAR NOTIFICACIONES
        public void Alert(string message, frmNotificaciones.estado std)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.showAlert(message, std);
        }

        private void dgPersonal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {   
            if (e.FocusedRowHandle >= 0)
            {
                pkPersonal = Convert.ToInt32(dgPersonal.GetRowCellValue(dgPersonal.FocusedRowHandle, "pk_personal").ToString());
                namePersonal = dgPersonal.GetRowCellValue(dgPersonal.FocusedRowHandle, "persNombre").ToString();
            }
            else
            {
                pkPersonal = 0;
            }
                    
        }

        private void dgCargo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (e.FocusedRowHandle >= 0)
            {
                pkCargo = Convert.ToInt32(dgCargo.GetRowCellValue(dgCargo.FocusedRowHandle, "pk_cargo").ToString());
                nameCargo = dgCargo.GetRowCellValue(dgCargo.FocusedRowHandle, "cargNombre").ToString();
            }
            else
            {
                pkCargo = 0;
            }

        }

        private void dgTurno_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {

                pkTurno = Convert.ToInt32(dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, "pk_turno").ToString());
                nameTurno = dgTurno.GetRowCellValue(dgTurno.FocusedRowHandle, "turnNombre").ToString();

                //Point p = this.Location;
                //p.Offset(this.Width / 2, this.Height / 2);
                //radialMenu1.ShowPopup(p);
            }
            else
            {
                pkTurno = 0;
            }

        }

        private void dgPersonal_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "persEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgCargo_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "cargEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void dgTurno_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "turnEstado")
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void cbTablas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
   
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            dvPersonal.RowFilter = ("Convert(persDni, 'System.String') LIKE '" + txtDni.Text + "%'");
        }

        private void cbEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if(cbEstado.Text != "Selecciona")
            {
                int estado = (cbEstado.Text == "Activo") ? 1 : 0;
                dvPersonal.RowFilter = ("Convert(persEstado, 'System.String') LIKE '" + estado + "%'");
            }
            else
            {
                listarPersonal();
            }
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            cbEstado.SelectedIndex = 0;
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            txtDni.Clear();
        }
    }
}
