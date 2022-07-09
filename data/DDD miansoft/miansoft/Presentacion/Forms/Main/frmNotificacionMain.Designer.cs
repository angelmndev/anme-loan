namespace Presentacion.Forms.Main
{
    partial class frmNotificacionMain
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.dgStockMin = new Telerik.WinControls.UI.RadGridView();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.dgFechaVencimiento = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockMin.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFechaVencimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFechaVencimiento.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "N O T I F I C A C I O N E S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PRODUCTOS CON STOCK MINIMO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PRODUCTOS CON FECHA DE VENCIMIENTO A VENCER";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.pnHeader.Controls.Add(this.btClose);
            this.pnHeader.Controls.Add(this.label1);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(435, 40);
            this.pnHeader.TabIndex = 2;
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
            this.btClose.Location = new System.Drawing.Point(404, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(18, 18);
            this.btClose.TabIndex = 1;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dgStockMin
            // 
            this.dgStockMin.Location = new System.Drawing.Point(12, 19);
            // 
            // 
            // 
            this.dgStockMin.MasterTemplate.ShowColumnHeaders = false;
            this.dgStockMin.MasterTemplate.ShowFilteringRow = false;
            this.dgStockMin.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgStockMin.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgStockMin.Name = "dgStockMin";
            this.dgStockMin.ShowGroupPanel = false;
            this.dgStockMin.ShowGroupPanelScrollbars = false;
            this.dgStockMin.Size = new System.Drawing.Size(411, 77);
            this.dgStockMin.TabIndex = 3;
            this.dgStockMin.ThemeName = "MaterialTeal";
            this.dgStockMin.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dgStockMin_RowFormatting);
            this.dgStockMin.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgStockMin_CellDoubleClick);
            this.dgStockMin.DoubleClick += new System.EventHandler(this.dgStockMin_DoubleClick);
            // 
            // dgFechaVencimiento
            // 
            this.dgFechaVencimiento.Location = new System.Drawing.Point(15, 158);
            // 
            // 
            // 
            this.dgFechaVencimiento.MasterTemplate.ShowColumnHeaders = false;
            this.dgFechaVencimiento.MasterTemplate.ShowFilteringRow = false;
            this.dgFechaVencimiento.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgFechaVencimiento.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgFechaVencimiento.Name = "dgFechaVencimiento";
            this.dgFechaVencimiento.ShowGroupPanel = false;
            this.dgFechaVencimiento.ShowGroupPanelScrollbars = false;
            this.dgFechaVencimiento.Size = new System.Drawing.Size(408, 77);
            this.dgFechaVencimiento.TabIndex = 4;
            this.dgFechaVencimiento.ThemeName = "MaterialTeal";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgStockMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 99);
            this.panel1.TabIndex = 5;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmNotificacionMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 238);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgFechaVencimiento);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificacionMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNotificacionMain";
            this.Deactivate += new System.EventHandler(this.frmNotificacionMain_Deactivate);
            this.Load += new System.EventHandler(this.frmNotificacionMain_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmNotificacionMain_MouseMove);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockMin.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFechaVencimiento.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFechaVencimiento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnHeader;
        private Telerik.WinControls.UI.RadGridView dgStockMin;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadGridView dgFechaVencimiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Timer timer;
    }
}