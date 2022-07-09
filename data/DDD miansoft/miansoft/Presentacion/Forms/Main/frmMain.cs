using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BunifuAnimatorNS;
using DevExpress.Data;
using DevExpress.XtraSplashScreen;
using Dominio.Models;
using FontAwesome.Sharp;
using Presentacion.Forms.frmDetails;
using Presentacion.Forms.Reports;
using Presentacion.Forms.subMenu;
using Soporte.Cache;

namespace Presentacion.Forms.Main
{
    public partial class frmMain : Form
    {
        private MainModel mainModel = new MainModel();
        public frmMain()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION 
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

                SolidBrush blueBrush = new SolidBrush(Color.Transparent);
                e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
                base.OnPaint(e);
                ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
          
           
        }

        /*************************************************************************************/

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void inicializarPNNav()
        {
            pnAlmacen.Height = 0;
            pnCotizacion.Height = 0;
            pnCompras.Height = 0;
            pnCaja.Height = 0;
            pnVentas.Height = 0;
            pnApartado.Height = 0;
            pnVentaCredito.Height = 0;
            pnInventario.Height = 0;
            pnComprobante.Height = 0;
            pnUsuario.Height = 0;
            pnParametros.Height = 0;
        }

        public void Notificaciones()
        {
            //0=>Obtenemos alerta de fecha de vencimiento
            //1=>Obtenemos alerta de stock minimo

            int contadorStockMin = mainModel.stockMin(1);
            int contadorFV = mainModel.fechaVencimiento(0);            

            int contador = 0;

            if (contadorStockMin != 0)
                contador = contador + 1;
            if (contadorFV != 0)
                contador = contador + 1;

            btNotificacion.Text = contador.ToString();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            inicializarPNNav();
            btMaximizar.Visible = false;
            Notificaciones();
            UserData();
        }

        private void UserData()
        {
            //lbNombreUsuario.Text = UserCache.usuaNombre + "" + UserCache.usuaApellido;
            //if (UserCache.usuaFoto == "imgDoont.png" && UserCache.usuaSexo == "Masculino")
            //    pbFotoUsuario.Image = Image.FromFile(@"recursos/Usuario/men.png");
            //else if (UserCache.usuaFoto == "imgDoont.png" && UserCache.usuaSexo == "Femenino")
            //    pbFotoUsuario.Image = Image.FromFile(@"recursos/Usuario/woman.png");
            //else
            //{
            //    pbFotoUsuario.Image = Image.FromFile(@"recursos/Usuario/" + UserCache.usuaFoto);
            //}
        }
        protected enum nombreButton
        {
            dashboard, almacen, cotizacion, compras, caja, ventas, apartado, ventaCredito,
            inventario, comprobante, usuario, parametros, configuracion, cerrarSesion
        }

