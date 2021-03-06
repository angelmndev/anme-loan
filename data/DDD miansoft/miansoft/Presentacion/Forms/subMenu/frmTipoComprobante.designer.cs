namespace Presentacion.Forms.subMenu
{
    partial class frmTipoComprobante
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.rDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow4 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbEstado = new Telerik.WinControls.UI.RadDropDownList();
            this.btLimpiar = new XanderUI.XUIButton();
            this.txtNombre = new Telerik.WinControls.UI.RadTextBox();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gridComprobante = new DevExpress.XtraGrid.GridControl();
            this.dgComprobante = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colpk_comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomSerie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomCorrelativo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.documentContainer3 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip4 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.btEliminar = new XanderUI.XUIButton();
            this.btModificar = new XanderUI.XUIButton();
            this.btNuevo = new XanderUI.XUIButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.toolWindow2 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).BeginInit();
            this.rDock.SuspendLayout();
            this.documentWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
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
            this.rDock.Location = new System.Drawing.Point(12, 75);
            this.rDock.MainDocumentContainer = this.documentContainer3;
            this.rDock.Name = "rDock";
            this.rDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.rDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.rDock.Size = new System.Drawing.Size(776, 366);
            this.rDock.SplitterWidth = 3;
            this.rDock.TabIndex = 17;
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
            this.documentWindow4.Controls.Add(this.radGroupBox3);
            this.documentWindow4.Controls.Add(this.gridComprobante);
            this.documentWindow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow4.Location = new System.Drawing.Point(6, 29);
            this.documentWindow4.Name = "documentWindow4";
            this.documentWindow4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow4.Size = new System.Drawing.Size(764, 331);
            this.documentWindow4.Text = "L I S T A  D E  C O M P R O B A N T E";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox3.Controls.Add(this.cbEstado);
            this.radGroupBox3.Controls.Add(this.btLimpiar);
            this.radGroupBox3.Controls.Add(this.txtNombre);
            this.radGroupBox3.Controls.Add(this.txtCodigo);
            this.radGroupBox3.Controls.Add(this.label2);
            this.radGroupBox3.Controls.Add(this.label1);
            this.radGroupBox3.Controls.Add(this.label5);
            this.radGroupBox3.HeaderText = "";
            this.radGroupBox3.Location = new System.Drawing.Point(0, 3);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(764, 61);
            this.radGroupBox3.TabIndex = 12;
            this.radGroupBox3.ThemeName = "Office2010Silver";
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Selecciona";
            radListDataItem2.Text = "Activo";
            radListDataItem3.Text = "Inactivo";
            this.cbEstado.Items.Add(radListDataItem1);
            this.cbEstado.Items.Add(radListDataItem2);
            this.cbEstado.Items.Add(radListDataItem3);
            this.cbEstado.Location = new System.Drawing.Point(540, 21);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(127, 20);
            this.cbEstado.TabIndex = 55;
            this.cbEstado.ThemeName = "Office2010Black";
            this.cbEstado.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbEstado_SelectedIndexChanged);
            this.cbEstado.Enter += new System.EventHandler(this.cbEstado_Enter);
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btLimpiar.ButtonImage = null;
            this.btLimpiar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btLimpiar.ButtonText = "LIMPIAR";
            this.btLimpiar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btLimpiar.ClickTextColor = System.Drawing.Color.Silver;
            this.btLimpiar.CornerRadius = 5;
            this.btLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btLimpiar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btLimpiar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btLimpiar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btLimpiar.Location = new System.Drawing.Point(686, 19);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(64, 24);
            this.btLimpiar.TabIndex = 5;
            this.btLimpiar.TextColor = System.Drawing.Color.White;
            this.btLimpiar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(250, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(233, 20);
            this.txtNombre.TabIndex = 49;
            this.txtNombre.ThemeName = "Office2010Silver";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(71, 23);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(116, 20);
            this.txtCodigo.TabIndex = 49;
            this.txtCodigo.ThemeName = "Office2010Silver";
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            this.txtCodigo.Enter += new System.EventHandler(this.txtDni_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(496, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(197, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(14, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Codigo:";
            // 
            // gridComprobante
            // 
            this.gridComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridComprobante.DataMember = "listarComprobante";
            gridLevelNode1.RelationName = "Level1";
            this.gridComprobante.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridComprobante.Location = new System.Drawing.Point(0, 66);
            this.gridComprobante.MainView = this.dgComprobante;
            this.gridComprobante.Name = "gridComprobante";
            this.gridComprobante.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridComprobante.Size = new System.Drawing.Size(764, 265);
            this.gridComprobante.TabIndex = 0;
            this.gridComprobante.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgComprobante});
            // 
            // dgComprobante
            // 
            this.dgComprobante.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dgComprobante.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colpk_comprobante,
            this.colcomCodigo,
            this.colcomNombre,
            this.colcomSerie,
            this.colcomCorrelativo,
            this.colcomEstado});
            this.dgComprobante.GridControl = this.gridComprobante;
            this.dgComprobante.Name = "dgComprobante";
            this.dgComprobante.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dgComprobante.OptionsPrint.EnableAppearanceEvenRow = true;
            this.dgComprobante.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgComprobante.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.dgComprobante.OptionsView.ShowAutoFilterRow = true;
            this.dgComprobante.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgComprobante.OptionsView.ShowGroupPanel = false;
            this.dgComprobante.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgComprobante_RowCellStyle);
            this.dgComprobante.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.dgComprobante_ShowingEditor);
            this.dgComprobante.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgComprobante_FocusedRowChanged);
            // 
            // colpk_comprobante
            // 
            this.colpk_comprobante.FieldName = "pk_comprobante";
            this.colpk_comprobante.Name = "colpk_comprobante";
            this.colpk_comprobante.Visible = true;
            this.colpk_comprobante.VisibleIndex = 0;
            // 
            // colcomCodigo
            // 
            this.colcomCodigo.FieldName = "comCodigo";
            this.colcomCodigo.Name = "colcomCodigo";
            this.colcomCodigo.Visible = true;
            this.colcomCodigo.VisibleIndex = 1;
            // 
            // colcomNombre
            // 
            this.colcomNombre.FieldName = "comNombre";
            this.colcomNombre.Name = "colcomNombre";
            this.colcomNombre.Visible = true;
            this.colcomNombre.VisibleIndex = 2;
            // 
            // colcomSerie
            // 
            this.colcomSerie.FieldName = "comSerie";
            this.colcomSerie.Name = "colcomSerie";
            this.colcomSerie.Visible = true;
            this.colcomSerie.VisibleIndex = 3;
            // 
            // colcomCorrelativo
            // 
            this.colcomCorrelativo.FieldName = "comCorrelativo";
            this.colcomCorrelativo.Name = "colcomCorrelativo";
            this.colcomCorrelativo.Visible = true;
            this.colcomCorrelativo.VisibleIndex = 4;
            // 
            // colcomEstado
            // 
            this.colcomEstado.FieldName = "comEstado";
            this.colcomEstado.Name = "colcomEstado";
            this.colcomEstado.Visible = true;
            this.colcomEstado.VisibleIndex = 5;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
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
            this.documentTabStrip4.Size = new System.Drawing.Size(776, 366);
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
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor2 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).IsPinned = false;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).Text = "L I S T A  D E  C O M P R O B A N T E";
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
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
            this.radGroupBox1.TabIndex = 16;
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
            this.btEliminar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btEliminar.ClickTextColor = System.Drawing.Color.Silver;
            this.btEliminar.CornerRadius = 5;
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btEliminar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
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
            this.btModificar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(19)))));
            this.btModificar.ClickTextColor = System.Drawing.Color.Silver;
            this.btModificar.CornerRadius = 5;
            this.btModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModificar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btModificar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(19)))));
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
            this.btNuevo.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btNuevo.ClickTextColor = System.Drawing.Color.Silver;
            this.btNuevo.CornerRadius = 5;
            this.btNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevo.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btNuevo.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btNuevo.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            // toolWindow2
            // 
            this.toolWindow2.Caption = null;
            this.toolWindow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolWindow2.Location = new System.Drawing.Point(1, 22);
            this.toolWindow2.Name = "toolWindow2";
            this.toolWindow2.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow2.Size = new System.Drawing.Size(364, 20);
            this.toolWindow2.Text = "toolWindow2";
            // 
            // frmTipoComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rDock);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmTipoComprobante";
            this.Text = "frmTipoComprobante";
            this.Load += new System.EventHandler(this.frmTipoComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).EndInit();
            this.rDock.ResumeLayout(false);
            this.documentWindow4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridComprobante;
        private DevExpress.XtraGrid.Views.Grid.GridView dgComprobante;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer3;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private XanderUI.XUIButton xuiButton1;
        private XanderUI.XUIButton btEliminar;
        private XanderUI.XUIButton btModificar;
        private XanderUI.XUIButton btNuevo;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private DevExpress.XtraGrid.Columns.GridColumn colpk_comprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colcomCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colcomNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colcomSerie;
        private DevExpress.XtraGrid.Columns.GridColumn colcomCorrelativo;
        private DevExpress.XtraGrid.Columns.GridColumn colcomEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow2;
        private Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadDropDownList cbEstado;
        private XanderUI.XUIButton btLimpiar;
        private Telerik.WinControls.UI.RadTextBox txtNombre;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}