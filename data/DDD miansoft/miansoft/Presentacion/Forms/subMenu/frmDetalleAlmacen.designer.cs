namespace Presentacion.Forms.subMenu
{
    partial class frmDetalleAlmacen
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.gridDtAlmacen = new DevExpress.XtraGrid.GridControl();
            this.dgDtAlmacen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCategoria = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMarca = new Telerik.WinControls.UI.RadDropDownList();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPresentacion = new Telerik.WinControls.UI.RadDropDownList();
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.rDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow4 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbMostrarPor = new Telerik.WinControls.UI.RadDropDownList();
            this.btLimpiar = new Telerik.WinControls.UI.RadButton();
            this.label4 = new System.Windows.Forms.Label();
            this.documentContainer3 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip4 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.cmEliminar = new Telerik.WinControls.UI.RadMenuItem();
            this.cmModificar = new Telerik.WinControls.UI.RadMenuItem();
            this.cmDetalle = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridDtAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDtAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPresentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).BeginInit();
            this.rDock.SuspendLayout();
            this.documentWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMostrarPor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer3)).BeginInit();
            this.documentContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip4)).BeginInit();
            this.documentTabStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDtAlmacen
            // 
            this.gridDtAlmacen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gridDtAlmacen.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridDtAlmacen.Location = new System.Drawing.Point(0, 96);
            this.gridDtAlmacen.MainView = this.dgDtAlmacen;
            this.gridDtAlmacen.Name = "gridDtAlmacen";
            this.gridDtAlmacen.Size = new System.Drawing.Size(770, 301);
            this.gridDtAlmacen.TabIndex = 0;
            this.gridDtAlmacen.UseEmbeddedNavigator = true;
            this.gridDtAlmacen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgDtAlmacen});
            // 
            // dgDtAlmacen
            // 
            this.dgDtAlmacen.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.dgDtAlmacen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgDtAlmacen.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.dgDtAlmacen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgDtAlmacen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgDtAlmacen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgDtAlmacen.Appearance.SelectedRow.BackColor = System.Drawing.Color.Teal;
            this.dgDtAlmacen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgDtAlmacen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dgDtAlmacen.GridControl = this.gridDtAlmacen;
            this.dgDtAlmacen.Name = "dgDtAlmacen";
            this.dgDtAlmacen.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dgDtAlmacen.OptionsPrint.EnableAppearanceEvenRow = true;
            this.dgDtAlmacen.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgDtAlmacen.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.dgDtAlmacen.OptionsView.ShowAutoFilterRow = true;
            this.dgDtAlmacen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgDtAlmacen.OptionsView.ShowGroupPanel = false;
            this.dgDtAlmacen.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgDtAlmacen_CustomDrawCell);
            this.dgDtAlmacen.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgDtAlmacen_RowCellStyle);
            this.dgDtAlmacen.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.dgDtAlmacen_ShowingEditor);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(80, 55);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(357, 20);
            this.txtDescripcion.TabIndex = 45;
            this.txtDescripcion.ThemeName = "Office2010Silver";
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.Enter += new System.EventHandler(this.txtDescripcion_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(7, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Descripcion:";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbCategoria.Location = new System.Drawing.Point(80, 17);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(143, 20);
            this.cbCategoria.TabIndex = 47;
            this.cbCategoria.Text = "Selecciona";
            this.cbCategoria.ThemeName = "Office2010Black";
            this.cbCategoria.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbCategoria_SelectedIndexChanged);
            this.cbCategoria.Enter += new System.EventHandler(this.cbCategoria_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Categoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(250, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Marca:";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbMarca.Location = new System.Drawing.Point(294, 17);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(143, 20);
            this.cbMarca.TabIndex = 47;
            this.cbMarca.Text = "Selecciona";
            this.cbMarca.ThemeName = "Office2010Black";
            this.cbMarca.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbMarca_SelectedIndexChanged);
            this.cbMarca.Enter += new System.EventHandler(this.cbMarca_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(460, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Presentacion:";
            // 
            // cbPresentacion
            // 
            this.cbPresentacion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbPresentacion.Location = new System.Drawing.Point(541, 17);
            this.cbPresentacion.Name = "cbPresentacion";
            this.cbPresentacion.Size = new System.Drawing.Size(143, 20);
            this.cbPresentacion.TabIndex = 47;
            this.cbPresentacion.Text = "Selecciona";
            this.cbPresentacion.ThemeName = "Office2010Black";
            this.cbPresentacion.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbPresentacion_SelectedIndexChanged);
            this.cbPresentacion.Enter += new System.EventHandler(this.cbPresentacion_Enter);
            // 
            // rDock
            // 
            this.rDock.ActiveWindow = this.documentWindow4;
            this.rDock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rDock.CausesValidation = false;
            this.rDock.Controls.Add(this.documentContainer3);
            this.rDock.IsCleanUpTarget = true;
            this.rDock.Location = new System.Drawing.Point(9, 9);
            this.rDock.MainDocumentContainer = this.documentContainer3;
            this.rDock.Name = "rDock";
            this.rDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.rDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.rDock.Size = new System.Drawing.Size(782, 432);
            this.rDock.SplitterWidth = 3;
            this.rDock.TabIndex = 48;
            this.rDock.TabStop = false;
            this.rDock.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.SplitPanelElement)(this.rDock.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(5);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rDock.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rDock.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rDock.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rDock.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.SystemColors.Control;
            // 
            // documentWindow4
            // 
            this.documentWindow4.BackColor = System.Drawing.SystemColors.Control;
            this.documentWindow4.Controls.Add(this.radGroupBox1);
            this.documentWindow4.Controls.Add(this.gridDtAlmacen);
            this.documentWindow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow4.Location = new System.Drawing.Point(6, 29);
            this.documentWindow4.Name = "documentWindow4";
            this.documentWindow4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow4.Size = new System.Drawing.Size(770, 397);
            this.documentWindow4.Text = "  D E T A L L E  D E   A L M A C E N  ";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.cbMostrarPor);
            this.radGroupBox1.Controls.Add(this.btLimpiar);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.cbPresentacion);
            this.radGroupBox1.Controls.Add(this.cbMarca);
            this.radGroupBox1.Controls.Add(this.txtDescripcion);
            this.radGroupBox1.Controls.Add(this.cbCategoria);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(770, 91);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // cbMostrarPor
            // 
            this.cbMostrarPor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Vigente";
            radListDataItem2.Text = "Pasado";
            radListDataItem3.Text = "Todo";
            this.cbMostrarPor.Items.Add(radListDataItem1);
            this.cbMostrarPor.Items.Add(radListDataItem2);
            this.cbMostrarPor.Items.Add(radListDataItem3);
            this.cbMostrarPor.Location = new System.Drawing.Point(541, 55);
            this.cbMostrarPor.Name = "cbMostrarPor";
            this.cbMostrarPor.Size = new System.Drawing.Size(143, 20);
            this.cbMostrarPor.TabIndex = 59;
            this.cbMostrarPor.ThemeName = "Office2010Black";
            this.cbMostrarPor.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbMostrarPor_SelectedIndexChanged_1);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Location = new System.Drawing.Point(458, 53);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(72, 24);
            this.btLimpiar.TabIndex = 58;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(206)))), ((int)(((byte)(226)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(206)))), ((int)(((byte)(226)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btLimpiar.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(541, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Mostrar por:";
            // 
            // documentContainer3
            // 
            this.documentContainer3.CausesValidation = false;
            this.documentContainer3.Controls.Add(this.documentTabStrip4);
            this.documentContainer3.Name = "documentContainer3";
            // 
            // 
            // 
            this.documentContainer3.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer3.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer3.SplitterWidth = 3;
            this.documentContainer3.ThemeName = "Office2010Silver";
            // 
            // documentTabStrip4
            // 
            this.documentTabStrip4.CanUpdateChildIndex = true;
            this.documentTabStrip4.CausesValidation = false;
            this.documentTabStrip4.Controls.Add(this.documentWindow4);
            this.documentTabStrip4.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip4.Name = "documentTabStrip4";
            // 
            // 
            // 
            this.documentTabStrip4.RootElement.BorderHighlightColor = System.Drawing.SystemColors.Control;
            this.documentTabStrip4.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip4.SelectedIndex = 0;
            this.documentTabStrip4.Size = new System.Drawing.Size(782, 432);
            this.documentTabStrip4.TabIndex = 0;
            this.documentTabStrip4.TabStop = false;
            this.documentTabStrip4.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.SplitPanelElement)(this.documentTabStrip4.GetChildAt(0))).BorderHighlightColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(1))).InnerColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(1))).InnerColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(1))).InnerColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderColor2 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderInnerColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderInnerColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderLeftColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderTopColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor2 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor3 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).IsPinned = false;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(39)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).Text = "  D E T A L L E  D E   A L M A C E N  ";
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.ActionButtonElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1))).ToolTipText = "Active Documents";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(2))).TopColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(2))).BottomColor = System.Drawing.SystemColors.ControlDark;
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.cmEliminar,
            this.cmModificar,
            this.cmDetalle});
            this.radContextMenu1.ThemeName = "Office2007Silver";
            // 
            // cmEliminar
            // 
            this.cmEliminar.Name = "cmEliminar";
            this.cmEliminar.Text = "Eliminar";
            this.cmEliminar.UseCompatibleTextRendering = false;
            // 
            // cmModificar
            // 
            this.cmModificar.Name = "cmModificar";
            this.cmModificar.Text = "Modificar";
            this.cmModificar.UseCompatibleTextRendering = false;
            // 
            // cmDetalle
            // 
            this.cmDetalle.ClickMode = Telerik.WinControls.ClickMode.Release;
            this.cmDetalle.Name = "cmDetalle";
            this.cmDetalle.Text = "Detalles";
            this.cmDetalle.UseCompatibleTextRendering = false;
            // 
            // frmDetalleAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rDock);
            this.Name = "frmDetalleAlmacen";
            this.Text = "frmDetalleAlmacen";
            this.Load += new System.EventHandler(this.frmDetalleAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDtAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDtAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPresentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).EndInit();
            this.rDock.ResumeLayout(false);
            this.documentWindow4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMostrarPor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer3)).EndInit();
            this.documentContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip4)).EndInit();
            this.documentTabStrip4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDtAlmacen;
        private DevExpress.XtraGrid.Views.Grid.GridView dgDtAlmacen;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDropDownList cbCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList cbMarca;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDropDownList cbPresentacion;
        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        private Telerik.WinControls.UI.Docking.RadDock rDock;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer3;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip4;
        private Telerik.WinControls.UI.RadButton btLimpiar;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDropDownList cbMostrarPor;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem cmEliminar;
        private Telerik.WinControls.UI.RadMenuItem cmModificar;
        private Telerik.WinControls.UI.RadMenuItem cmDetalle;
    }
}