        private void estiloButton(nombreButton NButton)
        {
            switch (NButton)
            {
                case nombreButton.almacen:
                    if (pnAlmacen.Height == 0)
                    {
                        pnAlmacen.Height = 210;
                        btIconAlmacen.IconChar = IconChar.AngleDoubleDown;

                    }
                    else if (pnAlmacen.Height == 210)
                    {
                        pnAlmacen.Height = 0;
                        btIconAlmacen.IconChar = IconChar.AngleDoubleLeft;

                    }
                    break;
                case nombreButton.cotizacion:
                    if (pnCotizacion.Height == 0)
                    {
                        pnCotizacion.Height = 60;
                        btIconCotizacion.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnCotizacion.Height == 60)
                    {
                        pnCotizacion.Height = 0;
                        btIconCotizacion.IconChar = IconChar.AngleDoubleLeft;
                    }

                    break;
                case nombreButton.compras:
                    if (pnCompras.Height == 0)
                    {
                        pnCompras.Height = 150;
                        btIconCompras.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnCompras.Height == 150)
                    {
                        pnCompras.Height = 0;
                        btIconCompras.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.caja:
                    if (pnCaja.Height == 0)
                    {
                        pnCaja.Height = 60;
                        btIconCaja.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnCaja.Height == 60)
                    {
                        pnCaja.Height = 0;
                        btIconCaja.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.ventas:
                    if (pnVentas.Height == 0)
                    {
                        pnVentas.Height = 150;
                        btIconVentas.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnVentas.Height == 150)
                    {
                        pnVentas.Height = 0;
                        btIconVentas.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.apartado:
                    if (pnApartado.Height == 0)
                    {
                        pnApartado.Height = 120;
                        btIconApartado.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnApartado.Height == 120)
                    {
                        pnApartado.Height = 0;
                        btIconApartado.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.ventaCredito:
                    if (pnVentaCredito.Height == 0)
                    {
                        pnVentaCredito.Height = 30;
                        btIconVentaCredito.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnVentaCredito.Height == 30)
                    {
                        pnVentaCredito.Height = 0;
                        btIconVentaCredito.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.inventario:
                    if (pnInventario.Height == 0)
                    {
                        pnInventario.Height = 60;
                        btIconInventario.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnInventario.Height == 60)
                    {
                        pnInventario.Height = 0;
                        btIconInventario.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.comprobante:
                    if (pnComprobante.Height == 0)
                    {
                        pnComprobante.Height = 60;
                        btIconComprobante.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnComprobante.Height == 60)
                    {
                        pnComprobante.Height = 0;
                        btIconComprobante.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.usuario:
                    if (pnUsuario.Height == 0)
                    {
                        pnUsuario.Height = 60;
                        btIconUsuario.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnUsuario.Height == 60)
                    {
                        pnUsuario.Height = 0;
                        btIconUsuario.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
                case nombreButton.parametros:
                    if (pnParametros.Height == 0)
                    {
                        pnParametros.Height = 90;
                        btIconParametros.IconChar = IconChar.AngleDoubleDown;
                    }
                    else if (pnParametros.Height == 90)
                    {
                        pnParametros.Height = 0;
                        btIconParametros.IconChar = IconChar.AngleDoubleLeft;
                    }
                    break;
            }
        }

        private void colorInactivoButton()
        {
            btDashboard.ForeColor = Color.White;
            btAlmacen.ForeColor = Color.White;
            btCotizacion.ForeColor = Color.White;
            btCompras.ForeColor = Color.White;
            btCaja.ForeColor = Color.White;
            btVentas.ForeColor = Color.White;
            btApartado.ForeColor = Color.White;
            btVentasCredito.ForeColor = Color.White;
            btInventario.ForeColor = Color.White;
            btComprobante.ForeColor = Color.White;
            btUsuario.ForeColor = Color.White;
            btParametros.ForeColor = Color.White;
            btConfiguracion.ForeColor = Color.White;
            btCerrarSesion.ForeColor = Color.White;

            btIconAlmacen.IconColor = Color.White;
            btIconCotizacion.IconColor = Color.White;
            btIconCompras.IconColor = Color.White;
            btIconCaja.IconColor = Color.White;
            btIconVentas.IconColor = Color.White;
            btIconApartado.IconColor = Color.White;
            btIconVentaCredito.IconColor = Color.White;
            btIconInventario.IconColor = Color.White;
            btIconComprobante.IconColor = Color.White;
            btIconUsuario.IconColor = Color.White;
            btIconParametros.IconColor = Color.White;

        }
        private void btAlmacen_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.almacen);
            colorInactivoButton();
            btAlmacen.ForeColor = Color.Red;
            btIconAlmacen.IconColor = Color.Red;

        }

        private void btCotizacion_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.cotizacion);
            colorInactivoButton();
            btCotizacion.ForeColor = Color.Red;
            btIconCotizacion.IconColor = Color.Red;
        }

        private void btCompras_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.compras);
            colorInactivoButton();
            btCompras.ForeColor = Color.Red;
            btIconCompras.IconColor = Color.Red;

        }

        private void btCaja_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.caja);
            colorInactivoButton();
            btCaja.ForeColor = Color.Red;
            btIconCaja.IconColor = Color.Red;
        }

