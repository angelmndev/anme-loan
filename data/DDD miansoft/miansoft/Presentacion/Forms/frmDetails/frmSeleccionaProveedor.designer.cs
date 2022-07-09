namespace Presentacion.Forms.frmDetails
{
    partial class frmSeleccionaProveedor
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.rDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow4 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.gridProveedor = new DevExpress.XtraGrid.GridControl();
            this.dgProveedor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.documentContainer3 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip4 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.txtBuscarNombre = new Telerik.WinControls.UI.RadTextBox();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarRuc = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btNuevo = new XanderUI.XUIButton();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).BeginInit();
            this.rDock.SuspendLayout();
            this.documentWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer3)).BeginInit();
            this.documentContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip4)).BeginInit();
            this.documentTabStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarRuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
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
            this.pnHeader.Size = new System.Drawing.Size(712, 49);
            this.pnHeader.TabIndex = 11;
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnHeader_MouseMove);
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
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "PROVEEDOR";
            // 
            // rDock
            // 
            this.rDock.ActiveWindow = this.documentWindow4;
            this.rDock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rDock.BackColor = System.Drawing.SystemColors.Control;
            this.rDock.CausesValidation = false;
            this.rDock.Controls.Add(this.documentContainer3);
            this.rDock.IsCleanUpTarget = true;
            this.rDock.Location = new System.Drawing.Point(9, 125);
            this.rDock.MainDocumentContainer = this.documentContainer3;
            this.rDock.Name = "rDock";
            this.rDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.rDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.rDock.Size = new System.Drawing.Size(694, 285);
            this.rDock.SplitterWidth = 3;
            this.rDock.TabIndex = 17;
            this.rDock.TabStop = false;
            this.rDock.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rDock.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rDock.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rDock.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.rDock.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.ControlLightLight;
            // 
            // documentWindow4
            // 
            this.documentWindow4.BackColor = System.Drawing.SystemColors.Control;
            this.documentWindow4.Controls.Add(this.gridProveedor);
            this.documentWindow4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentWindow4.Location = new System.Drawing.Point(6, 29);
            this.documentWindow4.Name = "documentWindow4";
            this.documentWindow4.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow4.Size = new System.Drawing.Size(682, 250);
            this.documentWindow4.Text = "L I S T A  D E  P R O V E E D O R ";
            // 
            // gridProveedor
            // 
            this.gridProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gridProveedor.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridProveedor.Location = new System.Drawing.Point(0, 3);
            this.gridProveedor.MainView = this.dgProveedor;
            this.gridProveedor.Name = "gridProveedor";
            this.gridProveedor.Size = new System.Drawing.Size(682, 247);
            this.gridProveedor.TabIndex = 0;
            this.gridProveedor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgProveedor});
            // 
            // dgProveedor
            // 
            this.dgProveedor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dgProveedor.GridControl = this.gridProveedor;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dgProveedor.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgProveedor.OptionsView.ShowGroupPanel = false;
            this.dgProveedor.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.DgProveedor_RowCellStyle);
            this.dgProveedor.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.DgProveedor_ShowingEditor);
            this.dgProveedor.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgProveedor_FocusedRowChanged);
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
            this.documentTabStrip4.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip4.SelectedIndex = 0;
            this.documentTabStrip4.Size = new System.Drawing.Size(694, 285);
            this.documentTabStrip4.TabIndex = 0;
            this.documentTabStrip4.TabStop = false;
            this.documentTabStrip4.ThemeName = "Office2010Silver";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.ControlLightLight;
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
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BorderBottomColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).IsPinned = false;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(33)))), ((int)(((byte)(91)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).Text = "L I S T A  D E  P R O V E E D O R ";
            ((Telerik.WinControls.UI.TabStripItem)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.SystemColors.Control;
            ((Telerik.WinControls.UI.ActionButtonElement)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1))).ToolTipText = "Active Documents";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.documentTabStrip4.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor4 = System.Drawing.SystemColors.ControlLightLight;
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(64, 30);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(267, 20);
            this.txtBuscarNombre.TabIndex = 45;
            this.txtBuscarNombre.ThemeName = "Office2010Silver";
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.TxtBuscarNombre_TextChanged);
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
            // txtBuscarRuc
            // 
            this.txtBuscarRuc.Location = new System.Drawing.Point(381, 30);
            this.txtBuscarRuc.Name = "txtBuscarRuc";
            this.txtBuscarRuc.Size = new System.Drawing.Size(181, 20);
            this.txtBuscarRuc.TabIndex = 45;
            this.txtBuscarRuc.ThemeName = "Office2010Silver";
            this.txtBuscarRuc.TextChanged += new System.EventHandler(this.TxtBuscarRuc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(346, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Ruc:";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btNuevo);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.txtBuscarNombre);
            this.radGroupBox1.Controls.Add(this.txtBuscarRuc);
            this.radGroupBox1.HeaderText = "Busqueda";
            this.radGroupBox1.Location = new System.Drawing.Point(8, 55);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(695, 67);
            this.radGroupBox1.TabIndex = 47;
            this.radGroupBox1.Text = "Busqueda";
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
            this.btNuevo.Location = new System.Drawing.Point(593, 28);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(84, 25);
            this.btNuevo.TabIndex = 47;
            this.btNuevo.TextColor = System.Drawing.Color.White;
            this.btNuevo.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btNuevo.Click += new System.EventHandler(this.BtNuevo_Click);
            // 
            // frmSeleccionaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 419);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.rDock);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSeleccionaProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionaProveedor";
            this.Load += new System.EventHandler(this.FrmSeleccionaProveedor_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rDock)).EndInit();
            this.rDock.ResumeLayout(false);
            this.documentWindow4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer3)).EndInit();
            this.documentContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip4)).EndInit();
            this.documentTabStrip4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarRuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.UI.Docking.RadDock rDock;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow4;
        private DevExpress.XtraGrid.GridControl gridProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView dgProveedor;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer3;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip4;
        private Telerik.WinControls.UI.RadTextBox txtBuscarNombre;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadTextBox txtBuscarRuc;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private XanderUI.XUIButton btNuevo;
    }
}