namespace Presentacion.Forms.subMenu
{
    partial class frmFormaPago
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.rDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow4 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btLimpiar = new Telerik.WinControls.UI.RadButton();
            this.cbEstado = new Telerik.WinControls.UI.RadDropDownList();
            this.txtFormaDePago = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridFormaPago = new DevExpress.XtraGrid.GridControl();
            this.dgFormaPago = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.documentContainer3 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip4 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.btEliminar = new XanderUI.XUIButton();
            this.btModificar = new XanderUI.XUIButton();
            this.btNuevo = new XanderUI.XUIButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).BeginInit();
            this.rDock.SuspendLayout();
            this.documentWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaDePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer3)).BeginInit();
            this.documentContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip4)).BeginInit();
            this.documentTabStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
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
            this.rDock.Location = new System.Drawing.Point(9, 79);
            this.rDock.MainDocumentContainer = this.documentContainer3;
            this.rDock.Name = "rDock";
            this.rDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.rDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.rDock.Size = new System.Drawing.Size(782, 361);
            this.rDock.SplitterWidth = 3;
            this.rDock.TabIndex = 22;
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
            this.documentWindow4.Controls.Add(this.radGroupBox2);
            this.documentWindow4.Controls.Add(this.gridFormaPago);
            this.documentWindow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow4.Location = new System.Drawing.Point(6, 29);
            this.documentWindow4.Name = "documentWindow4";
            this.documentWindow4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow4.Size = new System.Drawing.Size(770, 326);
            this.documentWindow4.Text = "  L I S T A  D E  F O R M A  D E  P A G O";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.btLimpiar);
            this.radGroupBox2.Controls.Add(this.cbEstado);
            this.radGroupBox2.Controls.Add(this.txtFormaDePago);
            this.radGroupBox2.Controls.Add(this.label6);
            this.radGroupBox2.Controls.Add(this.label4);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 1);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(770, 59);
            this.radGroupBox2.TabIndex = 11;
            this.radGroupBox2.ThemeName = "Office2010Silver";
            // 
            // btLimpiar
            // 
            this.btLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Location = new System.Drawing.Point(634, 15);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(72, 24);
            this.btLimpiar.TabIndex = 57;
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
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem4.Text = "Selecciona";
            radListDataItem5.Text = "Activo";
            radListDataItem6.Text = "Inactivo";
            this.cbEstado.Items.Add(radListDataItem4);
            this.cbEstado.Items.Add(radListDataItem5);
            this.cbEstado.Items.Add(radListDataItem6);
            this.cbEstado.Location = new System.Drawing.Point(466, 17);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(143, 20);
            this.cbEstado.TabIndex = 55;
            this.cbEstado.ThemeName = "Office2010Black";
            this.cbEstado.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // txtFormaDePago
            // 
            this.txtFormaDePago.Location = new System.Drawing.Point(114, 17);
            this.txtFormaDePago.Name = "txtFormaDePago";
            this.txtFormaDePago.Size = new System.Drawing.Size(290, 20);
            this.txtFormaDePago.TabIndex = 49;
            this.txtFormaDePago.ThemeName = "Office2010Silver";
            this.txtFormaDePago.TextChanged += new System.EventHandler(this.txtFormaDePago_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label6.Location = new System.Drawing.Point(415, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Estado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(20, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Forma de pago:";
            // 
            // gridFormaPago
            // 
            this.gridFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode2.RelationName = "Level1";
            this.gridFormaPago.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridFormaPago.Location = new System.Drawing.Point(0, 66);
            this.gridFormaPago.MainView = this.dgFormaPago;
            this.gridFormaPago.Name = "gridFormaPago";
            this.gridFormaPago.Size = new System.Drawing.Size(770, 260);
            this.gridFormaPago.TabIndex = 0;
            this.gridFormaPago.UseEmbeddedNavigator = true;
            this.gridFormaPago.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgFormaPago});
            // 
            // dgFormaPago
            // 
            this.dgFormaPago.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dgFormaPago.GridControl = this.gridFormaPago;
            this.dgFormaPago.Name = "dgFormaPago";
            this.dgFormaPago.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dgFormaPago.OptionsView.ShowAutoFilterRow = true;
            this.dgFormaPago.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgFormaPago.OptionsView.ShowGroupPanel = false;
            this.dgFormaPago.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgFormaPago_RowCellStyle);
            this.dgFormaPago.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.dgFormaPago_ShowingEditor);
            this.dgFormaPago.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgFormaPago_FocusedRowChanged);
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
            this.documentTabStrip4.Size = new System.Drawing.Size(782, 361);
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
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).Text = "  L I S T A  D E  F O R M A  D E  P A G O";
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.ActionButtonElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1))).ToolTipText = "Active Documents";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(2))).TopColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(2))).BottomColor = System.Drawing.SystemColors.ControlDark;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.xuiButton1);
            this.radGroupBox1.Controls.Add(this.btEliminar);
            this.radGroupBox1.Controls.Add(this.btModificar);
            this.radGroupBox1.Controls.Add(this.btNuevo);
            this.radGroupBox1.Controls.Add(this.separatorControl1);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 11);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(776, 53);
            this.radGroupBox1.TabIndex = 21;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.xuiButton1.ButtonImage = null;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "IMPRIMIR";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.xuiButton1.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.xuiButton1.CornerRadius = 5;
            this.xuiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.xuiButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(307, 12);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(84, 27);
            this.xuiButton1.TabIndex = 5;
            this.xuiButton1.TextColor = System.Drawing.Color.White;
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            // 
            // btEliminar
            // 
            this.btEliminar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btEliminar.ButtonImage = null;
            this.btEliminar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btEliminar.ButtonText = "ELIMINAR";
            this.btEliminar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btEliminar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btEliminar.CornerRadius = 5;
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btEliminar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btEliminar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btEliminar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btEliminar.Location = new System.Drawing.Point(191, 12);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(84, 27);
            this.btEliminar.TabIndex = 5;
            this.btEliminar.TextColor = System.Drawing.Color.White;
            this.btEliminar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btModificar
            // 
            this.btModificar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(19)))));
            this.btModificar.ButtonImage = null;
            this.btModificar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btModificar.ButtonText = "MODIFICAR";
            this.btModificar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btModificar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btModificar.CornerRadius = 5;
            this.btModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModificar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btModificar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btModificar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btModificar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btModificar.Location = new System.Drawing.Point(100, 12);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(84, 27);
            this.btModificar.TabIndex = 5;
            this.btModificar.TextColor = System.Drawing.Color.White;
            this.btModificar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btNuevo.ButtonImage = null;
            this.btNuevo.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btNuevo.ButtonText = "NUEVO";
            this.btNuevo.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btNuevo.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btNuevo.CornerRadius = 5;
            this.btNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevo.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btNuevo.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btNuevo.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btNuevo.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btNuevo.Location = new System.Drawing.Point(10, 12);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(84, 27);
            this.btNuevo.TabIndex = 5;
            this.btNuevo.TextColor = System.Drawing.Color.White;
            this.btNuevo.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // separatorControl1
            // 
            this.separatorControl1.AutoSizeMode = true;
            this.separatorControl1.BackColor = System.Drawing.SystemColors.Control;
            this.separatorControl1.LineAlignment = DevExpress.XtraEditors.Alignment.Center;
            this.separatorControl1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.separatorControl1.LineThickness = 2;
            this.separatorControl1.Location = new System.Drawing.Point(281, 6);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(20, 38);
            this.separatorControl1.TabIndex = 1;
            // 
            // frmFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rDock);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmFormaPago";
            this.Text = "frmFormaPago";
            this.Load += new System.EventHandler(this.frmFormaPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).EndInit();
            this.rDock.ResumeLayout(false);
            this.documentWindow4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaDePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer3)).EndInit();
            this.documentContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip4)).EndInit();
            this.documentTabStrip4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Docking.RadDock rDock;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btLimpiar;
        private Telerik.WinControls.UI.RadDropDownList cbEstado;
        private Telerik.WinControls.UI.RadTextBox txtFormaDePago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gridFormaPago;
        private DevExpress.XtraGrid.Views.Grid.GridView dgFormaPago;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer3;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private XanderUI.XUIButton xuiButton1;
        private XanderUI.XUIButton btEliminar;
        private XanderUI.XUIButton btModificar;
        private XanderUI.XUIButton btNuevo;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
    }
}