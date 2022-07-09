namespace Presentacion.Forms.frmDetails
{
    partial class frmSeleccionarCliente
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btNuevo = new XanderUI.XUIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new Telerik.WinControls.UI.RadTextBox();
            this.txtDni = new Telerik.WinControls.UI.RadTextBox();
            this.gridCliente = new DevExpress.XtraGrid.GridControl();
            this.dgCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.documentContainer2 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCliente)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            this.documentWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer2)).BeginInit();
            this.documentContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btNuevo);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.txtBuscarNombre);
            this.radGroupBox1.Controls.Add(this.txtDni);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(682, 67);
            this.radGroupBox1.TabIndex = 50;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // btNuevo
            // 
            this.btNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btNuevo.Location = new System.Drawing.Point(580, 28);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(84, 25);
            this.btNuevo.TabIndex = 47;
            this.btNuevo.TextColor = System.Drawing.Color.White;
            this.btNuevo.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(346, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Dni:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(7, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Nombre:";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(64, 30);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(267, 20);
            this.txtBuscarNombre.TabIndex = 45;
            this.txtBuscarNombre.ThemeName = "Office2010Silver";
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.txtBuscarNombre_TextChanged);
            this.txtBuscarNombre.Enter += new System.EventHandler(this.txtBuscarNombre_Enter);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(381, 30);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(181, 20);
            this.txtDni.TabIndex = 45;
            this.txtDni.ThemeName = "Office2010Silver";
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            this.txtDni.Enter += new System.EventHandler(this.txtDni_Enter);
            // 
            // gridCliente
            // 
            this.gridCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gridCliente.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridCliente.Location = new System.Drawing.Point(0, 72);
            this.gridCliente.MainView = this.dgCliente;
            this.gridCliente.Name = "gridCliente";
            this.gridCliente.Size = new System.Drawing.Size(682, 240);
            this.gridCliente.TabIndex = 0;
            this.gridCliente.UseEmbeddedNavigator = true;
            this.gridCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgCliente});
            // 
            // dgCliente
            // 
            this.dgCliente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dgCliente.GridControl = this.gridCliente;
            this.dgCliente.Name = "dgCliente";
            this.dgCliente.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dgCliente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgCliente.OptionsView.ShowGroupPanel = false;
            this.dgCliente.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgCliente_RowCellStyle);
            this.dgCliente.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.dgCliente_ShowingEditor);
            this.dgCliente.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgCliente_FocusedRowChanged);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.pnHeader.Controls.Add(this.btClose);
            this.pnHeader.Controls.Add(this.label12);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(712, 49);
            this.pnHeader.TabIndex = 48;
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseMove);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackgroundImage = global::Presentacion.Properties.Resources.cerrar__1_;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(670, 13);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(20, 20);
            this.btClose.TabIndex = 16;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "CLIENTE";
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.documentWindow1;
            this.radDock1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radDock1.CausesValidation = false;
            this.radDock1.Controls.Add(this.documentContainer2);
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(9, 63);
            this.radDock1.MainDocumentContainer = this.documentContainer2;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock1.Size = new System.Drawing.Size(694, 347);
            this.radDock1.SplitterWidth = 3;
            this.radDock1.TabIndex = 50;
            this.radDock1.TabStop = false;
            this.radDock1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.SplitPanelElement)(this.radDock1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(5);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.SystemColors.Control;
            // 
            // documentWindow1
            // 
            this.documentWindow1.BackColor = System.Drawing.SystemColors.Control;
            this.documentWindow1.Controls.Add(this.radGroupBox1);
            this.documentWindow1.Controls.Add(this.gridCliente);
            this.documentWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow1.Location = new System.Drawing.Point(6, 29);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(682, 312);
            this.documentWindow1.Text = "  L I S T A  D E  C L I E N T E";
            // 
            // documentContainer2
            // 
            this.documentContainer2.CausesValidation = false;
            this.documentContainer2.Controls.Add(this.documentTabStrip1);
            this.documentContainer2.Name = "documentContainer2";
            // 
            // 
            // 
            this.documentContainer2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer2.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer2.SplitterWidth = 3;
            this.documentContainer2.ThemeName = "Office2010Silver";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.CausesValidation = false;
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.BorderHighlightColor = System.Drawing.SystemColors.Control;
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(694, 347);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.UI.SplitPanelElement)(this.documentTabStrip1.GetChildAt(0))).BorderHighlightColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(1))).InnerColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(1))).InnerColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(1))).InnerColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderColor2 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderInnerColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderInnerColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderLeftColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderTopColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.RadPageViewTabStripElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor2 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor3 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).IsPinned = false;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(39)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).Text = "  L I S T A  D E  C L I E N T E";
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.UI.ActionButtonElement)(this.documentTabStrip1.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1))).ToolTipText = "Active Documents";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(2))).TopColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.documentTabStrip1.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(2))).BottomColor = System.Drawing.SystemColors.ControlDark;
            // 
            // frmSeleccionarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 419);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSeleccionarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarCliente";
            this.Load += new System.EventHandler(this.frmSeleccionarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCliente)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            this.documentWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer2)).EndInit();
            this.documentContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private XanderUI.XUIButton btNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadTextBox txtBuscarNombre;
        private Telerik.WinControls.UI.RadTextBox txtDni;
        private DevExpress.XtraGrid.GridControl gridCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView dgCliente;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer2;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
    }
}