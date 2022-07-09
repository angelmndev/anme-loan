namespace Presentacion.Forms.frmNew
{
    partial class frmNuevoNegocio
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btCancelar = new XanderUI.XUIButton();
            this.btGuardar = new XanderUI.XUIButton();
            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.txtNif = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombreFiscal = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombreComercial = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWeb = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPais = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProvincia = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new Telerik.WinControls.UI.RadTextBox();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreComercial)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvincia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoPostal)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.txtProvincia);
            this.radGroupBox1.Controls.Add(this.txtPais);
            this.radGroupBox1.Controls.Add(this.txtWeb);
            this.radGroupBox1.Controls.Add(this.txtEmail);
            this.radGroupBox1.Controls.Add(this.txtCodigoPostal);
            this.radGroupBox1.Controls.Add(this.txtNif);
            this.radGroupBox1.Controls.Add(this.txtNombreFiscal);
            this.radGroupBox1.Controls.Add(this.txtNombreComercial);
            this.radGroupBox1.Controls.Add(this.label8);
            this.radGroupBox1.Controls.Add(this.label7);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(17, 64);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(446, 324);
            this.radGroupBox1.TabIndex = 14;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btCancelar);
            this.radGroupBox2.Controls.Add(this.btGuardar);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(14, 257);
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
            this.btCancelar.TabIndex = 1;
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
            this.btGuardar.TabIndex = 0;
            this.btGuardar.TextColor = System.Drawing.Color.White;
            this.btGuardar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(14, 110);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(414, 20);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.ThemeName = "Office2010Silver";
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtNif
            // 
            this.txtNif.Location = new System.Drawing.Point(14, 226);
            this.txtNif.MaxLength = 20;
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(201, 20);
            this.txtNif.TabIndex = 3;
            this.txtNif.ThemeName = "Office2010Silver";
            this.txtNif.TextChanged += new System.EventHandler(this.txtNif_TextChanged);
            // 
            // txtNombreFiscal
            // 
            this.txtNombreFiscal.Location = new System.Drawing.Point(14, 73);
            this.txtNombreFiscal.Name = "txtNombreFiscal";
            this.txtNombreFiscal.Size = new System.Drawing.Size(414, 20);
            this.txtNombreFiscal.TabIndex = 2;
            this.txtNombreFiscal.ThemeName = "Office2010Silver";
            this.txtNombreFiscal.TextChanged += new System.EventHandler(this.txtNombreFiscal_TextChanged);
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(14, 34);
            this.txtNombreComercial.MaxLength = 1000;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(414, 20);
            this.txtNombreComercial.TabIndex = 1;
            this.txtNombreComercial.ThemeName = "Office2010Silver";
            this.txtNombreComercial.TextChanged += new System.EventHandler(this.txtNombreComercial_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(11, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Nif:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(11, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Nombre fiscal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Nombre comercial:";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.pnHeader.Controls.Add(this.btClose);
            this.pnHeader.Controls.Add(this.label12);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(483, 49);
            this.pnHeader.TabIndex = 13;
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseMove);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(273, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "NUEVO DATOS DEL NEGOCIO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label6.Location = new System.Drawing.Point(11, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Web:";
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(14, 150);
            this.txtWeb.MaxLength = 200;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(414, 20);
            this.txtWeb.TabIndex = 4;
            this.txtWeb.ThemeName = "Office2010Silver";
            this.txtWeb.TextChanged += new System.EventHandler(this.txtWeb_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label7.Location = new System.Drawing.Point(11, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Pais:";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(14, 189);
            this.txtPais.MaxLength = 80;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(201, 20);
            this.txtPais.TabIndex = 4;
            this.txtPais.ThemeName = "Office2010Silver";
            this.txtPais.TextChanged += new System.EventHandler(this.txtPais_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label8.Location = new System.Drawing.Point(224, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Provincia:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(227, 189);
            this.txtProvincia.MaxLength = 200;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(201, 20);
            this.txtProvincia.TabIndex = 4;
            this.txtProvincia.ThemeName = "Office2010Silver";
            this.txtProvincia.TextChanged += new System.EventHandler(this.txtProvincia_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(224, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Codigo postal:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(227, 226);
            this.txtCodigoPostal.MaxLength = 15;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(201, 20);
            this.txtCodigoPostal.TabIndex = 3;
            this.txtCodigoPostal.ThemeName = "Office2010Silver";
            this.txtCodigoPostal.TextChanged += new System.EventHandler(this.txtCodigoPostal_TextChanged);
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
            this.btClose.Location = new System.Drawing.Point(441, 13);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(20, 20);
            this.btClose.TabIndex = 0;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmNuevoNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 407);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoNegocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoNegocio";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreComercial)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvincia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoPostal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private XanderUI.XUIButton btCancelar;
        private XanderUI.XUIButton btGuardar;
        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private Telerik.WinControls.UI.RadTextBox txtNif;
        private Telerik.WinControls.UI.RadTextBox txtNombreFiscal;
        private Telerik.WinControls.UI.RadTextBox txtNombreComercial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadTextBox txtProvincia;
        private Telerik.WinControls.UI.RadTextBox txtPais;
        private Telerik.WinControls.UI.RadTextBox txtWeb;
        private Telerik.WinControls.UI.RadTextBox txtCodigoPostal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}