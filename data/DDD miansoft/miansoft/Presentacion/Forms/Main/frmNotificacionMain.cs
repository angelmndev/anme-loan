using Dominio.Models;
using Presentacion.Forms.subMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Presentacion.Forms.Main
{
    public partial class frmNotificacionMain : Form
    {
        private MainModel mainModel = new MainModel();
        public frmNotificacionMain()
        {
            InitializeComponent();
        }
        public void Notificaciones()
        {
            //0=>Obtenemos alerta de fecha de vencimiento
            //1=>Obtenemos alerta de stock minimo
        }
        private void listarStockMin()
        {
            dgStockMin.DataSource = mainModel.AlertaStock(1);
        }

        private void listarFechaVencimeintoPasado()
        {
            dgFechaVencimiento.DataSource = mainModel.AlertaFechaVencimiento(0);
        }

        private void EstiloDG()
        {
            dgStockMin.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            dgFechaVencimiento.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            dgStockMin.AllowAddNewRow = false;
            dgFechaVencimiento.AllowAddNewRow = false;

            dgStockMin.Columns["prodStkMin"].IsVisible = false;
            dgStockMin.Columns["prodCantidad"].Width = 30;
            dgStockMin.Columns["prodStkMin"].Width = 30;
            dgStockMin.Columns["prodDescripcion"].Width = 120;
            dgStockMin.TableElement.RowHeight = 25;
            dgStockMin.ReadOnly = true;

            //Fecha vencimeinto
            dgFechaVencimiento.Columns["prodCantidad"].Width = 30;
            dgFechaVencimiento.Columns["prodFechaVencimiento"].Width = 40;
            dgFechaVencimiento.Columns["prodDescripcion"].Width = 120;
            dgFechaVencimiento.TableElement.RowHeight = 25;
            dgFechaVencimiento.ReadOnly = true;
        }
        private void frmNotificacionMain_Load(object sender, EventArgs e)
        {
          
            Notificaciones();
            listarStockMin();
            listarFechaVencimeintoPasado();
            EstiloDG();
        }

        private int _posX = 0;
        private int _posY = 0;
        private void frmNotificacionMain_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                _posX = e.X;
                _posY = e.Y;
            }
            else
            {
                Left += (e.X - _posX);
                Top += (e.Y - _posY);
            }
        }

        private void dgStockMin_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            
        }

        private int posX = 0;
        private int posY = 0;
        public void showAlert()//Muestra el formulario actual 
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string formName;

            for (int i = 1; i < 10; i++)
            {
                formName = "alert" + i.ToString();
                frmNotificacionMain frm = (frmNotificacionMain)Application.OpenForms[formName];

                if (frm == null)
                {
                    this.Name = formName;
                    this.posX = Screen.PrimaryScreen.WorkingArea.Width - Screen.PrimaryScreen.WorkingArea.Width/2-Width/2;
                    this.posY = Screen.PrimaryScreen.WorkingArea.Height - Screen.PrimaryScreen.WorkingArea.Height;
                    this.Location = new Point(this.posX, this.posY);
                    break;
                }
            }

            this.posX = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            this.action = enumAction.start;
            this.Show();
            this.timer.Interval = 1;
            timer.Start();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            action = enumAction.close;
        }

        public enum enumAction
        {
            start,
            close
        }
        private enumAction action;


        private void timer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enumAction.start:
                    timer.Interval = 1;
                    this.Opacity += 0.1;
                    if (Location.Y < 60)
                    {
                        this.Top += 3;
                    }
                    break;
                case enumAction.close:
                    this.Opacity -= 0.1;
                    this.Top -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void frmNotificacionMain_Deactivate(object sender, EventArgs e)
        {
            action = enumAction.close;
        }

        private void dgStockMin_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void dgStockMin_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            frmCompras compras = new frmCompras();
            frmMain main = Owner as frmMain;
            if (main.pnWrap.Controls.Count > 0)
                main.pnWrap.Controls.RemoveAt(0);
            compras.FormBorderStyle = FormBorderStyle.None;
            compras.TopLevel = false;
            compras.Dock = DockStyle.Fill;
            main.pnWrap.Controls.Add(compras);
            compras.Show();
        }
    }
}
