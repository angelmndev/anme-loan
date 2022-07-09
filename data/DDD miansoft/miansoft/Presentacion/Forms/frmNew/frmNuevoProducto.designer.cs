namespace Presentacion.Forms.frmNew
{
    partial class frmNuevoProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCategoria = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btGuardar = new XanderUI.XUIButton();
            this.btEliminar = new XanderUI.XUIButton();
            this.cbMarca = new Telerik.WinControls.UI.RadDropDownList();
            this.cbUnidadMedida = new Telerik.WinControls.UI.RadDropDownList();
            this.cbPresentacion = new Telerik.WinControls.UI.RadDropDownList();
            this.cbCategoria = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbMoneda = new Telerik.WinControls.UI.RadDropDownList();
            this.txtCosto = new Telerik.WinControls.UI.RadTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStockMax = new Telerik.WinControls.UI.RadTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStokMin = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.chkPerecedero = new Telerik.WinControls.UI.RadCheckBox();
            this.chkEstado = new Telerik.WinControls.UI.RadCheckBox();
            this.rbCodigoAntiguo = new Telerik.WinControls.UI.RadRadioButton();
            this.rbCodigoNuevo = new Telerik.WinControls.UI.RadRadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.txtMarca = new Telerik.WinControls.UI.RadTextBox();
            this.txtUnidadMedida = new Telerik.WinControls.UI.RadTextBox();
            this.txtPresentacion = new Telerik.WinControls.UI.RadTextBox();
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnidadMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPresentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPerecedero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCodigoAntiguo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCodigoNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.pnHeader.Controls.Add(this.btClose);
            this.pnHeader.Controls.Add(this.label12);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(713, 49);
            this.pnHeader.TabIndex = 0;
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnHeader_MouseMove);
            // 
            // btClose
            // 
            this.btClose.BackgroundImage = global::Presentacion.Properties.Resources.cerrar__1_;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(671, 13);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(20, 20);
            this.btClose.TabIndex = 16;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "NUEVO PRODUCTO";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(107, 25);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(238, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Text = "1234567896875";
            this.txtCodigo.ThemeName = "Office2010Silver";
            this.txtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(53, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Codigo:";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(107, 85);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(113, 20);
            this.txtCategoria.TabIndex = 3;
            this.txtCategoria.ThemeName = "Office2010Silver";
            this.txtCategoria.TextChanged += new System.EventHandler(this.TxtCategoria_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(41, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(31, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Descripcion:";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btGuardar);
            this.radGroupBox1.Controls.Add(this.btEliminar);
            this.radGroupBox1.Controls.Add(this.cbMarca);
            this.radGroupBox1.Controls.Add(this.cbUnidadMedida);
            this.radGroupBox1.Controls.Add(this.cbPresentacion);
            this.radGroupBox1.Controls.Add(this.cbCategoria);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.pbFoto);
            this.radGroupBox1.Controls.Add(this.chkPerecedero);
            this.radGroupBox1.Controls.Add(this.chkEstado);
            this.radGroupBox1.Controls.Add(this.rbCodigoAntiguo);
            this.radGroupBox1.Controls.Add(this.rbCodigoNuevo);
            this.radGroupBox1.Controls.Add(this.label7);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.txtDescripcion);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.txtCodigo);
            this.radGroupBox1.Controls.Add(this.txtMarca);
            this.radGroupBox1.Controls.Add(this.txtUnidadMedida);
            this.radGroupBox1.Controls.Add(this.txtPresentacion);
            this.radGroupBox1.Controls.Add(this.txtCategoria);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 56);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(688, 346);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // btGuardar
            // 
            this.btGuardar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.ButtonImage = null;
            this.btGuardar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btGuardar.ButtonText = "GUARDAR";
            this.btGuardar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btGuardar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btGuardar.CornerRadius = 5;
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btGuardar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btGuardar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btGuardar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btGuardar.Location = new System.Drawing.Point(565, 300);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(109, 30);
            this.btGuardar.TabIndex = 42;
            this.btGuardar.TextColor = System.Drawing.Color.White;
            this.btGuardar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click_1);
            // 
            // btEliminar
            // 
            this.btEliminar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btEliminar.ButtonImage = null;
            this.btEliminar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btEliminar.ButtonText = "CANCELAR";
            this.btEliminar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btEliminar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btEliminar.CornerRadius = 5;
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btEliminar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btEliminar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btEliminar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btEliminar.Location = new System.Drawing.Point(443, 300);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(109, 30);
            this.btEliminar.TabIndex = 43;
            this.btEliminar.TextColor = System.Drawing.Color.White;
            this.btEliminar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbMarca.Location = new System.Drawing.Point(226, 175);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(183, 20);
            this.cbMarca.TabIndex = 41;
            this.cbMarca.Text = "radDropDownList1";
            this.cbMarca.ThemeName = "Office2010Black";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.cbMarca.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMarca.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbUnidadMedida.Location = new System.Drawing.Point(226, 145);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(183, 20);
            this.cbUnidadMedida.TabIndex = 41;
            this.cbUnidadMedida.Text = "radDropDownList1";
            this.cbUnidadMedida.ThemeName = "Office2010Black";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.cbUnidadMedida.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbUnidadMedida.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // cbPresentacion
            // 
            this.cbPresentacion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbPresentacion.Location = new System.Drawing.Point(226, 115);
            this.cbPresentacion.Name = "cbPresentacion";
            this.cbPresentacion.Size = new System.Drawing.Size(183, 20);
            this.cbPresentacion.TabIndex = 41;
            this.cbPresentacion.ThemeName = "Office2010Black";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.cbPresentacion.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbPresentacion.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbCategoria.Location = new System.Drawing.Point(226, 85);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(183, 20);
            this.cbCategoria.TabIndex = 41;
            this.cbCategoria.Text = "radDropDownList1";
            this.cbCategoria.ThemeName = "Office2010Black";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.cbCategoria.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbCategoria.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.cbMoneda);
            this.radGroupBox2.Controls.Add(this.txtCosto);
            this.radGroupBox2.Controls.Add(this.label11);
            this.radGroupBox2.Controls.Add(this.label10);
            this.radGroupBox2.Controls.Add(this.txtStockMax);
            this.radGroupBox2.Controls.Add(this.label9);
            this.radGroupBox2.Controls.Add(this.txtStokMin);
            this.radGroupBox2.Controls.Add(this.label8);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(17, 208);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(657, 74);
            this.radGroupBox2.TabIndex = 5;
            this.radGroupBox2.ThemeName = "Office2010Silver";
            // 
            // cbMoneda
            // 
            this.cbMoneda.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem3.Text = "Soles";
            radListDataItem4.Text = "Dolares";
            this.cbMoneda.Items.Add(radListDataItem3);
            this.cbMoneda.Items.Add(radListDataItem4);
            this.cbMoneda.Location = new System.Drawing.Point(536, 23);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(110, 20);
            this.cbMoneda.TabIndex = 41;
            this.cbMoneda.ThemeName = "Office2010Black";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.cbMoneda.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.cbMoneda.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(390, 23);
            this.txtCosto.MaxLength = 20;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(77, 20);
            this.txtCosto.TabIndex = 9;
            this.txtCosto.ThemeName = "Office2010Silver";
            this.txtCosto.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(482, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Moneda:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(346, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Costo:";
            // 
            // txtStockMax
            // 
            this.txtStockMax.Location = new System.Drawing.Point(251, 23);
            this.txtStockMax.MaxLength = 20;
            this.txtStockMax.Name = "txtStockMax";
            this.txtStockMax.Size = new System.Drawing.Size(77, 20);
            this.txtStockMax.TabIndex = 8;
            this.txtStockMax.ThemeName = "Office2010Silver";
            this.txtStockMax.TextChanged += new System.EventHandler(this.TxtStockMax_TextChanged);
            this.txtStockMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMax_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Stk. Maximo:";
            // 
            // txtStokMin
            // 
            this.txtStokMin.Location = new System.Drawing.Point(86, 23);
            this.txtStokMin.MaxLength = 20;
            this.txtStokMin.Name = "txtStokMin";
            this.txtStokMin.Size = new System.Drawing.Size(77, 20);
            this.txtStokMin.TabIndex = 7;
            this.txtStokMin.ThemeName = "Office2010Silver";
            this.txtStokMin.TextChanged += new System.EventHandler(this.TxtStokMin_TextChanged);
            this.txtStokMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStokMin_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Stk. Minimo:";
            // 
            // pbFoto
            // 
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFoto.Location = new System.Drawing.Point(547, 85);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(127, 114);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFoto.TabIndex = 6;
            this.pbFoto.TabStop = false;
            this.pbFoto.DoubleClick += new System.EventHandler(this.pbFoto_DoubleClick);
            // 
            // chkPerecedero
            // 
            this.chkPerecedero.Location = new System.Drawing.Point(431, 175);
            this.chkPerecedero.Name = "chkPerecedero";
            this.chkPerecedero.Size = new System.Drawing.Size(77, 18);
            this.chkPerecedero.TabIndex = 15;
            this.chkPerecedero.Text = "Perecedero";
            this.chkPerecedero.ThemeName = "Office2010Silver";
            this.chkPerecedero.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ChkEstado_ToggleStateChanged);
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(619, 26);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(51, 18);
            this.chkEstado.TabIndex = 15;
            this.chkEstado.Text = "Activo";
            this.chkEstado.ThemeName = "Office2010Silver";
            this.chkEstado.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ChkEstado_ToggleStateChanged);
            // 
            // rbCodigoAntiguo
            // 
            this.rbCodigoAntiguo.Location = new System.Drawing.Point(456, 26);
            this.rbCodigoAntiguo.Name = "rbCodigoAntiguo";
            this.rbCodigoAntiguo.Size = new System.Drawing.Size(100, 18);
            this.rbCodigoAntiguo.TabIndex = 14;
            this.rbCodigoAntiguo.Text = "Codigo Antiguo";
            this.rbCodigoAntiguo.ThemeName = "Office2010Silver";
            // 
            // rbCodigoNuevo
            // 
            this.rbCodigoNuevo.Location = new System.Drawing.Point(356, 26);
            this.rbCodigoNuevo.Name = "rbCodigoNuevo";
            this.rbCodigoNuevo.Size = new System.Drawing.Size(93, 18);
            this.rbCodigoNuevo.TabIndex = 13;
            this.rbCodigoNuevo.Text = "Codigo Nuevo";
            this.rbCodigoNuevo.ThemeName = "Office2010Silver";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label7.Location = new System.Drawing.Point(60, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Marca:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label6.Location = new System.Drawing.Point(14, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Undad Medida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(25, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Presentacion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(107, 55);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(567, 20);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.ThemeName = "Office2010Silver";
            this.txtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(107, 175);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(113, 20);
            this.txtMarca.TabIndex = 6;
            this.txtMarca.ThemeName = "Office2010Silver";
            this.txtMarca.TextChanged += new System.EventHandler(this.TxtMarca_TextChanged);
            // 
            // txtUnidadMedida
            // 
            this.txtUnidadMedida.Location = new System.Drawing.Point(107, 145);
            this.txtUnidadMedida.Name = "txtUnidadMedida";
            this.txtUnidadMedida.Size = new System.Drawing.Size(113, 20);
            this.txtUnidadMedida.TabIndex = 5;
            this.txtUnidadMedida.ThemeName = "Office2010Silver";
            this.txtUnidadMedida.TextChanged += new System.EventHandler(this.TxtUnidadMedida_TextChanged);
            // 
            // txtPresentacion
            // 
            this.txtPresentacion.Location = new System.Drawing.Point(107, 115);
            this.txtPresentacion.Name = "txtPresentacion";
            this.txtPresentacion.Size = new System.Drawing.Size(113, 20);
            this.txtPresentacion.TabIndex = 4;
            this.txtPresentacion.ThemeName = "Office2010Silver";
            this.txtPresentacion.TextChanged += new System.EventHandler(this.TxtPresentacion_TextChanged);
            // 
            // frmNuevoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 413);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoProducto";
            this.Load += new System.EventHandler(this.FrmNuevoProducto_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnidadMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPresentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPerecedero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCodigoAntiguo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbCodigoNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresentacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btClose;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBox txtCosto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private Telerik.WinControls.UI.RadTextBox txtStockMax;
        private System.Windows.Forms.Label label9;
        private Telerik.WinControls.UI.RadTextBox txtStokMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbFoto;
        private Telerik.WinControls.UI.RadCheckBox chkEstado;
        private Telerik.WinControls.UI.RadRadioButton rbCodigoAntiguo;
        private Telerik.WinControls.UI.RadRadioButton rbCodigoNuevo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private Telerik.WinControls.UI.RadTextBox txtMarca;
        private Telerik.WinControls.UI.RadTextBox txtUnidadMedida;
        private Telerik.WinControls.UI.RadTextBox txtPresentacion;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private Telerik.WinControls.UI.RadDropDownList cbCategoria;
        private Telerik.WinControls.UI.RadDropDownList cbMarca;
        private Telerik.WinControls.UI.RadDropDownList cbUnidadMedida;
        private Telerik.WinControls.UI.RadDropDownList cbPresentacion;
        private Telerik.WinControls.UI.RadDropDownList cbMoneda;
        private XanderUI.XUIButton btGuardar;
        private XanderUI.XUIButton btEliminar;
        private Telerik.WinControls.UI.RadCheckBox chkPerecedero;
    }
}