        private void btVentas_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.ventas);
            colorInactivoButton();
            btVentas.ForeColor = Color.Red;
            btIconVentas.IconColor = Color.Red;
        }

        private void btApartado_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.apartado);
            colorInactivoButton();
            btApartado.ForeColor = Color.Red;
            btIconApartado.IconColor = Color.Red;
        }

        private void btVentasCredito_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.ventaCredito);
            colorInactivoButton();
            btVentasCredito.ForeColor = Color.Red;
            btIconVentaCredito.IconColor = Color.Red;
        }

        private void btInventario_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.inventario);
            colorInactivoButton();
            btInventario.ForeColor = Color.Red;
            btIconInventario.IconColor = Color.Red;
        }

        private void btComprobante_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.comprobante);
            colorInactivoButton();
            btComprobante.ForeColor = Color.Red;
            btIconComprobante.IconColor = Color.Red;
        }
        private void btUsuario_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.usuario);
            colorInactivoButton();
            btUsuario.ForeColor = Color.Red;
            btIconUsuario.IconColor = Color.Red;
        }

        private void btParametros_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.parametros);
            colorInactivoButton();
            btParametros.ForeColor = Color.Red;
            btIconParametros.IconColor = Color.Red;
        }
        private void btConfiguracion_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.configuracion);
            colorInactivoButton();
            btConfiguracion.ForeColor = Color.Red;


        }

        private void btCerrarSesion_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.cerrarSesion);
            colorInactivoButton();
            btCerrarSesion.ForeColor = Color.Red;
            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            this.Close();
        }

        //hover y leave button 

        private void btIconVentas_MouseHover(object sender, EventArgs e)
        {
            //btIconVentas.IconColor = Color.Red;
        }

        private void btIconVentas_MouseLeave(object sender, EventArgs e)
        {
            //btIconVentas.IconColor = Color.White;
        }

        //icono de flechas
        private void BtDashboard_Click(object sender, EventArgs e)
        {
            //estiloButton(nombreButton.dashboard);
            //colorInactivoButton();
            //btDashboard.ForeColor = Color.Red;

            //frmDashboard dashboard = new frmDashboard();
            //mostrarFormulario(dashboard);
            //procesandoFRM();

        }
        private void btIconAlmacen_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.almacen);
            colorInactivoButton();
            btAlmacen.ForeColor = Color.Red;
            btIconAlmacen.IconColor = Color.Red;
        }

        private void btIconCotizacion_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.cotizacion);
            colorInactivoButton();
            btCotizacion.ForeColor = Color.Red;
            btIconCotizacion.IconColor = Color.Red;
        }

        private void btIconCompras_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.compras);
            colorInactivoButton();
            btCompras.ForeColor = Color.Red;
            btIconCompras.IconColor = Color.Red;
        }

        private void btIconCaja_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.caja);
            colorInactivoButton();
            btCaja.ForeColor = Color.Red;
            btIconCaja.IconColor = Color.Red;
        }

        private void btIconVentas_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.ventas);
            colorInactivoButton();
            btVentas.ForeColor = Color.Red;
            btIconVentas.IconColor = Color.Red;
        }

        private void btIconApartado_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.apartado);
            colorInactivoButton();
            btApartado.ForeColor = Color.Red;
            btIconApartado.IconColor = Color.Red;
        }

        private void btIconVentaCredito_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.ventaCredito);
            colorInactivoButton();
            btVentasCredito.ForeColor = Color.Red;
            btIconVentaCredito.IconColor = Color.Red;
        }

        private void btIconInventario_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.inventario);
            colorInactivoButton();
            btInventario.ForeColor = Color.Red;
            btIconInventario.IconColor = Color.Red;
        }

        private void btIconComprobante_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.comprobante);
            colorInactivoButton();
            btComprobante.ForeColor = Color.Red;
            btIconComprobante.IconColor = Color.Red;
        }

        private void btIconUsuario_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.usuario);
            colorInactivoButton();
            btUsuario.ForeColor = Color.Red;
            btIconUsuario.IconColor = Color.Red;
        }

        private void btIconParametros_Click(object sender, EventArgs e)
        {
            estiloButton(nombreButton.parametros);
            colorInactivoButton();
            btParametros.ForeColor = Color.Red;
            btIconParametros.IconColor = Color.Red;
        }

        private void btSidebar_Click(object sender, EventArgs e)
        {
            if (pnNav.Width == 208)
            {
                pnNav.Width = 0;
            }
            else if (pnNav.Width == 0)
            {
                pnNav.Width = 208;
            }
        }

        //Mouse Hover
        private void btAlmacen_MouseHover(object sender, EventArgs e)
        {
            btIconAlmacen.IconColor = Color.Red;
        }

        private void btAlmacen_MouseLeave(object sender, EventArgs e)
        {
            if (btIconAlmacen.IconChar == IconChar.AngleDoubleDown)
                btIconAlmacen.IconColor = Color.Red;
            else if (btIconAlmacen.IconChar == IconChar.AngleDoubleLeft)
                btIconAlmacen.IconColor = Color.White;
        }

        private void btApartado_MouseHover(object sender, EventArgs e)
        {
            btIconApartado.IconColor = Color.Red;
        }

        private void btApartado_MouseLeave(object sender, EventArgs e)
        {
            if (btIconApartado.IconChar == IconChar.AngleDoubleDown)
                btIconApartado.IconColor = Color.Red;
            else if (btIconApartado.IconChar == IconChar.AngleDoubleLeft)
                btIconApartado.IconColor = Color.White;
        }

        private void btVentasCredito_MouseHover(object sender, EventArgs e)
        {
            btIconVentaCredito.IconColor = Color.Red;
        }

        private void btVentasCredito_MouseLeave(object sender, EventArgs e)
        {
            if (btIconVentaCredito.IconChar == IconChar.AngleDoubleDown)
                btIconVentaCredito.IconColor = Color.Red;
            else if (btIconVentaCredito.IconChar == IconChar.AngleDoubleLeft)
                btIconVentaCredito.IconColor = Color.White;
        }

        private void btInventario_MouseHover(object sender, EventArgs e)
        {
            btIconInventario.IconColor = Color.Red;
        }

        private void btInventario_MouseLeave(object sender, EventArgs e)
        {
            if (btIconInventario.IconChar == IconChar.AngleDoubleDown)
                btIconInventario.IconColor = Color.Red;
            else if (btIconInventario.IconChar == IconChar.AngleDoubleLeft)
                btIconInventario.IconColor = Color.White;
        }

        private void btComprobante_MouseHover(object sender, EventArgs e)
        {
            btIconComprobante.IconColor = Color.Red;
        }

        private void btComprobante_MouseLeave(object sender, EventArgs e)
        {
            if (btIconComprobante.IconChar == IconChar.AngleDoubleDown)
                btIconComprobante.IconColor = Color.Red;
            else if (btIconComprobante.IconChar == IconChar.AngleDoubleLeft)
                btIconComprobante.IconColor = Color.White;
        }

        private void btUsuario_MouseHover(object sender, EventArgs e)
        {
            btIconUsuario.IconColor = Color.Red;
        }

        private void btUsuario_MouseLeave(object sender, EventArgs e)
        {
            if (btIconUsuario.IconChar == IconChar.AngleDoubleDown)
                btIconUsuario.IconColor = Color.Red;
            else if (btIconUsuario.IconChar == IconChar.AngleDoubleLeft)
                btIconUsuario.IconColor = Color.White;
        }

        private void btParametros_MouseHover(object sender, EventArgs e)
        {
            btIconParametros.IconColor = Color.Red;
        }

        private void btParametros_MouseLeave(object sender, EventArgs e)
        {
            if (btIconParametros.IconChar == IconChar.AngleDoubleDown)
                btIconParametros.IconColor = Color.Red;
            else if (btIconParametros.IconChar == IconChar.AngleDoubleLeft)
                btIconParametros.IconColor = Color.White;
        }

        private void btCotizacion_MouseHover(object sender, EventArgs e)
        {
            btIconCotizacion.IconColor = Color.Red;
        }

        private void btCotizacion_MouseLeave(object sender, EventArgs e)
        {
            if (btIconCotizacion.IconChar == IconChar.AngleDoubleDown)
                btIconCotizacion.IconColor = Color.Red;
            else if (btIconCotizacion.IconChar == IconChar.AngleDoubleLeft)
                btIconCotizacion.IconColor = Color.White;
        }

        private void btCompras_MouseHover(object sender, EventArgs e)
        {
            btIconCompras.IconColor = Color.Red;
        }

        private void btCompras_MouseLeave(object sender, EventArgs e)
        {
            if (btIconCompras.IconChar == IconChar.AngleDoubleDown)
                btIconCompras.IconColor = Color.Red;
            else if (btIconCompras.IconChar == IconChar.AngleDoubleLeft)
                btIconCompras.IconColor = Color.White;
        }

        private void btCaja_MouseHover(object sender, EventArgs e)
        {
            btIconCaja.IconColor = Color.Red;

        }

        private void btCaja_MouseLeave(object sender, EventArgs e)
        {

            if (btIconCaja.IconChar == IconChar.AngleDoubleDown)
                btCaja.ForeColor = Color.Red;
            else if (btIconCaja.IconChar == IconChar.AngleDoubleLeft)
                btIconCaja.IconColor = Color.White;

        }

        private void btVentas_MouseHover(object sender, EventArgs e)
        {
            btIconVentas.IconColor = Color.Red;

        }

        private void btVentas_MouseLeave(object sender, EventArgs e)
        {
            if (btIconVentas.IconChar == IconChar.AngleDoubleDown)
                btIconVentas.IconColor = Color.Red;
            else if (btIconVentas.IconChar == IconChar.AngleDoubleLeft)
                btIconVentas.IconColor = Color.White;
        }


        private void BtNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btMaximizar.Visible = true;
            btNormal.Visible = false;
        }

        private void BtCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// submenu
        /// </summary>
        /// 
        private void limpiarPanelWrap()
        {
            if (pnWrap.Controls.Count > 0)
                pnWrap.Controls.RemoveAt(0);
        }
        private void BtProducto_Click(object sender, EventArgs e)
        {
            lbItems.Text = "Almacen | Productos";
            lbItems.IconChar = IconChar.DiceD6;
            limpiarPanelWrap();
            procesandoFRM();
            frmProducto producto = new frmProducto();
            if (producto.Size.Width > Size.Width || producto.Size.Height > Size.Height)
            {
                Size = new Size(producto.Width + btProducto.Size.Width, producto.Height + btProducto.Size.Height);
            }

            producto.FormBorderStyle = FormBorderStyle.None;
            producto.TopLevel = false;
            producto.Dock = DockStyle.Fill;
            pnWrap.Controls.Add(producto);
            producto.Tag = producto;
            producto.Show();

        }

        private void procesandoFRM()
        {
            SplashScreenManager.ShowForm(this, typeof(frmProcesando), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Procesando...");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
        }

        private string estado = "Activo";
        private void pbFotoUsuario_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                frmInfoUsuario infoUser = new frmInfoUsuario();
                if (estado == "Activo")
                {
                    BunifuTransition transition = new BunifuTransition();
                    transition.ShowSync(infoUser, false, BunifuAnimatorNS.Animation.VertSlide);
                    estado = "Inactivo";
                }
                else
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.GetType() == typeof(frmInfoUsuario))
                        {
                            frm.Close();


                            break;

                        }
                    }
                    estado = "Activo";
                }
            }

        }


        int posX = 0;
        int posY = 0;
        private void moverFormulario(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
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
        private void PnHeaderMain_MouseMove(object sender, MouseEventArgs e)
        {
            moverFormulario(sender,e);
        }
        private void lbNombreUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            moverFormulario(sender, e);
        }
        private void BtMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btMaximizar.Visible = false;
            btNormal.Visible = true;
        }

        private void BtMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// -------------INICIO DE SUBMENUS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        //private Form subMenus;
        private void mostrarFormulario(Form name)
        {
            if (pnWrap.Controls.Count > 0)
                pnWrap.Controls.RemoveAt(0);
            procesandoFRM();
            name.FormBorderStyle = FormBorderStyle.None;
            name.TopLevel = false;
            name.Dock = DockStyle.Fill;
            pnWrap.Controls.Add(name);
            name.Show();
        }
        private void BtUser_Click(object sender, EventArgs e)
        {
            frmUsuario usuario = new frmUsuario();
            mostrarFormulario(usuario);
        }


        private void ItemsTop(string name, string subName, IconChar icons)
        {
            lbItems.Text = name + " | " + subName;
            lbItems.IconChar = icons;
        }
        private void BtMarca_Click(object sender, EventArgs e)
        {
            ItemsTop("Almacen", "Marca", IconChar.DiceD6);
            frmMarca marca = new frmMarca();
            mostrarFormulario(marca);


        }

        private void BtCategoria_Click(object sender, EventArgs e)
        {
            ItemsTop("Almacen", "Categoria", IconChar.DiceD6);
            frmCategoria categoria = new frmCategoria();
            mostrarFormulario(categoria);
            // procesandoFRM();
        }

        private void btDetalleAlmacen_Click(object sender, EventArgs e)
        {
            ItemsTop("Almacen", "Detalle Almacen", IconChar.DiceD6);
            frmDetalleAlmacen da = new frmDetalleAlmacen();
            mostrarFormulario(da);
            // procesandoFRM();
        }

        private void BtPerecederos_Click(object sender, EventArgs e)
        {
            ItemsTop("Almacen", "Perecedores", IconChar.DiceD6);
        }

        private void BtPresentacion_Click(object sender, EventArgs e)
        {
            ItemsTop("Almacen", "Presentacion", IconChar.DiceD6);
            frmPresentacion presentacion = new frmPresentacion();
            mostrarFormulario(presentacion);
            //procesandoFRM();
        }
        private void btUnidadMedida_Click(object sender, EventArgs e)
        {
            ItemsTop("Almacen", "Unidad de Medida", IconChar.DiceD6);
            frmUnidadMedida unme = new frmUnidadMedida();
            mostrarFormulario(unme);
        }
        private void btClientes_Click(object sender, EventArgs e)
        {
            ItemsTop("Ventas", "Cliente", IconChar.ShoppingCart);
            frmCliente cliente = new frmCliente();
            mostrarFormulario(cliente);
            //procesandoFRM();
        }

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmProveedor proveedor = new frmProveedor();
            mostrarFormulario(proveedor);
            //procesandoFRM();
        }

        private void BtPersonal_Click(object sender, EventArgs e)
        {
            ItemsTop("Usuario", "Personal", IconChar.UserFriends);
            frmMainPersonal personal = new frmMainPersonal();
            mostrarFormulario(personal);
            //procesandoFRM();
        }

        private void btAdministrarCaja_Click(object sender, EventArgs e)
        {
            ItemsTop("Caja", "Administrar Caja", IconChar.MoneyBillAlt);
            frmCaja caja = new frmCaja();
            mostrarFormulario(caja);
        }

        private void btTipoComprobante_Click(object sender, EventArgs e)
        {
            ItemsTop("Comprobante", "Tipo de Comprobante", IconChar.FileAlt);
            frmTipoComprobante comprobante = new frmTipoComprobante();
            mostrarFormulario(comprobante);
        }

        private void btRealizarCompras_Click(object sender, EventArgs e)
        {
            ItemsTop("Compras", "Realizar Compras", IconChar.Truck);
            frmCompras compras = new frmCompras();
            mostrarFormulario(compras);
        }

        private void btRealizarVentas_Click(object sender, EventArgs e)
        {
            ItemsTop("Ventas", "Realizar Ventas", IconChar.ShoppingCart);
            frmVentas ventas = new frmVentas();
            mostrarFormulario(ventas);
        }

        private void btMonedas_Click(object sender, EventArgs e)
        {
            ItemsTop("Parametros", "Monedas", IconChar.Tools);
            frmMoneda moneda = new frmMoneda();
            mostrarFormulario(moneda);
        }

        private void btDatosDelNegocio_Click(object sender, EventArgs e)
        {
            ItemsTop("Parametros", "Datos del negocio", IconChar.Tools);
            frmDatosNegocio DNegocio = new frmDatosNegocio();
            mostrarFormulario(DNegocio);
        }

        private void btSede_Click(object sender, EventArgs e)
        {
            ItemsTop("Parametros", "Datos del negocio", IconChar.Tools);
            frmSede sede = new frmSede();
            mostrarFormulario(sede);
        }

        private void btConsultaVentasDia_Click(object sender, EventArgs e)
        {
            ItemsTop("Ventas", "Consulta venta por dia", IconChar.ShoppingCart);
            frmReporteVentaDia sede = new frmReporteVentaDia();
            mostrarFormulario(sede);
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnHeaderMain_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lbNombreUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btNotificacion_Click(object sender, EventArgs e)
        {
            frmNotificacionMain noti = new frmNotificacionMain();
            AddOwnedForm(noti);
            noti.showAlert();
        }

        private void btConsultaVentasMes_Click(object sender, EventArgs e)
        {
            ItemsTop("Ventas", "Consulta venta por dia", IconChar.ShoppingCart);
            frmReporteVentaMes ventMes  = new frmReporteVentaMes();
            mostrarFormulario(ventMes);
        }
    }
}
