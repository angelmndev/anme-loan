namespace Presentacion.Forms.frmNew
{
    partial class frmNuevoCargo
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            this.object_49327f99_70ba_4d15_b096_014e6599599a = new Telerik.WinControls.UI.RadLabelRootElement();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.chkEstado = new Telerik.WinControls.UI.RadCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCargo = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btCancelar = new XanderUI.XUIButton();
            this.btGuardar = new XanderUI.XUIButton();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
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
            this.pnHeader.Size = new System.Drawing.Size(478, 49);
            this.pnHeader.TabIndex = 11;
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
            this.btClose.Location = new System.Drawing.Point(436, 13);
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
            this.label12.Size = new System.Drawing.Size(148, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "NUEVO CARGO";
            // 
            // object_49327f99_70ba_4d15_b096_014e6599599a
            // 
            this.object_49327f99_70ba_4d15_b096_014e6599599a.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.object_49327f99_70ba_4d15_b096_014e6599599a.Name = "object_49327f99_70ba_4d15_b096_014e6599599a";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.chkEstado);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.txtCargo);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 62);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(454, 152);
            this.radGroupBox1.TabIndex = 12;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(20, 60);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(54, 18);
            this.chkEstado.TabIndex = 48;
            this.chkEstado.Text = "Estado";
            this.chkEstado.ThemeName = "Office2010Silver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Cargo:";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(20, 34);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(414, 20);
            this.txtCargo.TabIndex = 46;
            this.txtCargo.ThemeName = "Office2010Silver";
            this.txtCargo.TextChanged += new System.EventHandler(this.txtCargo_TextChanged);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btCancelar);
            this.radGroupBox2.Controls.Add(this.btGuardar);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(20, 90);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(414, 49);
            this.radGroupBox2.TabIndex = 45;
            this.radGroupBox2.ThemeName = "Office2010Silver";
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btCancelar.ButtonImage = null;
            this.btCancelar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btCancelar.ButtonText = "CANCELAR";
            this.btCancelar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btCancelar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.CornerRadius = 5;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancelar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btCancelar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btCancelar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btCancelar.Location = new System.Drawing.Point(179, 10);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(109, 30);
            this.btCancelar.TabIndex = 26;
            this.btCancelar.TextColor = System.Drawing.Color.White;
            this.btCancelar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGuardar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.ButtonImage = null;
            this.btGuardar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btGuardar.ButtonText = "GUARDAR";
            this.btGuardar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.ClickTextColor = System.Drawing.Color.WhiteSmoke;
            this.btGuardar.CornerRadius = 5;
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btGuardar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btGuardar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btGuardar.Location = new System.Drawing.Point(294, 10);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(109, 30);
            this.btGuardar.TabIndex = 25;
            this.btGuardar.TextColor = System.Drawing.Color.White;
            this.btGuardar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // frmNuevoCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 226);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoCargo";
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
        private Telerik.WinControls.UI.RadLabelRootElement object_49327f99_70ba_4d15_b096_014e6599599a;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private XanderUI.XUIButton btCancelar;
        private XanderUI.XUIButton btGuardar;
        private Telerik.WinControls.UI.RadTextBox txtCargo;
        private Telerik.WinControls.UI.RadCheckBox chkEstado;
        private System.Windows.Forms.Label label2;
    }
}